namespace TaskManage.Entities
{
    public interface IEntityPrimaryKey<TId>
    {
        public TId Id { get; set; }
    }
}
