using System;

namespace PLKJDS.Entity
{
    public interface ICreationAudited
    {
        string ID { get; set; }
        string CreatorUserId { get; set; }
        DateTime? CreatorTime { get; set; }
    }
}