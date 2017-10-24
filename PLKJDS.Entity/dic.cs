
namespace PLKJDS.Entity
{

    // dic
	// by bobomouse
    public partial class dic : EntityBaseModel<dic> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)
        public string Name { get; set; } // Name (length: 200)
        public string PID { get; set; } // PID (length: 64)

        public dic()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

