using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Reflection;
using System.Text;
using FrameLog.Exceptions;

namespace FrameLog.Helpers
{
    /// <summary>
    /// Helper extract from ObjectContextAdapter to work with Object, Key, Reference ...
    /// </summary>
    public class DataContextHelper
    {
        public static object GetObjectByKey(ObjectContext context, EntityKey key)
        {
            return context.GetObjectByKey(key);
        }
        public static string KeyPropertyName
        {
            get { return "Id"; }
        }
        public static object KeyFromReference(string reference)
        {
            return int.Parse(reference);
        }

        /// <summary>
        /// Return the object of the specified type that has the specified reference.
        /// GetReferenceForObject(GetObjectByReference(type, reference)) == reference
        /// </summary>
        public static object GetObjectByReference(ObjectContext context, Type type, string reference)
        {
            try
            {
                var container = context.MetadataWorkspace.GetEntityContainer(
                            context.DefaultContainerName, DataSpace.CSpace);
                var set = container.BaseEntitySets.FirstOrDefault(meta => meta.ElementType.Name == type.Name);
                if (set == null)
                    throw new ObjectTypeDoesNotExistInDataModelException(type);

                var key = new EntityKey(container.Name + "." + set.Name, KeyPropertyName, KeyFromReference(reference));
                return GetObjectByKey(context, key);
            }
            catch (Exception e)
            {
                throw new FailedToRetrieveObjectException(type, reference, e);
            }
        }

        /// <summary>
        /// Return true if the object has a logging reference, otherwise false
        /// </summary>
        public static bool ObjectHasReference(object entity)
        {
            if (entity == null)
                return false;

            IHasLoggingReference entityWithReference = entity as IHasLoggingReference;
            if (entityWithReference != null)
                return true;

            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.IgnoreCase;
            string keyPropertyName = GetReferencePropertyForObject(entity);
            var keyProperty = entity.GetType().GetProperty(keyPropertyName, flags);
            if (keyProperty != null)
                return true;

            return false;
        }

        /// <summary>
        /// Return an unique reference that FrameLog uses to refer to the object
        /// in the logs. Normally the primary key.
        /// </summary>
        public static string GetReferenceForObject(ObjectContext context, object entity)
        {
            if (entity == null)
                return null;

            IHasLoggingReference entityWithReference = entity as IHasLoggingReference;
            if (entityWithReference != null)
                return entityWithReference.Reference.ToString();

            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.IgnoreCase;
            string keyPropertyName = GetReferencePropertyForObject(entity);
            var keyProperty = entity.GetType().GetProperty(keyPropertyName, flags);
            if (keyProperty != null)
                return keyProperty.GetGetMethod().Invoke(entity, null).ToString();

            ObjectStateEntry entry = null;
            if (context.ObjectStateManager.TryGetObjectStateEntry(entity, out entry))
            {
                var keyMember = entry.EntityKey.EntityKeyValues.FirstOrDefault();
                if (keyMember != null && keyMember.Value != null)
                    return keyMember.Value.ToString();
            }

            throw new Exception(string.Format("Attempted to log a foreign entity that did not implement IHasLoggingReference and that did not have a property with name '{0}'. It had type {1}, and it was '{2}'",
                    KeyPropertyName, entity.GetType(), entity));
        }

        /// <summary>
        /// Return the primary key property for an object
        /// </summary>
        public static string GetReferencePropertyForObject(object entity)
        {
            return KeyPropertyName;
        }
    }
}
