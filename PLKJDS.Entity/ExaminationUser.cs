
namespace PLKJDS.Entity
{

    // ExaminationUser
	// by bobomouse
    public partial class ExaminationUser : EntityBaseModel<ExaminationUser> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 课程ID
        ///</summary>
        public string CourseID { get; set; } // CourseID (length: 64)

        ///<summary>
        /// 试卷ID
        ///</summary>
        public string PaperID { get; set; } // PaperID (length: 64)

        ///<summary>
        /// 分数
        ///</summary>
        public int? Mark { get; set; } // Mark

        ///<summary>
        /// 考试时间
        ///</summary>
        public System.DateTime? TestTime { get; set; } // TestTime

        ///<summary>
        /// 交卷时间
        ///</summary>
        public System.DateTime? CommitTime { get; set; } // CommitTime

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

        public ExaminationUser()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

