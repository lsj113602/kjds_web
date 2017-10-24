
namespace PLKJDS.Entity
{

    // ResumeConfig
	// by bobomouse
    public partial class ResumeConfig : EntityBaseModel<ResumeConfig> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 用户ID
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 类型（radio， check，customer）
        ///</summary>
        public string TypeID { get; set; } // TypeID (length: 64)

        ///<summary>
        /// 配置名称
        ///</summary>
        public string ConfigName { get; set; } // ConfigName (length: 64)

        ///<summary>
        /// 选择项值（0个人信息（附照片）1 无照片）
        ///</summary>
        public byte? Radio { get; set; } // Radio

        ///<summary>
        /// 是否选择了(true 已选择 false 未选择)
        ///</summary>
        public bool? IsCheck { get; set; } // IsCheck

        ///<summary>
        /// 自定义ID
        ///</summary>
        public string CustomerID { get; set; } // CustomerID (length: 64)

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

        public ResumeConfig()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

