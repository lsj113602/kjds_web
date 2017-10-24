using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Entity;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Common;


namespace PLKJDS.BLL
{
    public class AccountTypeApp
    {
        IAccountTypeRepository sAccount = new AccountTypeRepository();
        public List<AccountType> GetAccountTypeList(Pagination pagination,string keyword)
        {
            var e = ExtLinq.True<AccountType>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            if(!string.IsNullOrEmpty(keyword))
                e = e.And(x => x.TypeName.Contains(keyword));
            var list = sAccount.FindList(e,pagination).ToList();
            return list;
        }
        

        public int AddAccountType(AccountType accountType)
        {
            accountType.Create();
            var ret = sAccount.Insert(accountType);
            return ret;
        }

        public int ModifyAccountType(AccountType accountType,string keyValue)
        {
            var entity = sAccount.FindEntity(keyValue);
            EntityCopyHelper.CopyEnity(entity, accountType);
            var ret = sAccount.Update(entity);
            return ret;
        }

        public int DeleteAccountType(AccountType accountType)
        {
            var entity = sAccount.FindEntity(accountType.ID);
            entity.Remove();
            var ret = sAccount.Update(entity);
            return ret;
        }

        public AccountType GetForm(AccountType account)
        {
            var entity = sAccount.FindEntity(account.ID);
            return entity;
        }

        public List<AccountType> GetAccountTypeList()
         {
            var e = ExtLinq.True<AccountType>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            var list = sAccount.IQueryable(e).ToList();
            return list;
        }
    }
}
