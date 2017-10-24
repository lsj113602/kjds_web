
namespace PLKJDS.Entity
{

    // ExaminationPaper
	// by bobomouse
    public partial class ExaminationPaper : EntityBaseModel<ExaminationPaper> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 课程ID
        ///</summary>
        public string CourseID { get; set; } // CourseID (length: 64)

        ///<summary>
        /// 满分
        ///</summary>
        public int? FullMark { get; set; } // FullMark

        ///<summary>
        /// 通过分数
        ///</summary>
        public int? PassMark { get; set; } // PassMark

        ///<summary>
        /// 题目总数
        ///</summary>
        public int? QuesetionNum { get; set; } // QuesetionNum

        ///<summary>
        /// 单选数量
        ///</summary>
        public int? SelectNum { get; set; } // SelectNum

        ///<summary>
        /// 选择分数
        ///</summary>
        public string SelectScore { get; set; } // SelectScore (length: 64)

        ///<summary>
        /// 判断体数量
        ///</summary>
        public int? TFNum { get; set; } // TFNum

        ///<summary>
        /// 判断题分数
        ///</summary>
        public string TFScore { get; set; } // TFScore (length: 64)

        ///<summary>
        /// 状态（0待审核1审核通过2审核不通过3停用）
        ///</summary>
        public string StatusCode { get; set; } // StatusCode (length: 64)

        ///<summary>
        /// 制定人ID
        ///</summary>
        public string MakingUserID { get; set; } // MakingUserID (length: 64)

        ///<summary>
        /// 审核人ID
        ///</summary>
        public string CheckUserId { get; set; } // CheckUserId (length: 64)

        ///<summary>
        /// 审核人时间
        ///</summary>
        public System.DateTime? CheckTime { get; set; } // CheckTime

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

        public ExaminationPaper()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

