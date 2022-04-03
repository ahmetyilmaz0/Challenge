
using Challenge.Repositories;
using Challenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Services
{
    public class StudentService : Service<StudentRepository, Student, StudentViewModel>, IStudentService
    {
        public bool Delete(Guid id)
        {
            StudentPaidService _studentPaidService = new StudentPaidService();
            var paid = _studentPaidService.List().Where(x => x.studentID == id);
            if (paid != null)
            {
                foreach (var item in paid)
                {
                    _studentPaidService.Delete(item);
                }
            }
            return Delete(List().FirstOrDefault(x => x.studentID == id));
        }
    }
}
