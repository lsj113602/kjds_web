
namespace PLKJDS.Entity
{

    // File
	// by bobomouse
    public partial class File : EntityBaseModel<File> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 用户编号
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 文件类型ID
        ///</summary>
        public string TypeID { get; set; } // TypeID (length: 64)

        ///<summary>
        /// 文件名
        ///</summary>
        public string FileName { get; set; } // FileName (length: 256)

        ///<summary>
        /// 原文件名
        ///</summary>
        public string OName { get; set; } // OName (length: 256)

        ///<summary>
        /// 文件扩展名
        ///</summary>
        public string FileExt { get; set; } // FileExt (length: 16)

        ///<summary>
        /// 文件路径
        ///</summary>
        public string FilePath { get; set; } // FilePath (length: 256)

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

        public File()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

