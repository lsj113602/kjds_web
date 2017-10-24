
namespace PLKJDS.Entity
{

    // TrainParter
	// by bobomouse
    public partial class TrainParter : EntityBaseModel<TrainParter> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 培训信息ID
        ///</summary>
        public string TrainID { get; set; } // TrainID (length: 64)

        ///<summary>
        /// 参加培训用户ID
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 是否取消（取消true 未取消false）
        ///</summary>
        public bool? IsCancel { get; set; } // IsCancel

        ///<summary>
        /// 参加时间
        ///</summary>
        public System.DateTime? PartTime { get; set; } // PartTime

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

        public TrainParter()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

