using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.Common;
using PLKJDS.Common.Enums;

namespace PLKJDS.BLL
{
    public class AuthorizeButtonApp
    {
        IAuthorizeRepository authorizeButtonApp = new AuthorizeRepository();

        public List<Authorize> GetButtonListByAuthList(List<Authorize> AuthorizeList)
        {
            List<Authorize> buttonList = new List<Authorize>();
            foreach (var auth in AuthorizeList)
            {
                var temp = GetAuthorizeButtonList(null,auth.ID,"");
                buttonList.AddRange(temp);
            }
            return buttonList;
        }

        //public List<Authorize> GetAuthorizeByPid(string pid, string accountTypeID)
        //{
        //    var e = ExtLinq.True<Authorize>();
        //    e = e.And(x => x.PID == pid);
        //    e = e.And(x => x.AccountTypeID == accountTypeID);
        //    e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
        //    var list = authorizeApp.IQueryable(e).ToList();
        //    return list;
        //}
        public List<Authorize> GetAuthorizeButtonList(Pagination pagination,string authorizeID,string keyword)
        {
            var e = ExtLinq.True<Authorize>();
            //e = e.And(x => x.PID == pid);
            //e = e.And(x => x.AccountTypeID == accountTypeID);
            e = e.And(x => x.PID == authorizeID);
            e = e.And(x => x.AuthorizeType == ((int)AuthorizeType.Button).ToString());
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            List<Authorize> list =null;
            if(pagination!=null)
            {
                if (pagination.sord == "asc")
                {
                    if (pagination.sidx == "AuthorizeName")
                    {
                        list = authorizeButtonApp.IQueryable(e).OrderBy(x => x.AuthorizeName).ToList();
                    }
                    else if (pagination.sidx == "SortCode")
                    {
                        list = authorizeButtonApp.IQueryable(e).OrderBy(x => x.SortCode).ToList();
                    }
                    else if (pagination.sidx == "Split")
                    {
                        list = authorizeButtonApp.IQueryable(e).OrderBy(x => x.Split).ToList();
                    }
                    else//IsPublic
                    {
                        list = authorizeButtonApp.IQueryable(e).OrderBy(x => x.IsPublic).ToList();
                    }

                }
                else
                {
                    if (pagination.sidx == "AuthorizeName")
                    {
                        list = authorizeButtonApp.IQueryable(e).OrderByDescending(x => x.AuthorizeName).ToList();
                    }
                    else if (pagination.sidx == "SortCode")
                    {
                        list = authorizeButtonApp.IQueryable(e).OrderByDescending(x => x.SortCode).ToList();
                    }
                    else if (pagination.sidx == "Split")
                    {
                        list = authorizeButtonApp.IQueryable(e).OrderByDescending(x => x.Split).ToList();
                    }
                    else//IsPublic
                    {
                        list = authorizeButtonApp.IQueryable(e).OrderByDescending(x => x.IsPublic).ToList();
                    }
                    //list = authorizeButtonApp.IQueryable(e).OrderByDescending(x => x.SortCode).ToList();
                }
            }else
            {
                list = authorizeButtonApp.IQueryable(e).OrderBy(x => x.SortCode).ToList();
            }
            
            
            if(keyword!=null&& keyword != "")
            {
                list = list.Where(x => x.AuthorizeName.Contains(keyword)).ToList();
            }
            
            return list;
        }


        public int AddAuthorizeButton(Authorize authorize)
        {
            authorize.Create();
            var ret = authorizeButtonApp.Insert(authorize);
            return ret;
        }

        public int ModifyAuthorizeButton(Authorize authorize, string keyValue)
        {
            var entity = authorizeButtonApp.FindEntity(keyValue);
            EntityCopyHelper.CopyEnity(entity, authorize);
            var ret = authorizeButtonApp.Update(entity);
            return ret;
        }

        public int DeleteAuthorizeButton(Authorize authorize)
        {
            var entity = authorizeButtonApp.FindEntity(authorize.ID);
            entity.Remove();
            var ret = authorizeButtonApp.Update(entity);
            return ret;
        }

        public Authorize GetForm(Authorize authorize)
        {
            var entity = authorizeButtonApp.FindEntity(authorize.ID);
            return entity;
        }
    }
}
