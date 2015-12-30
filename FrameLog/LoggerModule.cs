using System.Data.Entity.Core.Objects;
using FrameLog.Contexts;
using FrameLog.Models;
using Logger.Pattern;

namespace FrameLog
{
    /// <summary>
    /// Base on FrameLogModule
    /// But use for user can controll over Entity's ObjectState, and do not need FrameLog to Save last
    /// </summary>
    public class LoggerModule : ILogging
    {
        public LoggerModule(string connectionString, ContextInfo contextInfo, User user)
        {
            this.user = user;
            this.contextInfo = contextInfo;
            context = new LogContext(connectionString);
        }

        public LoggerModule(string connectionString, ContextInfo contextInfo, int userId)
        {
            this.contextInfo = contextInfo;
            context = new LogContext(connectionString);
            this.user = context.Users.Find(userId);
        }

        #region Properties
        private FrameLog<ChangeSet, User> frameLog;

        public User user { get; set; }
        public ContextInfo contextInfo { get; set; }
        public LogContext context { get; set; }

        public ChangeSet ChangeSet { get; private set; }
        #endregion

        /// <summary>
        /// Use when SyncObjectChangePreCommit
        /// Collect ObjectStateManager, Entity information 
        /// </summary>
        public void SaveChangePreCommit()
        {
            frameLog = new FrameLog<ChangeSet, User>(contextInfo, new ChangeSetFactory());
            frameLog.LogChanges(user);
        }

        /// <summary>
        /// Maybe not neccessary because we will ReBake in the last phase
        /// </summary>
        public void SaveChangePostCommit()
        {
            ChangeSet = frameLog.ReBake(user);
            if (ChangeSet != null)
            {
                this.context.ChangeSets.Add(ChangeSet);
                this.context.SaveChanges();
            }
        }

        // Reset ChangeSet
        public void ClearChangeSet()
        {
            ChangeSet = null;
        }
    }
}
