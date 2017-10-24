using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using PLKJDS.Data;
using PLKJDS.UIEntity.UI;
using PLKJDS.Common;
using System.Data.Common;
using System.Configuration;

namespace PLKJDS.UIBLL
{
    public class UserInfoApp
    {
        IRepositoryBase baseRpty = new RepositoryBase();
        IUserRepository userRpty = new UserRepository();
        IOrganizeRepository orgRpty = new OrganizeRepository();

        //获取用户信息
        //id, name，stuNo， school， pastern，sex，birthday，phone，email，（province，city，area）,logo
        public UserInfoModel Get(string id) 
        {
            UserInfoModel model = null;
            var user = userRpty.FindEntity(id);
            if (user != null)
            {
                model = new UserInfoModel()
                {
                    area = user.Area,
                    birthday = user.BirthDay.HasValue ? user.BirthDay.Value.ToString("yyyy-MM-dd") : "",
                    city = user.City,
                    email = user.EMail,
                    id = user.ID,
                    logo = user.LogoID,
                    name = user.TrueName,
                    pastern = user.DepartMent,
                    phone = user.Phone,
                    province = user.Province,
                    school = orgRpty.IQueryable(x => x.ID == user.OrgID).Select(x => x.OrgName).FirstOrDefault(),
                    sex = user.Gender,
                    stuNo = user.StudentID
                };
            }
            return model;
        }

        //修改用户信息
        //pastern,sex,birthday,phone,email,province,city,area
        public bool ModifyUserInfo(ModifyUserInfoParam param) 
        {
            var user = userRpty.FindEntity(param.id);
            if (user != null)
            {
                user.DepartMent = param.pastern;
                user.Gender = param.sex;
                user.BirthDay = param.birthday;
                user.Phone = param.phone;
                user.EMail = param.email;
                user.Province = param.province;
                user.City = param.city;
                user.Area = param.area;
                userRpty.Update(user);
                return true;
            }
            return false;
        }

        //修改用户头像
        //logo
        public bool ModifyUserLogo(ModifyUserLogoParam param) 
        {
            var user = userRpty.FindEntity(param.id);
            if (user != null)
            {
                user.LogoID = param.logo;
                userRpty.Update(user);
                return true;
            }
            return false;
        }

        //修改用户密码
        //oldPwd, newPwd
        public bool ModifyUserPwd(ModifyUserPwdParam param, out string msg)
        {
            msg = null;
            var user = userRpty.FindEntity(param.id);
            if (user != null)
            {
                string dbPassword = Md5.md5(DESEncrypt.Encrypt(param.oldPwd.ToLower(), user.SecretKey).ToLower(), 32).ToLower();
                if (!string.Equals(user.Passsword, dbPassword))
                {
                    msg = "旧密码不正确，请重新输入!";
                    return false;
                }
                dbPassword = Md5.md5(DESEncrypt.Encrypt(param.newPwd.ToLower(), user.SecretKey).ToLower(), 32).ToLower();
                user.Passsword = dbPassword;
                userRpty.Update(user);
                return true;
            }
            return false;
        }
    }

    public class UserInfoModel 
    {
        public string id { get; set; }
        public string name     {get;set;}
        public string stuNo    {get;set;}
        public string school   {get;set;}
        public string pastern  {get;set;}
        public string sex      {get;set;}
        public string birthday {get;set;}
        public string phone    {get;set;}
        public string email    {get;set;}
        public string province {get;set;}
        public string city     {get;set;}
        public string area     {get;set;}
        public string logo     {get;set;}
    }

    public class ModifyUserInfoParam
    {
        public string id { get; set; }
        public string pastern { get; set; }
        public string sex { get; set; }
        public DateTime? birthday { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string area { get; set; }
    }

    public class ModifyUserLogoParam 
    { 
        public string id {get;set;}
        public string logo{get;set;}
    }

    public class ModifyUserPwdParam 
    {
        public string id { get; set; }
        public string oldPwd{get;set;}
        public string newPwd{get;set;}
    }
}
