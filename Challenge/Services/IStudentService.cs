using Challenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Services
{
    public interface IStudentService:IService<StudentViewModel>
    {
        public bool Delete(Guid id);
    }
}
