
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Services
{
    using Challenge.Repositories;
    using AutoMapper;

    public class Service<Rep, Entity, ViewModel> : IService<ViewModel> where Rep : IRepository<Entity>
    {
        private static Rep _repository;

        public static Rep Repository
        {
            get
            {
                if (_repository == null)
                    _repository = Activator.CreateInstance<Rep>();
                return _repository;
            }
            set { _repository = value; }
        }

        private IMapper _mapper { get; set; }
        protected virtual IMapper Mapper
        {
            get
            {
                return _mapper ?? (_mapper = new MapperConfiguration(mc => mc.AddProfile(new Helpers.Mapper())).CreateMapper());
            }
        }
        public virtual bool Add(ViewModel entity)
        {
            return Repository.Add(Mapper.Map<Entity>(entity));
        }

        public virtual bool Delete(ViewModel entity)
        {
            return Repository.Delete(Mapper.Map<Entity>(entity));
        }

        public virtual IList<ViewModel> List()
        {
            return Mapper.Map<IList<ViewModel>>(Repository.List().ToList()).ToList();
        }

        public virtual bool Update(ViewModel entity)
        {
            return Repository.Update(Mapper.Map<Entity>(entity));
        }
    }
}
