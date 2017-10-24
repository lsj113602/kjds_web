
namespace PLKJDS.Entity
{

    // EmployPosition
	// by bobomouse
    public partial class EmployPosition : EntityBaseModel<EmployPosition> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 岗位名称
        ///</summary>
        public string PosName { get; set; } // PosName (length: 64)

        ///<summary>
        /// 岗位编码
        ///</summary>
        public string EnCode { get; set; } // EnCode (length: 64)

        ///<summary>
        /// 排序
        ///</summary>
        public int? SortCode { get; set; } // SortCode

        ///<summary>
        /// 父级
        ///</summary>
        public string PID { get; set; } // PID (length: 64)

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

        public EmployPosition()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

