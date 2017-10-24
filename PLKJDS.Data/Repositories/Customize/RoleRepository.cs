using PLKJDS.Common.Enums;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Data.Repositories
{
    public partial class RoleRepository
    {
        public int SubmitForm(Role role, string[] permissionIds, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                role.Create();
            }
            else
            {
                role.Modify(keyValue);
            }
            var roleAuths = new List<RoleAuthorize>();
            foreach (var per in permissionIds)
            {
                RoleAuthorize roleAuth = new RoleAuthorize();
                roleAuth.Create();
                roleAuth.AuthorizeID = per;
                roleAuth.RoleID = role.ID;
                roleAuth.ObjectType = RoleAuthorizeType.Role.GetEnumCode();
                roleAuths.Add(roleAuth);
            }
            var ret = 0;
            using (var db = new RepositoryBase().BeginTrans())
            {
                if (string.IsNullOrEmpty(keyValue))
                {
                    db.Insert(role);
                }
                else
                {
                    db.Update(role);
                }
                db.Delete<RoleAuthorize>(t => t.RoleID == role.ID);
                db.Insert(roleAuths);
                ret = db.Commit();
            }
            return ret;
        }
    }
}
