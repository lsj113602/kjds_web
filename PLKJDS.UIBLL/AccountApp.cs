using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.Common;
using PLKJDS.UIEntity.UI;
using PLKJDS.Data;
using PLKJDS.Common.Enums;
namespace PLKJDS.UIBLL
{

    public class AccountApp
    {
        private IOrganizeRepository organizeApp = new OrganizeRepository();
        private IAccountTypeRepository accountApp = new AccountTypeRepository();
        private IUserRepository userApp = new UserRepository();
        private IUserDataRepository userDataApp = new UserDataRepository();
        private IRepositoryBase repositoryBase = new RepositoryBase();
        private IRoleRepository roleApp = new RoleRepository();
        public List<Organize> GetSchoolList()
        {
            string school = Configs.GetValue("School");
            //Get 学校ID
            var f = ExtLinq.True<AccountType>();
            f = f.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            f = f.And(x => x.TypeName.Trim() == school);
            var accountType = accountApp.FindEntity(f);
            if (accountType == null)
            {
                return null;
            }
            var e = ExtLinq.True<Organize>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            e = e.And(x => x.OrgType == accountType.ID);
            var orgList = organizeApp.IQueryable(e).ToList();
            return orgList;
        }


        public int AddUser(RegisterModel register)
        {
            User userModel = new User();
            UserData userDataModel = new UserData();
            //init User
            userModel.UserName = register.UserName;
            //user.SecretKey = Md5.md5(CommonUtility.CreateNo(), 16).ToLower();
            //user.Passsword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(user.Passsword, 32).ToLower(), user.SecretKey).ToLower(), 32).ToLower();
            userModel.SecretKey = Md5.md5(CommonUtility.CreateNo(), 16).ToLower();
            userModel.Passsword = Md5.md5(DESEncrypt.Encrypt(Md5.md5(register.Password, 32).ToLower(), userModel.SecretKey).ToLower(), 32).ToLower(); ;
            userModel.OrgID = register.OrgID;
            userModel.StudentID = register.StudentID;
            userModel.RoleID = GetRoleStudent();
            userModel.AgreeCode = "1";//审核状态，此处默认已审核通过
            userModel.IsLogin = false;//是否允许登录，此此处默认允许登录
            userModel.IsEnable = true;
            userModel.DeleteMark = false;
            //default unAgree
           // userModel.AgreeCode = UserAgreeCode.UnAgree.GetEnumCode();
            userModel.Create();
            //init UserData
            userDataModel.UserID = userModel.ID;
            userDataModel.FileID = register.PicUrl;
            userDataModel.Create();
            
            var ret = -1;
            using (var db = repositoryBase.BeginTrans())
            {
                db.Insert(userModel);
                db.Insert(userDataModel);
                ret = db.Commit();
            }
            return ret == 2 ? 1 : 0;
        }


        private string GetRoleStudent()
        {
            var roleName = Configs.GetValue("Student");
            var e = ExtLinq.True<Role>();
            e = e.And(x => (x.DeleteMark == null ? false : x.DeleteMark) != true);
            e = e.And(x => x.RoleName.Trim() == roleName);
            var role = roleApp.FindEntity(e);
            if (role == null)
            {
                return string.Empty;
            }
            return role.ID;
        }


        public User CheckLogin(LoginModel login)
        {
            User userEntity = userApp.FindEntity(t => t.UserName == login.UserName&&(t.DeleteMark==null?false:t.DeleteMark)!=true);
            if (userEntity != null)
            {
                    string dbPassword = Md5.md5(DESEncrypt.Encrypt(login.Password.ToLower(), userEntity.SecretKey).ToLower(), 32).ToLower();
                    if (dbPassword == userEntity.Passsword)
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
                throw new Exception("账户不存在，请重新输入");
            }
        }

        public bool CheckUserName(string username)
        {
            bool flag=false;
            var user = userApp.IQueryable().Where(x => x.UserName == username).FirstOrDefault();
            var model = userApp.FindEntity(x => x.UserName == username);
            if(user!=null)
            {
                flag = true;//该用户名已被注册;
            }
            return flag;
        }
    }
}
