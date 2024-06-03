using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;

public class GVAR
{
    public ConcurrentDictionary<string, ConcurrentDictionary<string, string>> DicOfDic { get; set; }
        = new ConcurrentDictionary<string, ConcurrentDictionary<string, string>>();
    public ConcurrentDictionary<string, List<Dictionary<string, object>>> DicOfDT { get; set; }
        = new ConcurrentDictionary<string, List<Dictionary<string, object>>>();

    public void AddDataTable(string key, DataTable table)
    {
        var list = new List<Dictionary<string, object>>();

        foreach (DataRow row in table.Rows)
        {
            var dict = new Dictionary<string, object>();
            foreach (DataColumn col in table.Columns)
            {
                dict[col.ColumnName] = row[col];
            }
            list.Add(dict);
        }

        DicOfDT[key] = list;
    }


}
