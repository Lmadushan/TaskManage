using System.ComponentModel.DataAnnotations;

namespace TaskManage.Entities
{
    public abstract class BaseEntity<TId> : IEntityPrimaryKey<TId>
    {
        // TID type will come through from the class where BaseEntity been inherit
        public TId Id { get; set; }

        [MaxLength(450)]
        public string? CreatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        [MaxLength(450)]
        public string? EditedBy { get; set; }

        public DateTimeOffset? EditedOn { get; set; }

        [MaxLength(450)]
        public string? DeletedBy { get; set; }

        public DateTimeOffset? DeletedOn { get; set; }

        // when you create new entity inherit from this table add global filter and set IsDelete=False
        public bool IsDeleted { get; set; }

        //public List<BaseDomainEvent> Events = new();
    }
}