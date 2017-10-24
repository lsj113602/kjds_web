
namespace PLKJDS.Entity
{

    // User
	// by bobomouse
    public partial class User : EntityBaseModel<User> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 账号类型ID
        ///</summary>
        public string AccountTypeID { get; set; } // AccountTypeID (length: 64)

        ///<summary>
        /// 角色编号
        ///</summary>
        public string RoleID { get; set; } // RoleID (length: 64)

        ///<summary>
        /// 用户名
        ///</summary>
        public string UserName { get; set; } // UserName (length: 64)

        ///<summary>
        /// 密码
        ///</summary>
        public string Passsword { get; set; } // Passsword (length: 128)

        ///<summary>
        /// 秘钥
        ///</summary>
        public string SecretKey { get; set; } // SecretKey (length: 64)

        ///<summary>
        /// 性别 0 男1 女
        ///</summary>
        public string Gender { get; set; } // Gender (length: 64)

        ///<summary>
        /// 昵称
        ///</summary>
        public string NickName { get; set; } // NickName (length: 128)

        ///<summary>
        /// 头像ID
        ///</summary>
        public string LogoID { get; set; } // LogoID (length: 64)

        ///<summary>
        /// 邮箱
        ///</summary>
        public string EMail { get; set; } // EMail (length: 128)

        ///<summary>
        /// 是否绑定邮箱（true已经绑定false未绑定）
        ///</summary>
        public bool? IsBindEmail { get; set; } // IsBindEmail

        ///<summary>
        /// 绑定Email时间
        ///</summary>
        public System.DateTime? BindEmailTime { get; set; } // BindEmailTime

        ///<summary>
        /// 真实姓名
        ///</summary>
        public string TrueName { get; set; } // TrueName (length: 64)

        ///<summary>
        /// 联系电话
        ///</summary>
        public string Phone { get; set; } // Phone (length: 16)

        ///<summary>
        /// 是否绑定手机号码（true已经绑定false未绑定）
        ///</summary>
        public bool? IsBindPhone { get; set; } // IsBindPhone

        ///<summary>
        /// 审批状态（1通过2未通过 0未审批）
        ///</summary>
        public string AgreeCode { get; set; } // AgreeCode (length: 64)

        ///<summary>
        /// 审批时间
        ///</summary>
        public System.DateTime? AgreeTime { get; set; } // AgreeTime

        ///<summary>
        /// 审批人
        ///</summary>
        public string AgreeUserID { get; set; } // AgreeUserID (length: 64)

        ///<summary>
        /// 是否为机构true机构
        ///</summary>
        public bool? IsOrg { get; set; } // IsOrg

        ///<summary>
        /// 机构ID
        ///</summary>
        public string OrgID { get; set; } // OrgID (length: 64)

        ///<summary>
        /// 是否启用（true 启用 false 停用）
        ///</summary>
        public bool? IsEnable { get; set; } // IsEnable

        ///<summary>
        /// 微信
        ///</summary>
        public string WetChat { get; set; } // WetChat (length: 128)

        ///<summary>
        /// 生日
        ///</summary>
        public System.DateTime? BirthDay { get; set; } // BirthDay

        ///<summary>
        /// 是否允许登录(true允许fals 不允许)
        ///</summary>
        public bool? IsLogin { get; set; } // IsLogin

        ///<summary>
        /// 学号
        ///</summary>
        public string StudentID { get; set; } // StudentID (length: 64)

        ///<summary>
        /// 部门 （系别）
        ///</summary>
        public string DepartMent { get; set; } // DepartMent (length: 64)

        ///<summary>
        /// 备注
        ///</summary>
        public string ReMark { get; set; } // ReMark (length: 256)

        ///<summary>
        /// 创建用户
        ///</summary>
        public string CreatorUserId { get; set; } // CreatorUserId (length: 64)

        ///<summary>
        /// 创建时间（注册时间）
        ///</summary>
        public System.DateTime? CreatorTime { get; set; } // CreatorTime

        ///<summary>
        /// 最后修改用户
        ///</summary>
        public string LastModifyUserId { get; set; } // LastModifyUserId (length: 64)

        ///<summary>
        /// 最后修改时间
        ///</summary>
        public System.DateTime? LastModifyTime { get; set; } // LastModifyTime

        ///<summary>
        /// 删除标志
        ///</summary>
        public bool? DeleteMark { get; set; } // DeleteMark

        ///<summary>
        /// 删除用户
        ///</summary>
        public string DeleteUserId { get; set; } // DeleteUserId (length: 64)

        ///<summary>
        /// 删除时间
        ///</summary>
        public System.DateTime? DeleteTime { get; set; } // DeleteTime

        public string Province { get; set; }
        public string City { get; set; }
        public string Area { get; set; }

        public User()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

