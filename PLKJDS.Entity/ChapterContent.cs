
namespace PLKJDS.Entity
{

    // ChapterContent
	// by bobomouse
    public partial class ChapterContent : EntityBaseModel<ChapterContent> //,ICreationAudited, IDeleteAudited, IModificationAudited
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
        /// 文件ID
        ///</summary>
        public string FileID { get; set; } // FileID (length: 64)

        ///<summary>
        /// 内容分类ID
        ///</summary>
        public string TypeID { get; set; } // TypeID (length: 64)

        ///<summary>
        /// 试题数量
        ///</summary>
        public int? TestQuestionNum { get; set; } // TestQuestionNum

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

        public ChapterContent()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

