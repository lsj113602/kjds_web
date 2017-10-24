
namespace PLKJDS.Entity
{

    // RoleAuthorize
	// by bobomouse
    public partial class RoleAuthorize : EntityBaseModel<RoleAuthorize> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 角色ID
        ///</summary>
        public string RoleID { get; set; } // RoleID (length: 64)

        ///<summary>
        /// 权限ID
        ///</summary>
        public string AuthorizeID { get; set; } // AuthorizeID (length: 64)

        ///<summary>
        /// 对象分类1-角色2-部门-3用户
        ///</summary>
        public string ObjectType { get; set; } // ObjectType (length: 64)

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

        public RoleAuthorize()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

