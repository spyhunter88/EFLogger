using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models
{
    public partial class Category : Entity
    {
        public Category() { }

        public int CategoryID { get; set; }
        public String Type { get; set; }
        public String Code { get; set; }
        public String Value { get; set; }
        public String Description { get; set; }
    }
}
