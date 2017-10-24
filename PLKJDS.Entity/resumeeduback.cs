
namespace PLKJDS.Entity
{

    // resumeeduback
	// by bobomouse
    public partial class resumeeduback : EntityBaseModel<resumeeduback> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)
        public string ResumeID { get; set; } // ResumeID (length: 64)

        ///<summary>
        /// 院校名称
        ///</summary>
        public string School { get; set; } // School (length: 200)

        ///<summary>
        /// 专业
        ///</summary>
        public string Major { get; set; } // Major (length: 200)

        ///<summary>
        /// 开始日期
        ///</summary>
        public System.DateTime? SDT { get; set; } // SDT

        ///<summary>
        /// 结束日期
        ///</summary>
        public System.DateTime? EDT { get; set; } // EDT

        public resumeeduback()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

