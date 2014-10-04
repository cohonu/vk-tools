using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VkTools.Common
{
    public interface IGatherFriendsStatistics
    {
        Report ByUsers(int[] uids);

        Report ByUserFriends(int uid);
    }
}
