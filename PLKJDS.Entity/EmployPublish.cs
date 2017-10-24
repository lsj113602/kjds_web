
namespace PLKJDS.Entity
{

    // EmployPublish
	// by bobomouse
    public partial class EmployPublish : EntityBaseModel<EmployPublish> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 招聘信息ID
        ///</summary>
        public string EmployID { get; set; } // EmployID (length: 64)

        ///<summary>
        /// 发布机构用户ID
        ///</summary>
        public string OrgUserID { get; set; } // OrgUserID (length: 64)

        ///<summary>
        /// 接收机构用户ID
        ///</summary>
        public string ROrgUserID { get; set; } // ROrgUserID (length: 64)

        ///<summary>
        /// 发布时间
        ///</summary>
        public System.DateTime? PublishTime { get; set; } // PublishTime

        ///<summary>
        /// 是否推荐
        ///</summary>
        public bool? IsRecommend { get; set; } // IsRecommend

        ///<summary>
        /// 是否审批通过
        ///</summary>
        public bool? IsAgree { get; set; } // IsAgree

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

        public EmployPublish()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

