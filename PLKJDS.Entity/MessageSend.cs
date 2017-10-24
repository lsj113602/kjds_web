
namespace PLKJDS.Entity
{

    // MessageSend
	// by bobomouse
    public partial class MessageSend : EntityBaseModel<MessageSend> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 发送用户编号
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 标签
        ///</summary>
        public string MessageType { get; set; } // MessageType (length: 64)

        ///<summary>
        /// 标题
        ///</summary>
        public string Title { get; set; } // Title (length: 64)

        ///<summary>
        /// 内容
        ///</summary>
        public string Content { get; set; } // Content (length: 256)

        ///<summary>
        /// 发送时间
        ///</summary>
        public System.DateTime? SendTime { get; set; } // SendTime

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

        public MessageSend()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

