using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    internal class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; } // the user Id who created this record
        public DateTime CreatedOn { get; set; } // the date of creation 
        public int LastModifiedBy { get; set; } // the user Id who modfied this record
        public DateTime LastModifiedOn { get; set; } // the date of the last modification
        public bool IsDeleted { get; set; } // to apply the concept of soft deleation


    }
}
