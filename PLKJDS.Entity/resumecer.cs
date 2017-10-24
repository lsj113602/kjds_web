
namespace PLKJDS.Entity
{

    // resumecer
	// by bobomouse
    public partial class resumecer : EntityBaseModel<resumecer> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)
        public string ResumeID { get; set; } // ResumeID (length: 64)

        ///<summary>
        /// 证书等级
        ///</summary>
        public string Name { get; set; } // Name (length: 200)

        ///<summary>
        /// 证书等级
        ///</summary>
        public string CardLevel { get; set; } // CardLevel (length: 50)

        public string Level { get; set; }
        ///<summary>
        /// 颁发日期
        ///</summary>
        public System.DateTime? IsuDT { get; set; } // IsuDT

        public resumecer()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

