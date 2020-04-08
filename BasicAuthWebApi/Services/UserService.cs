using DALMockup.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthWebApi.Services
{
    public class UserService : IUserRepository
    {
        private IUserRepository _repo = new UserRepository(); 

        public bool Check(string username, string password)
        {
            return _repo.Check(username, password);
        }
    }
}