using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.ViewModels
{
    public class StudentViewModel
    {
        public Guid studentID { get; set; }
        public int studentNumber { get; set; }
        public string studentName { get; set; }
        public string studentSurname { get; set; }
        public List<StudentPaidViewModel> studentPaid { get; set; }
    }
}
