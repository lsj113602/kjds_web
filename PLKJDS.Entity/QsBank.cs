
namespace PLKJDS.Entity
{

    // QsBank
	// by bobomouse
    public partial class QsBank : EntityBaseModel<QsBank> //,ICreationAudited, IDeleteAudited, IModificationAudited
    {
        public string ID { get; set; } // ID (Primary key) (length: 64)
        public string OrgName { get; set; } // OrgName (length: 300)
        public string StrName { get; set; } // StrName (length: 300)
        public string FileExt { get; set; } // FileExt (length: 50)
        public string FilePath { get; set; } // FilePath (length: 2147483647)
        public string CreatorUserId { get; set; } // CreatorUserId (length: 64)
        public System.DateTime? CreatorTime { get; set; } // CreatorTime
        public string LastModifyUserId { get; set; } // LastModifyUserId (length: 64)
        public System.DateTime? LastModifyTime { get; set; } // LastModifyTime
        public bool? DeleteMark { get; set; } // DeleteMark
        public string DeleteUserId { get; set; } // DeleteUserId (length: 64)
        public System.DateTime? DeleteTime { get; set; } // DeleteTime

        public QsBank()
        {
            DeleteMark = true;
            InitializePartial();
        }

        partial void InitializePartial();
    }

}

