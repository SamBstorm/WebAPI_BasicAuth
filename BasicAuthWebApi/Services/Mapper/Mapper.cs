using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G = DALMockup.Models;
using C = BasicAuthWebApi.Models;

namespace BasicAuthWebApi.Services.Mapper
{
    public static class Mapper
    {
        public static G.Employee ToGlobal(this C.Employee employee) {
            return new G.Employee
            {
                ID = employee.ID,
                LastName = employee.LastName,
                FirstName = employee.FirstName
            };
        }

        public static C.Employee ToClient(this G.Employee employee)
        {
            return new C.Employee
            {
                ID = employee.ID,
                LastName = employee.LastName,
                FirstName = employee.FirstName
            };
        }
    }
}