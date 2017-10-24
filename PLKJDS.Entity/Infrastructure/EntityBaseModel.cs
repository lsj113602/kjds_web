using PLKJDS.Common;
using System;

namespace PLKJDS.Entity
{
    public class EntityBaseModel<TEntity> : EntityModelBaseForReflection
    {
        public void Create()
        {
            var entity = this as ICreationAudited;
            entity.ID = CommonUtility.GuId();
            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            //if (LoginInfo != null)
            //{
            //    entity.CreatorUserId = LoginInfo.UserId; ;
            //}
            entity.CreatorTime = DateTime.Now;
        }
        public void Modify(string keyValue)
        {
            var entity = this as IModificationAudited;
            entity.ID = keyValue;
            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            //if (LoginInfo != null)
            //{
            //    entity.LastModifyUserId = LoginInfo.UserId;
            //}
            entity.LastModifyTime = DateTime.Now;
        }
        public void Remove()
        {
            var entity = this as IDeleteAudited;
            //var LoginInfo = OperatorProvider.Provider.GetCurrent();
            //if (LoginInfo != null)
            //{
            //    entity.DeleteUserId = LoginInfo.UserId;
            //}
            //entity.DeleteTime = DateTime.Now;
            entity.DeleteMark = true;
        }
    }
}
