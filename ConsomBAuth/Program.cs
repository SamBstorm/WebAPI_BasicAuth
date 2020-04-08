using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsomBAuth
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5629/api/");
            HttpResponseMessage response = client.GetAsync("Employee/1").Result;
            Console.WriteLine("{0} - {1}", (int)response.StatusCode, response.ReasonPhrase);
            if ((int)response.StatusCode == 401)
            {
                var credentials = new NetworkCredential("Sam", "test1234=");
                var handler = new HttpClientHandler { Credentials = credentials };

                client = new HttpClient(handler);
                client.BaseAddress = new Uri("http://localhost:5629/api/");
                response = client.GetAsync("Employee/1").Result;
                Console.WriteLine("{0} - {1}", (int)response.StatusCode, response.ReasonPhrase);
            }
            if (response.IsSuccessStatusCode)
            {
                List<EmployeeDto> Lemployee = (List<EmployeeDto>)response.Content.ReadAsAsync<List<EmployeeDto>>().Result;

                foreach (var employee in Lemployee)
                {
                    Console.WriteLine("{0}\t{1}\t{2}",
                    employee.ID,
                    employee.FirstName,
                    employee.LastName);
                }
                
            }
            Console.ReadKey();
        }
    }
}
