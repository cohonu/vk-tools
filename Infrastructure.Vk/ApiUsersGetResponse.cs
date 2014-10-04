using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Vk
{
    public class ApiUsersGetResponse
    {
        public class User
        {

            public int uid;
            public string first_name;
            public string last_name;
            public string screen_name;
        }

        public User[] Response;
    }
}
