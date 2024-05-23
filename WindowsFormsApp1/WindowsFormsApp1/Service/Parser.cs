using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1.Service
{
    internal class Parser
    {
        public DataTable LoadDataFromCSV(string filePath)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    string[] columnNames = lines[0].Split(';');

                    foreach (string columnName in columnNames)
                    {
                        dataTable.Columns.Add(columnName);
                    }

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] values = lines[i].Split(';');
                        dataTable.Rows.Add(values);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных из файла: " + ex.Message);
            }
            return dataTable;
        }
    }
}
