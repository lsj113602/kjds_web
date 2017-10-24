
namespace PLKJDS.Entity
{

    // CourseParter
	// by bobomouse
    public partial class CourseParter : EntityBaseModel<CourseParter> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 课程ID
        ///</summary>
        public string CourseID { get; set; } // CourseID (length: 64)

        ///<summary>
        /// 参加课程用户ID
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 是否取消（取消true 未取消false）
        ///</summary>
        public bool? IsCancel { get; set; } // IsCancel

        ///<summary>
        /// 是否完成（true完成了）
        ///</summary>
        public bool? IsFinish { get; set; } // IsFinish

        ///<summary>
        /// s是否参加了考试（true参加）
        ///</summary>
        public bool? IsTest { get; set; } // IsTest

        ///<summary>
        /// 考试时间
        ///</summary>
        public System.DateTime? TestTime { get; set; } // TestTime

        ///<summary>
        /// 参加时间
        ///</summary>
        public System.DateTime? PartTime { get; set; } // PartTime

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

        public CourseParter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

