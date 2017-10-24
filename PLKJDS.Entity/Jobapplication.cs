
namespace PLKJDS.Entity
{

    // Jobapplication
	// by bobomouse
    public partial class Jobapplication : EntityBaseModel<Jobapplication> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)
        public string UserID { get; set; } // UserID (length: 64)
        public string EmployID { get; set; } // EmployID (length: 64)
        public System.DateTime? ApplyTime { get; set; } // ApplyTime
        public string StatusCode { get; set; } // StatusCode (length: 11)
        public string ReMark { get; set; } // ReMark (length: 64)

        public Jobapplication()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

