using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.ViewModels
{
    public class StudentPaidViewModel
    {
        public Guid studentPaidID { get; set; }
        public Guid studentID { get; set; }
        public decimal? studentPaidDetail { get; set; }
        public DateTime? studentPaidDate { get; set; }
    }
}
