
namespace PLKJDS.Entity
{

    // Course
	// by bobomouse
    public partial class Course : EntityBaseModel<Course> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 课程级别ID
        ///</summary>
        public string LevelID { get; set; } // LevelID (length: 64)

        ///<summary>
        /// 图片ID
        ///</summary>
        public string PhotoID { get; set; } // PhotoID (length: 64)

        ///<summary>
        /// 课程大纲名称
        ///</summary>
        public string CourseName { get; set; } // CourseName (length: 64)

        ///<summary>
        /// 制定时间
        ///</summary>
        public System.DateTime? SetTime { get; set; } // SetTime

        ///<summary>
        /// 状态 0即将开课1开课中2已结课
        ///</summary>
        public byte? StatusCode { get; set; } // StatusCode

        ///<summary>
        /// 开始时间
        ///</summary>
        public System.DateTime? StartTime { get; set; } // StartTime

        ///<summary>
        /// 结束时间
        ///</summary>
        public System.DateTime? EndTime { get; set; } // EndTime

        ///<summary>
        /// 期数（1，2，3，4）
        ///</summary>
        public int? SerialNum { get; set; } // SerialNum

        ///<summary>
        /// 上一期课程ID 若无则为0
        ///</summary>
        public string PreCourse { get; set; } // PreCourse (length: 64)

        ///<summary>
        /// 是否显示
        ///</summary>
        public bool? IsShow { get; set; } // IsShow

        ///<summary>
        /// 是否有考试
        ///</summary>
        public bool? IsTest { get; set; } // IsTest

        ///<summary>
        /// 课程描述
        ///</summary>
        public string Desc { get; set; } // Desc (length: 2147483647)

        ///<summary>
        /// 课程创始人
        ///</summary>
        public string CreateCourseUserID { get; set; } // CreateCourseUserID (length: 64)

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

        public Course()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

