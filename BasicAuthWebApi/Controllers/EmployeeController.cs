using BasicAuthWebApi.Helper;
using BasicAuthWebApi.Models;
using BasicAuthWebApi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BasicAuthWebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeService _employeeService = new EmployeeService();

        [BasicAuthenticator(realm:"MIKE8")]
        public IEnumerable<Employee> GET()
        {
            return _employeeService.Get();
        }
    }
}
