using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkTools.Common
{
    public class GatherFriendsStatistics : IGatherFriendsStatistics
    {
        /* Useful uids:
         * 
         * 178646197 - own
         * 233425350 - without friends
         * 
         */

        public static GatherFriendsStatistics New()
        {
            return new GatherFriendsStatistics();
        }

        public Report ByUsers(int[] uids)
        {
            if (uids == null)
            {
                throw new ArgumentNullException("uids");
            }
            
            var report = new Report();
            
            var users = UserRepository.New().Get(uids);

            foreach (var u in users)
            {
                report.Items[u] = FriendRepository.New().Get(u.Uid).Length;
            }

            return report;
        }

        public Report ByUserFriends(int uid)
        {
            return ByUsers(

                FriendRepository.New().Get(uid)
            );
        }
    }
}
