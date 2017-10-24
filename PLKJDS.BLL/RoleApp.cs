using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Common;
using PLKJDS.Data;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.Common.Enums;
namespace PLKJDS.BLL
{
    public class RoleApp
    {
        IRoleRepository roleService = new RoleRepository();
        IRoleAuthorizeRepository roleAuth = new RoleAuthorizeRepository();

        public int AddRole(Role role, string[] permissionIds)
        {
            return roleService.SubmitForm(role, permissionIds, "");
        }

        public List<Role> GetList(string keyword, Pagination pagination)
        {
            var e = ExtLinq.True<Role>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.RoleName.Contains(keyword));
            }
            var list = roleService.FindList(e, pagination);

            return list;
        }

        public int ModifyRole(Role role, string[] permissionIds, string keyValue)
        {
            return roleService.SubmitForm(role, permissionIds, keyValue);
        }

        public int DeleteRole(string keyValue)
        {
            Role role = new Role();
            role.ID = keyValue;
            role.Remove();

            return roleService.Update(role);
        }

        public Role GetForm(string keyValue)
        {
            return roleService.FindEntity(keyValue);
        }
        public List<Role> GetList()
        {
            var e = ExtLinq.True<Role>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);

            var list = roleService.IQueryable(e).ToList();
                
            return list;
        }
    }
}
