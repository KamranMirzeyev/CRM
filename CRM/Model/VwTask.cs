using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    class VwTask
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public DateTime  CreateAt { get; set; }
        public string DeadLine { get; set; }  
        public string Finished { get; set; }
        
    
    }
}
