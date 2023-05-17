using System.ComponentModel;
using System.Data;
using System.Text;

namespace TaskManage.Common
{
    public static class Util
    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        //public static string CreatePassword(int length)
        //{
        //    const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        //    StringBuilder res = new StringBuilder();
        //    Random rnd = new Random();
        //    while (0 < length--)
        //    {
        //        res.Append(valid[rnd.Next(valid.Length)]);
        //    }
        //    return res.ToString();
        //}
    }
}
