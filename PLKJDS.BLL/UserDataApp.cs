using PLKJDS.Common;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.BLL
{
    public class UserDataApp
    {
        IUserDataRepository userDataService = new UserDataRepository();


        public List<UserData> GetUserDataList(string userId)
        {
            var e = ExtLinq.True<UserData>();
            e = e.And(x => x.UserID == userId);
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            var list = userDataService.IQueryable(e).OrderByDescending(x => x.CreatorTime).ToList();
            return list;
        }
    }
}
