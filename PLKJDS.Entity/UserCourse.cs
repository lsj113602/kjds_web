
namespace PLKJDS.Entity
{

    // UserCourse
	// by bobomouse
    public partial class UserCourse : EntityBaseModel<UserCourse> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)
        public string UserID { get; set; } // UserID (length: 64)
        public string CourseID { get; set; } // CourseID (length: 64)
        public string CreatorUserId { get; set; } // CreatorUserId (length: 64)
        public System.DateTime? CreatorTime { get; set; } // CreatorTime
        public string LastModifyUserId { get; set; } // LastModifyUserId (length: 64)
        public System.DateTime? LastModifyTime { get; set; } // LastModifyTime
        public bool? DeleteMark { get; set; } // DeleteMark
        public string DeleteUserId { get; set; } // DeleteUserId (length: 64)
        public System.DateTime? DeleteTime { get; set; } // DeleteTime

        public UserCourse()
        {
            DeleteMark = true;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

