
namespace PLKJDS.Entity
{

    // ExaminationPaperUser
	// by bobomouse
    public partial class ExaminationPaperUser : EntityBaseModel<ExaminationPaperUser> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 用户考试ID
        ///</summary>
        public string ExaminationUserID { get; set; } // ExaminationUserID (length: 64)

        ///<summary>
        /// 课程ID
        ///</summary>
        public string CourseID { get; set; } // CourseID (length: 64)

        ///<summary>
        /// 题目类型ID
        ///</summary>
        public string TypeID { get; set; } // TypeID (length: 64)

        ///<summary>
        /// 题目ID
        ///</summary>
        public string QuestionID { get; set; } // QuestionID (length: 64)

        ///<summary>
        /// 选择题答案
        ///</summary>
        public string SelectAnswer { get; set; } // SelectAnswer (length: 4)

        ///<summary>
        /// 判断体答案
        ///</summary>
        public bool? TFAnswer { get; set; } // TFAnswer

        ///<summary>
        /// 答案是否正确（true正确false错误）
        ///</summary>
        public bool? IsRight { get; set; } // IsRight

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

        public ExaminationPaperUser()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

