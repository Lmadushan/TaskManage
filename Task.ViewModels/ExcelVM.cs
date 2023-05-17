namespace TaskManage.ViewModels
{
    public class ExcelVM
    {
        public string? ColumnName { get; set; }
        public string? Column { get; set; }
        public IEnumerable<BaseDropDownVM<Guid>>? DropDownValuesGuid { get; set; }
        public IEnumerable<BaseDropDownVM<int>>? DropDownValuesInt { get; set; }
    }
}
