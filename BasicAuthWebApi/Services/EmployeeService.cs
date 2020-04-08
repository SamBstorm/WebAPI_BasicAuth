using BasicAuthWebApi.Models;
using BasicAuthWebApi.Services.Mapper;
using DALMockup.Models;
using DALMockup.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G = DALMockup.Models;
using C = BasicAuthWebApi.Models;

namespace BasicAuthWebApi.Services
{
    public class EmployeeService : IEmployeeRepository<int,C.Employee>
    {
        private IEmployeeRepository<int,G.Employee> _repo = new EmployeeRepository();

        public void Add(C.Employee entity)
        {
            _repo.Add(entity.ToGlobal());
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public IEnumerable<C.Employee> Get()
        {
            return _repo.Get().Select(e => e.ToClient());
        }

        public C.Employee Get(int id)
        {
            return _repo.Get(id).ToClient();
        }

        public IEnumerable<C.Employee> Get(string lastName)
        {
            return _repo.Get(lastName).Select(e => e.ToClient());
        }

        public void Update(int id, C.Employee entity)
        {
            _repo.Update(id, entity.ToGlobal());
        }
    }
}