using System;
using System.Text;
using Infrastructure.Vk;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace VkTools.Common
{
    public class UserRepository
    {
        private string _command = "https://api.vk.com/method/users.get?user_ids={0}&fields={1}";

        public static UserRepository New()
        {

            return new UserRepository();
        }

        public List<User> Get(int[] ids)
        {

            var idsEncoded = string.Join(",", ids);

            var rawData = SimpleWebClient.New().Get(

                string.Format(_command, idsEncoded, "screen_name")
            );

            return ParseUsers(rawData);
        }

        private List<User> ParseUsers(string rawData)
        {

            var response = JsonConvert.DeserializeObject<ApiUsersGetResponse>(rawData);

            var users = new List<User>();

            if (response.Response == null)
            {

                return users;
            }

            foreach (var raw in response.Response)
            {

                users.Add(

                    new User
                    {
                        Uid = raw.uid,
                        FirstName = raw.first_name,
                        LastName = raw.last_name,
                        ScreenName = raw.screen_name
                    }
                );
            }

            return users;
        }
    }
}
