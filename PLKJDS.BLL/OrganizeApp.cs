using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Common;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;

namespace PLKJDS.BLL
{
    public class OrganizeApp
    {
        IOrganizeRepository organize = new OrganizeRepository();
        IUserRepository user = new UserRepository();
        public List<Organize> GetList(Pagination pagination,string keyword)
        {
            var e = ExtLinq.True<Organize>();
            e = e.And(x =>(x.DeleteMark==null?false:x.DeleteMark) != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.OrgName.Contains(keyword));
            }

            List<Organize> list = null;
            if (pagination != null)
            {
                if (pagination.sord == "asc")
                {
                    if (pagination.sidx == "OrgName")
                    {
                        list = organize.IQueryable(e).OrderBy(x => x.OrgName).ToList();
                    }
                    else if (pagination.sidx == "OrgCode")
                    {
                        list = organize.IQueryable(e).OrderBy(x => x.OrgCode).ToList();
                    }
                    else if (pagination.sidx == "OrgType")
                    {
                        list = organize.IQueryable(e).OrderBy(x => x.OrgType).ToList();
                    }
                    else if (pagination.sidx == "OrgProp")
                    {
                        list = organize.IQueryable(e).OrderBy(x => x.OrgProp).ToList();
                    }
                    else if (pagination.sidx == "OrgContact")
                    {
                        list = organize.IQueryable(e).OrderBy(x => x.OrgContact).ToList();
                    }
                    else if (pagination.sidx == "CreatorTime")
                    {
                        list = organize.IQueryable(e).OrderBy(x => x.CreatorTime).ToList();
                    }
                    else if (pagination.sidx == "IsEnable")
                    {
                        list = organize.IQueryable(e).OrderBy(x => x.IsEnable).ToList();
                    }
                    else//IsPublic
                    {
                        list = organize.IQueryable(e).OrderBy(x => x.ReMark).ToList();
                    }

                }
                else
                {
                    if (pagination.sidx == "OrgName")
                    {
                        list = organize.IQueryable(e).OrderByDescending(x => x.OrgName).ToList();
                    }
                    else if (pagination.sidx == "OrgCode")
                    {
                        list = organize.IQueryable(e).OrderByDescending(x => x.OrgCode).ToList();
                    }
                    else if (pagination.sidx == "OrgType")
                    {
                        list = organize.IQueryable(e).OrderByDescending(x => x.OrgType).ToList();
                    }
                    else if (pagination.sidx == "OrgProp")
                    {
                        list = organize.IQueryable(e).OrderByDescending(x => x.OrgProp).ToList();
                    }
                    else if (pagination.sidx == "OrgContact")
                    {
                        list = organize.IQueryable(e).OrderByDescending(x => x.OrgContact).ToList();
                    }
                    else if (pagination.sidx == "CreatorTime")
                    {
                        list = organize.IQueryable(e).OrderByDescending(x => x.CreatorTime).ToList();
                    }
                    else if (pagination.sidx == "IsEnable")
                    {
                        list = organize.IQueryable(e).OrderByDescending(x => x.IsEnable).ToList();
                    }
                    else//IsPublic
                    {
                        list = organize.IQueryable(e).OrderByDescending(x => x.ReMark).ToList();
                    }
                    //list = authorizeButtonApp.IQueryable(e).OrderByDescending(x => x.SortCode).ToList();
                }
                list = list.Skip(pagination.rows * (pagination.page - 1)).Take(pagination.rows).ToList();
            }
            else
            {
                list = organize.FindList(e, pagination);
            }
            return list;
        }

        public List<Organize> GetList()
        {
            var e = ExtLinq.True<Organize>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            var list = organize.IQueryable(e).ToList();
            return list;
        }

        public int AddOrganize(Organize org)
        {
            org.Create();
            var ret = organize.Insert(org);
            return ret;
        }

        public int ModifyOrganize(Organize org, string keyValue)
        {
            org.Modify(keyValue);
            var ret = organize.Update(org);
            return ret;
        }


        public int DeleteOrganize(string keyValue)
        {
            var userCount = user.IQueryable(x => x.OrgID == keyValue).Count();
            if (userCount > 0)
            {
                return 0;
            }
            else
            {
                Organize org = new Organize();
                org.ID = keyValue;
                org.Remove();
                var ret = organize.Update(org);
                return ret;
            }
        }
        public Organize GetForm(string keyValue)
        {
            return organize.FindEntity(keyValue);
        }
    }
}
