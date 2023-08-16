using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMB4_Improved_Stat_Tracker.DataReading
{
    
    internal class Text2CSV
    {
        public void ReadTXTProduceCSV(string filename)
        {
            
            List<string> list = new List<string> { "\"Mem\"", "\"00\"", "\"01\"", "\"02\"", "\"03\"", "\"04\"", "\"05\"", "\"06\"", "\"07\"", "\"08\"", "\"09\"", "\"0A\"", "\"0B\"", "\"0C\"", "\"0D\"", "\"0E\"", "\"0F\"" };

            DataTable dt = new DataTable();
            for (int i = 0; i < 17; i++)
            {
                dt.Columns.Add(list[i]);
            }
            foreach (var line in File.ReadAllLines(filename))
            {
                string editableLine = line;
                if(editableLine.Substring(0,1) == "\u009c" ) 
                { 
                    editableLine = editableLine.Substring(1);
                }
                DataRow dr = dt.NewRow();
                dr[list[0]] = "\"" + editableLine.Substring(0,8) + "\"";
                //if(editableLine.Substring(0, 8) == "000026F0" && filename == ".\\DataCopyLocation\\Entire Game\\Text2CSV\\season-TI1AB4.txt")
                //{ Console.Write("1"); }
                editableLine = editableLine.Substring(11);
                for(int i = 0; i < 16; i++) 
                {
                    dr[list[i+1]] = "\"" + editableLine.Substring(0, 2) + "\"";
                    editableLine = editableLine.Substring(3);
                }
                dt.Rows.Add(dr);
            }
            string coolerFileName = filename.Substring(0, filename.Length - 3) + "csv";
            if (File.Exists(coolerFileName))
            {
                File.Delete(coolerFileName);
            }
            //File.Create(coolerFileName);
            toCSV(dt, coolerFileName);
        }

        public void toCSV(DataTable dt, string filepath) 
        {
            
            //got this online
            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString());
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(filepath, sb.ToString());
        }
    }
}
