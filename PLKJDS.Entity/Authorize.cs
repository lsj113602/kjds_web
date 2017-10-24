
namespace PLKJDS.Entity
{

    // Authorize
	// by bobomouse
    public partial class Authorize : EntityBaseModel<Authorize> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 角色ID
        ///</summary>
        public string RoleID { get; set; } // RoleID (length: 64)

        ///<summary>
        /// 类型ID 区分是哪种账号类型权限
        ///</summary>
        public string AccountTypeID { get; set; } // AccountTypeID (length: 64)

        ///<summary>
        /// 权限名称
        ///</summary>
        public string AuthorizeName { get; set; } // AuthorizeName (length: 64)

        ///<summary>
        /// 权限类型（1 菜单 2 按钮）
        ///</summary>
        public string AuthorizeType { get; set; } // AuthorizeType (length: 64)

        ///<summary>
        /// 编码
        ///</summary>
        public string EnCode { get; set; } // EnCode (length: 64)

        ///<summary>
        /// 父级权限
        ///</summary>
        public string PID { get; set; } // PID (length: 64)

        ///<summary>
        /// 图标
        ///</summary>
        public string Icon { get; set; } // Icon (length: 64)

        ///<summary>
        /// 连接地址
        ///</summary>
        public string UrlAddress { get; set; } // UrlAddress (length: 512)

        ///<summary>
        /// 目标
        ///</summary>
        public string Target { get; set; } // Target (length: 64)

        ///<summary>
        /// 是否为菜单 true 菜单
        ///</summary>
        public bool? IsMenu { get; set; } // IsMenu

        ///<summary>
        /// 是否展开 true 展开
        ///</summary>
        public bool? IsExpand { get; set; } // IsExpand

        ///<summary>
        /// 是否公开
        ///</summary>
        public bool? IsPublic { get; set; } // IsPublic

        ///<summary>
        /// 是否允许编辑
        ///</summary>
        public bool? AllowEdit { get; set; } // AllowEdit

        ///<summary>
        /// 排序
        ///</summary>
        public int? SortCode { get; set; } // SortCode

        ///<summary>
        /// JS事件
        ///</summary>
        public string JsEvent { get; set; } // JsEvent (length: 64)

        ///<summary>
        /// 分割线
        ///</summary>
        public bool? Split { get; set; } // Split

        ///<summary>
        /// 备注
        ///</summary>
        public string ReMark { get; set; } // ReMark (length: 512)

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

        public Authorize()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

