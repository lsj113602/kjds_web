
namespace PLKJDS.Entity
{

    // EmployPart
	// by bobomouse
    public partial class EmployPart : EntityBaseModel<EmployPart> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 招聘信息ID
        ///</summary>
        public string EmployID { get; set; } // EmployID (length: 64)

        ///<summary>
        /// 参加用户ID
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 发布时间
        ///</summary>
        public System.DateTime? PartTime { get; set; } // PartTime

        ///<summary>
        /// 是否通过招聘（true 通过）
        ///</summary>
        public bool? IsPass { get; set; } // IsPass

        ///<summary>
        /// 评价等级ID
        ///</summary>
        public string LevelID { get; set; } // LevelID (length: 64)

        ///<summary>
        /// 评论
        ///</summary>
        public string Comment { get; set; } // Comment (length: 256)

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

        public EmployPart()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

