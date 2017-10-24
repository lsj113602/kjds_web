
namespace PLKJDS.Entity
{

    // WorkExperience
	// by bobomouse
    public partial class WorkExperience : EntityBaseModel<WorkExperience> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 用户ID
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 公司名
        ///</summary>
        public string CompanyName { get; set; } // CompanyName (length: 128)

        ///<summary>
        /// 职位
        ///</summary>
        public string Position { get; set; } // Position (length: 64)

        ///<summary>
        /// 开始时间
        ///</summary>
        public System.DateTime? StartTime { get; set; } // StartTime

        ///<summary>
        /// 结束时间
        ///</summary>
        public System.DateTime? EndTime { get; set; } // EndTime

        ///<summary>
        /// 工作内容
        ///</summary>
        public string WorkContent { get; set; } // WorkContent (length: 512)

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

        public WorkExperience()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

