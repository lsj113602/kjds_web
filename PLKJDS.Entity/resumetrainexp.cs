
namespace PLKJDS.Entity
{

    // resumetrainexp
	// by bobomouse
    public partial class resumetrainexp : EntityBaseModel<resumetrainexp> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)
        public string ResumeID { get; set; } // ResumeID (length: 64)

        ///<summary>
        /// 培训公司
        ///</summary>
        public string CpyName { get; set; } // CpyName (length: 200)

        ///<summary>
        /// 培训岗位
        ///</summary>
        public string Post { get; set; } // Post (length: 50)

        ///<summary>
        /// 培训内容
        ///</summary>
        public string TrainDesc { get; set; } // TrainDesc (length: 2000)

        ///<summary>
        /// 开始时间
        ///</summary>
        public System.DateTime? SDT { get; set; } // SDT

        ///<summary>
        /// 结束时间
        ///</summary>
        public System.DateTime? EDT { get; set; } // EDT

        public resumetrainexp()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

