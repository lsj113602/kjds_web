using System;

namespace PLKJDS.Entity
{
    public interface IModificationAudited
    {
        string ID { get; set; }
        string LastModifyUserId { get; set; }
        DateTime? LastModifyTime { get; set; }
    }
}