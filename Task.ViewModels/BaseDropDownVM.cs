namespace TaskManage.ViewModels
{
    public class BaseDropDownVM<TId>
    {
        public TId? Id { get; set; }
        public string? Value { get; set; }
    }
}