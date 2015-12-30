using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;

namespace FrameLog
{
    public class ContextInfo
    {
        public ContextInfo(ObjectContext objectContext)
        {
            this.ObjectContext = objectContext;
            this.Workspace = objectContext.MetadataWorkspace;
        }

        public Type UnderlyingType { get; set; }
        public MetadataWorkspace Workspace { get; set; }
        // public IDataContext Context { get; set; }
        public ObjectContext ObjectContext { get; set; }
    }
}
