using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models
{
    public partial class Request : Entity
    {
        public Request()
        {
            this.RequestDocuments = new List<RequestDocument>();
        }

        public int RequestID { get; set; }
        public Int32 ClaimID { get; set; }
        public string VendorName { get; set; }
        public string ProductLine { get; set; }
        public string Representation { get; set; }
        public string RepresentationPosition { get; set; }
        public string ProgramName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Model { get; set; }
        public long Target { get; set; }
        public string Unit { get; set; }
        public string Rebate { get; set; }
        public string Note { get; set; }
        public int Status { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
        public int LastEditBy { get; set; }
        public DateTime LastEditTime { get; set; }

        // public virtual Claim Claim { get; set; }
        public virtual ICollection<RequestDocument> RequestDocuments { get; set; }
    }
}
