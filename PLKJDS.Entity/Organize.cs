
namespace PLKJDS.Entity
{

    // Organize
	// by bobomouse
    public partial class Organize : EntityBaseModel<Organize> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 机构类型
        ///</summary>
        public string OrgType { get; set; } // OrgType (length: 64)

        ///<summary>
        /// 机构性质
        ///</summary>
        public string OrgProp { get; set; } // OrgProp (length: 64)

        ///<summary>
        /// 缩略图
        ///</summary>
        public string LogoID { get; set; } // LogoID (length: 64)

        ///<summary>
        /// 机构名称
        ///</summary>
        public string OrgName { get; set; } // OrgName (length: 64)

        ///<summary>
        /// 机构编码
        ///</summary>
        public string OrgCode { get; set; } // OrgCode (length: 128)

        ///<summary>
        /// 公司人数
        ///</summary>
        public string OrgPeopleNumber { get; set; } // OrgPeopleNumber (length: 64)

        ///<summary>
        /// 机构联系人
        ///</summary>
        public string OrgContact { get; set; } // OrgContact (length: 64)

        ///<summary>
        /// 电话
        ///</summary>
        public string Phone { get; set; } // Phone (length: 64)

        ///<summary>
        /// 机构联系人电话
        ///</summary>
        public string Telphone { get; set; } // Telphone (length: 64)

        ///<summary>
        /// 公司地址
        ///</summary>
        public string Address { get; set; } // Address (length: 256)

        ///<summary>
        /// 微信
        ///</summary>
        public string WeChat { get; set; } // WeChat (length: 128)

        ///<summary>
        /// 邮箱
        ///</summary>
        public string Email { get; set; } // Email (length: 256)

        ///<summary>
        /// 传真
        ///</summary>
        public string Fax { get; set; } // Fax (length: 64)

        ///<summary>
        /// 是否有效true有效
        ///</summary>
        public bool? IsEnable { get; set; } // IsEnable

        ///<summary>
        /// 行业ID
        ///</summary>
        public string IndID { get; set; } // IndID (length: 64)

        ///<summary>
        /// 规模ID
        ///</summary>
        public string ScaleID { get; set; } // ScaleID (length: 64)

        ///<summary>
        /// 官网地址
        ///</summary>
        public string OffSite { get; set; } // OffSite (length: 64)

        ///<summary>
        /// 公司介绍
        ///</summary>
        public string Introduction { get; set; } // Introduction (length: 2147483647)

        ///<summary>
        /// 备注
        ///</summary>
        public string ReMark { get; set; } // ReMark (length: 256)

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

        public Organize()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

