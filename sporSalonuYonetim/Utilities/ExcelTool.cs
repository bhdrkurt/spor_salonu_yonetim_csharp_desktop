using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace sporSalonuYonetim.Utilities
{
    public class ExcelTool
    {
        public static void ExportExcel(DataTable tbl, string excelFilePath)
        {
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");


               
                // load excel, and create a new workbook
                excelApp.Workbooks.Add();
                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }
                // rows
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < tbl.Columns.Count; j++)
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                }

                workSheet.Columns.AutoFit();//Bestfitallcolumn() yapıyor

                //workSheet.Rows.AutoFit();
                // check file path
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();

                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        //Marshal.FinalReleaseComObject(xlRng);
                        Marshal.FinalReleaseComObject(workSheet);

                        //excelApp.Worksheets[0].Close(Type.Missing, Type.Missing, Type.Missing);
                        //Marshal.FinalReleaseComObject(xlBook);

                        excelApp.Quit();

                        Marshal.FinalReleaseComObject(excelApp);
                        //MessageBox.Show("Excel file saved!");

                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n" + ex.Message);
                    }
                }
                else
                { // no file path is given
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
            finally
            {
                excelApp = null;
                GC.Collect();
                
            }
           
        }//Datatable excel'e çevirme
    }
}
