using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Entity;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Common;
using PLKJDS.Common.Enums;

namespace PLKJDS.BLL
{
    public class RoleAuthorizeApp
    {
        IRoleAuthorizeRepository roleAuthorize = new RoleAuthorizeRepository();
        IAuthorizeRepository authorize = new AuthorizeRepository();
        public List<RoleAuthorize> GetList(string roleId, string roleAuthType)
        {
            var e = ExtLinq.True<RoleAuthorize>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            e = e.And(x => x.RoleID == roleId);
            var list = roleAuthorize.IQueryable(e).ToList();
            return list;
        }
        /// <summary>
        /// 获取菜单和按钮
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<Authorize> GetAuthorizeList(string roleId, AuthorizeType type)
        {
            var list = GetList(roleId, "");
            List<Authorize> auths = new List<Authorize>();
            foreach (var auth in list)
            {
                var temp = authorize.FindEntity(auth.AuthorizeID);
                if (temp != null && temp.AuthorizeType == type.GetEnumCode())
                {
                    auths.Add(temp);
                }
            }
            var testlist = auths.OrderBy(x => x.SortCode).ToList();
            return auths.OrderBy(x => x.SortCode).ToList();
        }

        
    }
}
