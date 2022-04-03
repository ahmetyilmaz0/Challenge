using Challenge.Repositories;
using Challenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Services
{
    public class StudentPaidService : Service<StudentPaidRepository, StudentPaid, StudentPaidViewModel>, IStudentPaidService
    {
        public IEnumerable<StudentPaidViewModel> GetByStudentIDDate(Guid studentid, DateTime startDate, DateTime endDate)
        {
            return List().Where(x => x.studentPaidDate >= startDate && x.studentPaidDate <= endDate && x.studentID == studentid).ToList();
        }

        public IEnumerable<StudentPaidViewModel> GetbyStudentID(Guid studentid)
        {
            return List().Where(x => x.studentID == studentid).ToList();
        }
    }
}
