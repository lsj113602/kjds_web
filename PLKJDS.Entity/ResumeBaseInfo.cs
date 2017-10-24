
namespace PLKJDS.Entity
{

    // ResumeBaseInfo
	// by bobomouse
    public partial class ResumeBaseInfo : EntityBaseModel<ResumeBaseInfo> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 用户编号
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 真实姓名
        ///</summary>
        public string TrueName { get; set; } // TrueName (length: 64)

        ///<summary>
        /// 性别
        ///</summary>
        public string Gender { get; set; } // Gender (length: 4)

        ///<summary>
        /// 出生年月
        ///</summary>
        public System.DateTime? BirthDate { get; set; } // BirthDate

        public int? Age { get; set; }

        ///<summary>
        /// 教育背景
        ///</summary>
        public string Education { get; set; } // Education (length: 64)

        ///<summary>
        /// 居住地
        ///</summary>
        public string Address { get; set; } // Address (length: 64)

        ///<summary>
        /// 手机
        ///</summary>
        public string Phone { get; set; } // Phone (length: 16)

        ///<summary>
        /// 邮箱
        ///</summary>
        public string Email { get; set; } // Email (length: 64)

        ///<summary>
        /// 专业技能
        ///</summary>
        public string Skill { get; set; } // Skill (length: 2147483647)

        ///<summary>
        /// 自我评价
        ///</summary>
        public string SelfVal { get; set; } // SelfVal (length: 2147483647)

        ///<summary>
        /// 头像ID
        ///</summary>
        public string HeadPicID { get; set; } // HeadPicID (length: 64)

        ///<summary>
        /// 创建用户
        ///</summary>
        public string CreatorUserId { get; set; } // CreatorUserId (length: 64)

        ///<summary>
        /// 创建时间
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

        public ResumeBaseInfo()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

