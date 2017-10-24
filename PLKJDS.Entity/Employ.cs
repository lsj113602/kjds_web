
namespace PLKJDS.Entity
{

    // Employ
	// by bobomouse
    public partial class Employ : EntityBaseModel<Employ> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 类型ID
        ///</summary>
        public string TypeID { get; set; } // TypeID (length: 64)

        ///<summary>
        /// 地区ID
        ///</summary>
        public string AreaID { get; set; } // AreaID (length: 64)

        ///<summary>
        /// 发布信息ID
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 岗位ID
        ///</summary>
        public string PostID { get; set; } // PostID (length: 64)

        ///<summary>
        /// 机构账号ID
        ///</summary>
        public string OrgUserID { get; set; } // OrgUserID (length: 64)

        ///<summary>
        /// 标题（包含职位信息）
        ///</summary>
        public string Title { get; set; } // Title (length: 64)

        ///<summary>
        /// 公司名
        ///</summary>
        public string CompanyName { get; set; } // CompanyName (length: 128)

        ///<summary>
        /// 需求人数
        ///</summary>
        public int? PeopleCount { get; set; } // PeopleCount

        ///<summary>
        /// 发布时间
        ///</summary>
        public System.DateTime? PublishTime { get; set; } // PublishTime

        ///<summary>
        /// 职位诱惑
        ///</summary>
        public string EmployAtract { get; set; } // EmployAtract (length: 64)

        ///<summary>
        /// 岗位要求
        ///</summary>
        public string EmployDesc { get; set; } // EmployDesc (length: 2147483647)

        ///<summary>
        /// 岗位职责
        ///</summary>
        public string JobResp { get; set; } // JobResp (length: 2147483647)

        ///<summary>
        /// 工作地点
        ///</summary>
        public string Address { get; set; } // Address (length: 256)

        ///<summary>
        /// 开始时间
        ///</summary>
        public System.DateTime? StartTime { get; set; } // StartTime

        ///<summary>
        /// 结束时间
        ///</summary>
        public System.DateTime? EndTime { get; set; } // EndTime

        ///<summary>
        /// 薪资
        ///</summary>
        public string Salary { get; set; } // Salary (length: 64)

        ///<summary>
        /// 状态（开始，停止）
        ///</summary>
        public string StatusCode { get; set; } // StatusCode (length: 64)

        ///<summary>
        /// 是否永久有效（true永久有效）
        ///</summary>
        public bool? IsValid { get; set; } // IsValid

        ///<summary>
        /// 工作经验
        ///</summary>
        public string WorkExperience { get; set; } // WorkExperience (length: 64)

        ///<summary>
        /// 学历要求
        ///</summary>
        public string EduRequire { get; set; } // EduRequire (length: 64)

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

        public Employ()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

