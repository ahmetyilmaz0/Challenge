using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Services
{
    public interface IService<ViewModel>
    {
        IList<ViewModel> List();
        bool Add(ViewModel entity);
        bool Delete(ViewModel entity);
        bool Update(ViewModel entity);
    }
}
