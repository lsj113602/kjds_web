using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIEntity
{
    public partial class ChapterAndFile 
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)

        ///<summary>
        /// 课程ID
        ///</summary>
        public string CourserID { get; set; } // CourserID (length: 64)

        ///<summary>
        /// 培训资源指定人ID
        ///</summary>
        public string UserID { get; set; } // UserID (length: 64)

        ///<summary>
        /// 章节名称
        ///</summary>
        public string ChapterName { get; set; } // ChapterName (length: 64)


        public string FileID { get; set; }

        public string VideoID{get;set;}

        ///<summary>
        /// 制定时间
        ///</summary>
        public System.DateTime? SetTime { get; set; } // SetTime

        ///<summary>
        /// 顺序值
        ///</summary>
        public int? SequenceID { get; set; } // SequenceID

        ///<summary>
        /// 父级ID （默认0）
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
    }
}
