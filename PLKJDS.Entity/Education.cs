
namespace PLKJDS.Entity
{

    // Education
	// by bobomouse
    public partial class Education : EntityBaseModel<Education> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 用户ID
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 学校名称
        ///</summary>
        public string SchoolName { get; set; } // SchoolName (length: 128)

        ///<summary>
        /// 学院
        ///</summary>
        public string Academy { get; set; } // Academy (length: 64)

        ///<summary>
        /// 专业
        ///</summary>
        public string Professional { get; set; } // Professional (length: 64)

        ///<summary>
        /// 开始时间
        ///</summary>
        public System.DateTime? StartTime { get; set; } // StartTime

        ///<summary>
        /// 结束时间
        ///</summary>
        public System.DateTime? EndTime { get; set; } // EndTime

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

        public Education()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

