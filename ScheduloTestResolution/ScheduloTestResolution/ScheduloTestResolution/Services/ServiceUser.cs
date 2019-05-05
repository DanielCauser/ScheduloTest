using System;
using System.Collections.Generic;
using ScheduloTestResolution.Models;
using System.Linq;

namespace ScheduloTestResolution.Services
{
    public class ServiceUser : IServiceUser
    {
        List<ModelUser> _users = new List<ModelUser>()
        {
            new ModelUser("Fred", 1),
            new ModelUser("Wilma", 2)
        };

        public string GetUserNameById(int id)
        {
            return _users.Single(x => x.Id == id).Name;
        }
    }
}
