using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models
{
    public partial class Allocation : Entity
    {
        public Allocation()
        {
        }

        public int AllocationID { get; set; }
        public int ClaimID { get; set; }
        public int? PaymentID { get; set; }
        public string AreaAllocate { get; set; }
        public string Criteria { get; set; }
        public DateTime? FafDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public decimal? AllocateAmount { get; set; }
        public decimal? CalculateAmount { get; set; }
        public decimal? ActualAmount { get; set; }
        public DateTime? TimeAllocate { get; set; }
        public string ProgramCode { get; set; }
        public string NoteCalculate { get; set; }
        public string Note { get; set; }
        public string Participant { get; set; }
        public string Part { get; set; }


        // Mapping
        public virtual Claim Claim { internal get; set; }
        // public virtual Payment Payment { internal get; set; }
    }
}
