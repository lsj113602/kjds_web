
namespace PLKJDS.Entity
{

    // resumeworkexp
	// by bobomouse
    public partial class resumeworkexp : EntityBaseModel<resumeworkexp> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)
        public string ResumeID { get; set; } // ResumeID (length: 64)

        ///<summary>
        /// 实习公司
        ///</summary>
        public string CpyName { get; set; } // CpyName (length: 200)

        ///<summary>
        /// 所任职务
        ///</summary>
        public string Post { get; set; } // Post (length: 50)

        ///<summary>
        /// 工作内容
        ///</summary>
        public string JobDesc { get; set; } // JobDesc (length: 2000)

        ///<summary>
        /// 开始时间
        ///</summary>
        public System.DateTime? SDT { get; set; } // SDT

        ///<summary>
        /// 结束时间
        ///</summary>
        public System.DateTime? EDT { get; set; } // EDT

        public resumeworkexp()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

