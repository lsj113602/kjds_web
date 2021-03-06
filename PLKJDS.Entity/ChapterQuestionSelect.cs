
namespace PLKJDS.Entity
{

    // ChapterQuestionSelect
	// by bobomouse
    public partial class ChapterQuestionSelect : EntityBaseModel<ChapterQuestionSelect> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 课程ID
        ///</summary>
        public string CourserID { get; set; } // CourserID (length: 64)

        ///<summary>
        /// 章节ID
        ///</summary>
        public string ChapterID { get; set; } // ChapterID (length: 64)

        ///<summary>
        /// 题目类型
        ///</summary>
        public string TypeID { get; set; } // TypeID (length: 64)

        ///<summary>
        /// 题目题干
        ///</summary>
        public string QName { get; set; } // QName (length: 64)

        ///<summary>
        /// 答案
        ///</summary>
        public string Answer { get; set; } // Answer (length: 4)
        public string SelectA { get; set; } // SelectA (length: 64)
        public string SelectB { get; set; } // SelectB (length: 64)
        public string SelectC { get; set; } // SelectC (length: 64)
        public string SelectD { get; set; } // SelectD (length: 64)

        ///<summary>
        /// 分数
        ///</summary>
        public int? Score { get; set; } // Score

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

        public ChapterQuestionSelect()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

