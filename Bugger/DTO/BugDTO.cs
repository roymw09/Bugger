using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugger.DTO
{
    public class BugDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Assignee { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string FixDescription { get; set; }
        public string DateRaised { get; set; }
        public string DateClosed { get; set; }
    }
}
