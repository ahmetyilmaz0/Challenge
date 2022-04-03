using Challenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Services
{
    public interface IStudentPaidService:IService<StudentPaidViewModel>
    {
        IEnumerable<StudentPaidViewModel> GetByStudentIDDate(Guid studentid, DateTime startDate, DateTime endDate);
        IEnumerable<StudentPaidViewModel> GetbyStudentID(Guid studentid);
    }
}
