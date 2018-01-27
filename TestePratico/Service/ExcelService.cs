using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace TestePratico.Service
{
    public class ExcelService
    {
        public MemoryStream ExportExcel<T>(List<T> list)
        {
            MemoryStream memory = null;
            ExcelPackage excelPackage = null;
            ExcelWorksheet excel = null;
            PropertyInfo[] propertyInfo = null;

            using (memory = new MemoryStream())
            {
                using (excelPackage = new ExcelPackage(memory))
                {
                    if (list != null && list.Count > 0)
                    {
                        propertyInfo = list[0].GetType().GetProperties();
                        excel = excelPackage.Workbook.Worksheets.Add(list[0].GetType().Name);
                        excel.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        var column = 1;
                        var row = 1;

                        for (int i = 0; i < propertyInfo.Count(); i++)
                        {
                            excel.Cells[row, column].Value = propertyInfo[i].Name;
                            column++;
                        }

                        column = 1;
                        row = 2;

                        foreach (var item in list)
                        {
                            propertyInfo = item.GetType().GetProperties();

                            for (int i = 0; i < propertyInfo.Count(); i++)
                            {
                                excel.Cells[row, column].Value = item.GetType().GetProperty(propertyInfo[i].Name).GetValue(item).ToString();
                                column++;
                            }

                            row++;
                            column = 1;
                        }

                        excelPackage.Save();
                    }
                }
            }           

            return memory;
        }
    }
}