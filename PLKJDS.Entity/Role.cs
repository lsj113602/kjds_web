
namespace PLKJDS.Entity
{

    // Role
	// by bobomouse
    public partial class Role : EntityBaseModel<Role> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 机构编号
        ///</summary>
        public string OrgID { get; set; } // OrgID (length: 64)

        ///<summary>
        /// 类型ID
        ///</summary>
        public string AccountTypeID { get; set; } // AccountTypeID (length: 64)

        ///<summary>
        /// 角色名称
        ///</summary>
        public string RoleName { get; set; } // RoleName (length: 64)

        ///<summary>
        /// 角色编码
        ///</summary>
        public string RoleCode { get; set; } // RoleCode (length: 128)

        ///<summary>
        /// 备注
        ///</summary>
        public string Remark { get; set; } // Remark (length: 256)

        ///<summary>
        /// 排序
        ///</summary>
        public int? SortCode { get; set; } // SortCode

        ///<summary>
        /// 是否可编辑（true 可编辑false不可编辑）
        ///</summary>
        public bool? IsEdit { get; set; } // IsEdit

        ///<summary>
        /// 是否可删除（true可删除）
        ///</summary>
        public bool? IsDelete { get; set; } // IsDelete

        ///<summary>
        /// 是否有效（true有效
        ///</summary>
        public bool? IsEnable { get; set; } // IsEnable

        ///<summary>
        /// 0 学生端1 教师端 2企业端
        ///</summary>
        public string AppStyle { get; set; } // AppStyle (length: 64)

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

        public Role()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

