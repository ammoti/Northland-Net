using System;

namespace Northland.Net.Domain
{
    public abstract class AuditableEntity
    {   public DateTime CreateDate { get; set; }
        public DateTime? LastModified { get; set; }
        public long CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public Status Status { get; set; }


        public void Activate() { Status = Status.Activated; }
        public void Deleted() { Status = Status.Deleted; }
        public void Inactivate() { Status = Status.Inactive; }
    }
}