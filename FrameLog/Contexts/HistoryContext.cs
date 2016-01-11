using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FrameLog.Models;
using FrameLog.Patterns.Models;
using FrameLog.Helpers;
using System.Data.Entity.Core.Objects;

namespace FrameLog.Contexts
{
    public class HistoryContext : LogContext, IHistoryContext<ChangeSet, User>
    {
        public HistoryContext(string connectionString) : base(connectionString) { }
        public HistoryContext() : base("LogContext") { }

        IQueryable<IChangeSet<User>> IHistoryContext<ChangeSet, User>.ChangeSets
        {
            get { return ChangeSets; }
        }

        IQueryable<IObjectChange<User>> IHistoryContext<ChangeSet, User>.ObjectChanges
        {
            get { return ObjectChanges; }
        }

        IQueryable<IPropertyChange<User>> IHistoryContext<ChangeSet, User>.PropertyChanges
        {
            get { return PropertyChanges; }
        }

        public bool ObjectHasReference(object model)
        {
            return DataContextHelper.ObjectHasReference(model);
        }

        public string GetReferenceForObject(object model)
        {
            return DataContextHelper.GetReferenceForObject(ContextInfo.ObjectContext, model);
        }

        public string GetReferencePropertyForObject(object model)
        {
            return DataContextHelper.GetReferencePropertyForObject(model);
        }

        public object GetObjectByReference(Type type, string raw)
        {
            return DataContextHelper.GetObjectByReference(ContextInfo.ObjectContext, type, raw);
        }
    }
}
