using System;
using System.Data.Entity.Core.Objects;
using FrameLog.Filter;
using FrameLog.Logging;
using FrameLog.Patterns.Models;

namespace FrameLog
{
    /// <summary>
    /// 
    /// </summary>
    class FrameLog<TChangeSet, TPrincipal>
        where TChangeSet : IChangeSet<TPrincipal>
    {
        public bool Enabled { get; set; }
        private ContextInfo contextInfo;
        private IChangeSetFactory<TChangeSet, TPrincipal> factory;
        private ILoggingFilter filter;

        // Extend variable to save when change phase before and after save
        private ChangeLogger<TChangeSet, TPrincipal> logger;
        private IOven<TChangeSet, TPrincipal> oven;

        public FrameLog(ContextInfo contextInfo,
            IChangeSetFactory<TChangeSet, TPrincipal> factory,
            ILoggingFilterProvider filter = null)
        {
            this.contextInfo = contextInfo;
            this.factory = factory;
            this.filter = (filter ?? Filter.Filters.Default).Get(contextInfo);
            Enabled = true;
        }

        /// <summary>
        /// Run in PreCommit phase to create Framelog module, IOven instance
        /// </summary>
        /// <param name="principal"></param>
        public void LogChanges(TPrincipal principal)
        {
            logger = new ChangeLogger<TChangeSet, TPrincipal>(contextInfo.ObjectContext, factory, filter);
            oven = logger.Log(contextInfo.ObjectContext.ObjectStateManager);
        }

        /// <summary>
        /// Call in SyncPostCommit or call after Commit when use UnitOfWork transaction.
        /// </summary>
        public TChangeSet ReBake(TPrincipal principal)
        {
            if (oven.HasChangeSet)
            {
                TChangeSet changeSet = oven.Bake(DateTime.Now, principal);
                return changeSet;
            }

            return default(TChangeSet);
        }
    }
}
