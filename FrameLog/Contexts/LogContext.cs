using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FrameLog.Models;
using FrameLog.Patterns.Models;

namespace FrameLog.Contexts
{
    public class LogContext : DbContext, IHistoryContext<ChangeSet, User>
    {
        public LogContext(string connectionString) : base(connectionString) { }
        public LogContext() : base("LogContext") { }

        public DbSet<User> Users { get; set; }
        public DbSet<ChangeSet> ChangeSets { get; set; }
        public DbSet<ObjectChange> ObjectChanges { get; set; }
        public DbSet<PropertyChange> PropertyChanges { get; set; }

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("AspNetUsers");
            modelBuilder.Entity<ChangeSet>().ToTable("ChangeSets");
            modelBuilder.Entity<ObjectChange>().ToTable("ObjectChanges");
            modelBuilder.Entity<PropertyChange>().ToTable("PropertyChanges");
        }

        public bool ObjectHasReference(object model)
        {
            throw new NotImplementedException();
        }

        public string GetReferenceForObject(object model)
        {
            throw new NotImplementedException();
        }

        public string GetReferencePropertyForObject(object model)
        {
            throw new NotImplementedException();
        }

        public object GetObjectByReference(Type type, string raw)
        {
            throw new NotImplementedException();
        }
    }
}
