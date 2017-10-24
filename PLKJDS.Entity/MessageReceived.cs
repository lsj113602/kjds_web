
namespace PLKJDS.Entity
{

    // MessageReceived
	// by bobomouse
    public partial class MessageReceived : EntityBaseModel<MessageReceived> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 接收用户ID
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 消息ID
        ///</summary>
        public string MessageID { get; set; } // MessageID (length: 64)

        ///<summary>
        /// 是否已读（true已读false未读）
        ///</summary>
        public bool? IsRead { get; set; } // IsRead

        ///<summary>
        /// 接收时间
        ///</summary>
        public System.DateTime? ReceivedTime { get; set; } // ReceivedTime

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

        public MessageReceived()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

