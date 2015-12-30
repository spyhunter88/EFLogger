using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models
{
    public class Document : Entity
    {
        public Document() { }

        public int DocumentID { get; set; }
        public int ReferenceID { get; set; }
        // public string ReferenceName { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime UploadTime { get; set; }
        public int UploadBy { get; set; }
    }

    public class ClaimDocument : Document
    {
        public ClaimDocument() { }

        public int ClaimID { get; set; }

        public virtual Claim Claim { get; set; }
    }

    public class RequestDocument : Document
    {
        public RequestDocument() { }

        public int RequestID { get; set; }

        public virtual Request Request { get; set; }
    }
}
