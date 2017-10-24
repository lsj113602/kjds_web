
namespace PLKJDS.Entity
{

    // TrainInfo
	// by bobomouse
    public partial class TrainInfo : EntityBaseModel<TrainInfo> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 发布人
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 图片编号
        ///</summary>
        public string PhotoID { get; set; } // PhotoID (length: 512)

        ///<summary>
        /// 举办单位
        ///</summary>
        public string Host { get; set; } // Host (length: 128)

        ///<summary>
        /// 活动地点
        ///</summary>
        public string Address { get; set; } // Address (length: 128)

        ///<summary>
        /// 培训信息详情
        ///</summary>
        public string Content { get; set; } // Content (length: 2147483647)

        ///<summary>
        /// 标题
        ///</summary>
        public string TrainTitle { get; set; } // TrainTitle (length: 128)

        ///<summary>
        /// 状态（0 报名中，1已结束）
        ///</summary>
        public string StatusCode { get; set; } // StatusCode (length: 64)

        ///<summary>
        /// 参加人数上限
        ///</summary>
        public int? LimitNumber { get; set; } // LimitNumber

        ///<summary>
        /// 已经参加人数
        ///</summary>
        public int? PartNumber { get; set; } // PartNumber

        ///<summary>
        /// 发布时间
        ///</summary>
        public System.DateTime? PublishTime { get; set; } // PublishTime

        ///<summary>
        /// 开始时间
        ///</summary>
        public System.DateTime? StartTime { get; set; } // StartTime

        ///<summary>
        /// 结束时间
        ///</summary>
        public System.DateTime? EndTime { get; set; } // EndTime

        ///<summary>
        /// 活动开始报名时间
        ///</summary>
        public System.DateTime? ApplySTime { get; set; } // ApplySTime

        ///<summary>
        /// 活动结束报名时间
        ///</summary>
        public System.DateTime? ApplyETime { get; set; } // ApplyETime

        ///<summary>
        /// 总结
        ///</summary>
        public string Summary { get; set; } // Summary (length: 2147483647)

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

        public TrainInfo()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

