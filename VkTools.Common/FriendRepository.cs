using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Infrastructure.Vk;

namespace VkTools.Common
{
    public class FriendRepository
    {
        private string _command = "https://api.vk.com/method/friends.get?user_id={0}";

        public static FriendRepository New()
        {

            return new FriendRepository();
        }

        public int[] Get(int userId)
        {

            return ParseIds(

                SimpleWebClient.New().Get(

                    string.Format(_command, userId)
                )
            );
        }

        private int[] ParseIds(string rawData)
        {

            var r = JsonConvert.DeserializeObject<ApiFriendsGetResponse>(rawData);

            return r.Response;
        }
    }
}
