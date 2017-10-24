using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.Common;

namespace PLKJDS.BLL
{
    public class AuthorizeApp
    {
        IAuthorizeRepository authorizeApp = new AuthorizeRepository();

        public List<Authorize> GetAuthorizeByPid(string pid,string accountTypeID)
        {
            var e = ExtLinq.True<Authorize>();
            e = e.And(x => x.PID == pid);
            e = e.And(x => x.AccountTypeID == accountTypeID);
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            var list = authorizeApp.IQueryable(e).ToList();
            return list;
        }

        public List<Authorize> GetAuthorizeList()
        {
            var e = ExtLinq.True<Authorize>();
            //e = e.And(x => x.PID == pid);
            //e = e.And(x => x.AccountTypeID == accountTypeID);
            e = e.And(x => x.AuthorizeType == "1");
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            var list = authorizeApp.IQueryable(e).OrderBy(x => x.SortCode).ToList();
            return list;
        }
        public List<Authorize> GetAuthorizeList(string authorizeType,string accountType)
        {
            var e = ExtLinq.True<Authorize>();
            //e = e.And(x => x.PID == pid);
            e = e.And(x => x.AccountTypeID == accountType);
            e = e.And(x => x.AuthorizeType == authorizeType);
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            var list = authorizeApp.IQueryable(e).OrderBy(x => x.SortCode).ToList();
            return list;
        }

        public int AddAuthorize(Authorize authorize)
        {
            authorize.Create();
            var ret = authorizeApp.Insert(authorize);
            return ret;
        }

        public int ModifyAuthorize(Authorize authorize, string keyValue)
        {
            var entity = authorizeApp.FindEntity(keyValue);
            EntityCopyHelper.CopyEnity(entity, authorize);
            var ret = authorizeApp.Update(entity);
            return ret;
        }

        public int DeleteAuthorize(Authorize authorize)
        {
            var e = ExtLinq.True<Authorize>();
            e = e.And(x => x.PID == authorize.ID);
            if (authorizeApp.IQueryable(e).Count() > 0)
            {
                return 0;
            }
            var entity = authorizeApp.FindEntity(authorize.ID);
            entity.Remove();
            var ret = authorizeApp.Update(entity);
            return ret;
        }

        public Authorize GetForm(Authorize authorize)
        {
            var entity = authorizeApp.FindEntity(authorize.ID);
            return entity;
        }
    }
}
