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
using PLKJDS.Entity.ViewModel;

namespace PLKJDS.BLL
{
    public class UserApp
    {
        IUserRepository userService = new UserRepository();
        IUserDataRepository userDataService = new UserDataRepository();

        public List<User> GetList(Pagination pagination, string keyword)
        {
            var e = ExtLinq.True<User>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.UserName.Contains(keyword));
                e = e.Or(x => x.Phone.Contains(keyword));
                e = e.Or(x => x.TrueName.Contains(keyword));
            }

            return userService.FindList(e, pagination).ToList();
        }
        public List<User> GetList(Pagination pagination, string keyword, string OrgID)
        {
            var e = ExtLinq.True<User>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            e = e.And(x => x.OrgID == OrgID);
            if (!string.IsNullOrEmpty(keyword))
            {
                e = e.And(x => x.UserName.Contains(keyword));
                e = e.Or(x => x.Phone.Contains(keyword));
                e = e.Or(x => x.TrueName.Contains(keyword));
            }

            return userService.FindList(e, pagination).ToList();
        }

        public User GetForm(string keyValue)
        {
            return userService.FindEntity(keyValue);
        }

        public User GetForm(string keyValue, string OrgId)
        {
            var e = ExtLinq.True<User>();
            e = e.And(x => x.ID == keyValue);
            e = e.And(x => x.OrgID == OrgId);
            var entity = userService.FindEntity(e);
            return entity;
        }

        public int AddUser(User user)
        {
            var e = ExtLinq.True<User>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            if (!string.IsNullOrEmpty(user.UserName))
            {
                e = e.And(x => x.UserName == user.UserName);
            }
            if (!string.IsNullOrEmpty(user.Phone))
            {
                e = e.Or(x => x.Phone == user.Phone);
            }
            var sum = userService.IQueryable(e).Count();
            if (sum != 0)
            {
                return 0;
            }

            user.Create();
            var ret = userService.Insert(user);
            return ret;
        }

        public User CheckLogin(string username, string password)
        {
            User userEntity = userService.FindEntity(t => t.UserName == username);
            if (userEntity != null)
            {
                if (userEntity.IsLogin == true)
                {
                    User userLogOnEntity = GetForm(userEntity.ID);
                    string dbPassword = Md5.md5(DESEncrypt.Encrypt(password.ToLower(), userLogOnEntity.SecretKey).ToLower(), 32).ToLower();
                    if (dbPassword == userLogOnEntity.Passsword)
                    {
                        return userEntity;
                    }
                    else
                    {
                        throw new Exception("密码不正确，请重新输入");
                    }
                }
                else
                {
                    throw new Exception("该账号没有后台登录权限");
                }
            }
            else
            {
                throw new Exception("账户不存在，请重新输入");
            }
        }

        public List<User> findUserById(string userId)
        {
            var e = ExtLinq.True<User>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            e = e.And(x => x.ID == userId);
            e = e.Or(x => x.TrueName== userId);
            return userService.IQueryable(e).ToList() ;
        }

        public List<UserListModel> FindUserListModel()
        {
            List<User>userList=userService.IQueryable().ToList();
            List<UserListModel> list = new List<UserListModel>();
            foreach (User user in userList)
            {
                if(user.TrueName==""|| user.TrueName == null) {
                    continue;
                }
                UserListModel usermodel = new UserListModel();
                usermodel.id = user.ID;
                usermodel.title = user.TrueName;
                list.Add(usermodel);
            }
            return list;
        }

        public int ModifyUser(User user, string keyvalue)
        {
            user.Modify(keyvalue);
            var ret = userService.Update(user);
            return ret;
        }

        public int DeleteUser(string keyvalue)
        {
            User user = new User();
            user.ID = keyvalue;
            user.Remove();
            var ret = userService.Update(user);
            return ret;
        }
        public int DeleteUser(string keyvalue, string OrgID)
        {
            var entity = this.GetForm(keyvalue, OrgID);
            var ret = -1;
            if (entity != null)
            {
                entity.Remove();
                ret = userService.Update(entity);
            }
            return ret;

        }
        public int RevisePassword(string userPassword, string keyValue)
        {
            User user = new User();
            user.ID = keyValue;
            user.SecretKey = Md5.md5(CommonUtility.CreateNo(), 16).ToLower();
            user.Passsword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userPassword, 32).ToLower(), user.SecretKey).ToLower(), 32).ToLower();
            var ret = userService.Update(user);
            return ret;
        }

        public int RevisePassword(string userPassword, string keyValue, string OrgID)
        {
            User user = this.GetForm(keyValue, OrgID);
            var ret = -1;
            if (user != null)
            {
                user.SecretKey = Md5.md5(CommonUtility.CreateNo(), 16).ToLower();
                user.Passsword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(userPassword, 32).ToLower(), user.SecretKey).ToLower(), 32).ToLower();
                ret = userService.Update(user);
            }
            return ret;
        }

        public object GetApprove(string keyValue)
        {
            var userData = userDataService.FindEntity(keyValue);

            return null;
        }

        public int Approve(string keyValue, string typeID)
        {
            //TestData
            //private string UserID = OperatorProvider.Provider.GetCurrent().UserId;
            string UserID = "8abacd53-f43b-4d28-b8da-ebc82a5df624";
            User user = new User();
            if (typeID == "1")
            {
                user.ID = keyValue;
                user.AgreeCode = "1";
                user.AgreeTime = DateTime.Now;
                user.IsLogin = true;
                user.AgreeUserID = UserID;
            }
            else
            {
                user.AgreeCode = "2";
                user.AgreeTime = DateTime.Now;
                user.AgreeUserID = UserID;
                user.IsLogin = false;
                user.ID = keyValue;
            }
            return userService.Update(user);
        }

        public bool CheckUserName(string username)
        {
            bool flag = false;
            var user = userService.IQueryable().Where(x => x.UserName == username&&(x.DeleteMark==null?false:x.DeleteMark)!=true).FirstOrDefault();
            if (user != null)
            {
                flag = true;//该用户名已被注册;
            }
            return flag;
        }
    }
}
