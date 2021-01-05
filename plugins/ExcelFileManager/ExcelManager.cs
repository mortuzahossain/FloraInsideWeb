using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System;
using System.Data;
using System.Collections.Generic; 
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using GlobalEntities.Entities;
using static GlobalEntities.Enums.GlobalEnums;
using OfficeOpenXml.Style;

namespace ExcelFileManager
{
    public static class ExcelManager
    {
        public static void CreateExcel()
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
              //  MessageBox.Show("Excel is not properly installed!!");
                return;
            }


            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 1] = "ID";
            xlWorkSheet.Cells[1, 2] = "Name";
            xlWorkSheet.Cells[2, 1] = "1";
            xlWorkSheet.Cells[2, 2] = "One";
            xlWorkSheet.Cells[3, 1] = "2";
            xlWorkSheet.Cells[3, 2] = "Two";

            //Here saving the file in xlsx
            xlWorkBook.SaveAs("d:\\vdfgdfg.xlsx", Microsoft.Office.Interop.Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
            misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);


            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);


             

          //  MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xlsx");
        }


        public static MemoryStream DataTableToExcelXlsx(System.Data.DataTable table, string sheetName, ReportPrintCommon reportPrintCommon)
        {
            MemoryStream Result = new MemoryStream();
            ExcelPackage pack = new ExcelPackage();
            ExcelWorksheet ws = pack.Workbook.Worksheets.Add(sheetName);
            //ws.Cells[1, 1, 1, 8].Merge = true;
            //ws.Cells["A1:C1"].Merge = true;
            //ws.Cells[1, 4][1, 8].Value = "Test Marge";
            
            #region Page Header

            Int32 col = 1;
            Int32 row = 1;

            if (reportPrintCommon != null)
            {
                string headerTable = string.Empty;
                if (table != null)
                {
                    if (table.Rows.Count > 0)
                    {

                        //BankName
                        ws.Cells[row, 1, row, table.Columns.Count].Merge = true;
                        ws.Cells[row, 1, row, table.Columns.Count].Value = reportPrintCommon.BankName.Trim();
                        ws.Cells[row, 1, row, table.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        row = row + 1;

                        //Branch Name
                        ws.Cells[row, 1, row, table.Columns.Count].Merge = true;
                        ws.Cells[row, 1, row, table.Columns.Count].Value = reportPrintCommon.BranchName.Trim();
                        ws.Cells[row, 1, row, table.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        row = row + 1;

                        //Report Title
                        ws.Cells[row, 1, row, table.Columns.Count].Merge = true;
                        ws.Cells[row, 1, row, table.Columns.Count].Value = reportPrintCommon.ReportTitle.Trim();
                        ws.Cells[row, 1, row, table.Columns.Count].Style.Font.Bold = true;
                        ws.Cells[row, 1, row, table.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        row = row + 1;

                        if (!string.IsNullOrEmpty(reportPrintCommon.ReportSubTitle))
                        {
                            //Report Sub Title
                            ws.Cells[row, 1, row, table.Columns.Count].Merge = true;
                            ws.Cells[row, 1, row, table.Columns.Count].Value = reportPrintCommon.ReportSubTitle.Trim();
                            ws.Cells[row, 1, row, table.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            row = row + 1;
                        }


                        if (reportPrintCommon.ReportFormDetails != null)
                        {
                            if (reportPrintCommon.ReportFormDetails.Count > 0)
                            {
                                for (int i = 0; i < reportPrintCommon.ReportFormDetails.Count; i++)
                                {
                                    if (reportPrintCommon.ReportFormDetails[i].UserInputValue != "")
                                    {
                                        if ((reportPrintCommon.ReportFormDetails[i].ControlTypeId == (int)FieldType.Dropdown) || (reportPrintCommon.ReportFormDetails[i].ControlTypeId == (int)FieldType.EmbededCheckBox))
                                        {
                                            ws.Cells[row, 1, row, table.Columns.Count].Merge = true;
                                            ws.Cells[row, 1, row, table.Columns.Count].Value = reportPrintCommon.ReportFormDetails[i].DisplayName.Trim() + " : " + reportPrintCommon.ReportFormDetails[i].UserInputValueName.Trim();
                                            ws.Cells[row, 1, row, table.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            row = row + 1;
                                        }
                                        else
                                        {
                                            ws.Cells[row, 1, row, table.Columns.Count].Merge = true;
                                            ws.Cells[row, 1, row, table.Columns.Count].Value = reportPrintCommon.ReportFormDetails[i].DisplayName.Trim() + " : " + reportPrintCommon.ReportFormDetails[i].UserInputValue.Trim();
                                            ws.Cells[row, 1, row, table.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                            row = row + 1;
                                        }
                                    }
                                }
                            }
                        }

                        //Report Print Date
                        ws.Cells[row, 1, row, table.Columns.Count].Merge = true;
                        ws.Cells[row, 1, row, table.Columns.Count].Value = "Print Date: " + reportPrintCommon.ReportPrintDate;
                        ws.Cells[row, 1, row, table.Columns.Count].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        row = row + 1;

                    }
                    else
                    {
                        ws.Cells[row, 1, row, 8].Merge = true;
                        ws.Cells[row, 1, row, 8].Value = "No data found";
                        ws.Cells[row, 1, row, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        row = row + 1;
                    }
                }
                else
                {
                    ws.Cells[row, 1, row, 8].Merge = true;
                    ws.Cells[row, 1, row, 8].Value = "No data found";
                    ws.Cells[row, 1, row, 8].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    row = row + 1;
                }

                //HttpContext.Current.Response.Write("<br><br>");
            }

             
            #endregion

            #region Report Header
            col = 1;
            row = row+1;
            foreach (DataColumn column in table.Columns)
            {
                ws.Cells[row, col].Value = column.ColumnName.ToString();
                ws.Cells[row, col].Style.Font.Bold = true;
                col++;
            }
            #endregion

            #region Report Details
            col = 1;
            row = row+1;
            foreach (DataRow rw in table.Rows)
            {
                foreach (DataColumn cl in table.Columns)
                {
                    if (rw[cl.ColumnName] != DBNull.Value)
                    {
                        if (cl.DataType.Name.ToUpper() == "DECIMAL")
                        {
                            Double amt = 0;
                            amt = Double.Parse(rw[cl.ColumnName].ToString());
                            if (amt == 0)
                            {
                                ws.Cells[row, col].Value = 0.00;
                            }
                            else
                            {
                                ws.Cells[row, col].Value = amt;
                                ws.Cells[row, col].Style.Numberformat.Format = "###,###,##,###,##.00";
                            }
                        }
                        else if (cl.DataType.Name.ToUpper() == "INT32")
                        {
                            Int64 amt = 0;
                            amt = Int64.Parse(rw[cl.ColumnName].ToString());
                            ws.Cells[row, col].Value = amt;
                            ws.Cells[row, col].Style.Numberformat.Format = "######";
                        }
                        else
                        {
                            ws.Cells[row, col].Value = rw[cl.ColumnName].ToString();
                        }
                    }
                    col++;
                }
                row++;
                col = 1;
            }
            #endregion

            #region Report Footer

            #endregion


            pack.SaveAs(Result);
            return Result;
        }
        public static void ExportToExcel(ref string repley, string fileName, System.Data.DataTable dt, ReportPrintCommon reportPrintCommon)
        {


           


            MemoryStream ms = DataTableToExcelXlsx(dt, "Sheet1", reportPrintCommon);
            ms.WriteTo(HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName+".xlsx");
            HttpContext.Current.Response.StatusCode = 200;
            HttpContext.Current.Response.End();

            return;
        }
        //public static void Export(ref string repley, string fileName, GridView gv, ReportPrintCommon reportPrintCommon)
        //{
        //    //HttpContext.Current.Response.Clear();
        //    //HttpContext.Current.Response.AddHeader(
        //    //    "content-disposition", string.Format("attachment; filename={0}", fileName));
        //    ////HttpContext.Current.Response.ContentType = "application/ms-excel";

        //    //HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        //    MemoryStream ms = DataTableToExcelXlsx(dt, "Sheet1");
        //    ms.WriteTo(HttpContext.Current.Response.OutputStream);
        //    HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + Filename);
        //    HttpContext.Current.Response.StatusCode = 200;
        //    HttpContext.Current.Response.End();

        //    if (reportPrintCommon != null)
        //    {
        //        string headerTable = string.Empty;
        //        if (gv.HeaderRow != null)
        //        {
        //            //headerTable = "<Table> <tr> <td rowspan='2'><img src='D:\\Flora Bank\\Release\\bank_logo.png' style='height: 60px'\\></td> <td  style = 'font-size:20px;'> " + paramValues[0] + "</td> </tr> <tr> <td> " + paramValues[1] + " </td> </tr> <tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "' style = 'font-size:20px; text-align: center'> Report Title : " + paramValues[2] + "</td> </tr> <tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "' style = 'font-size:12px; text-align: center'> Report Date : " + paramValues[3] + "</td> </tr> </Table> ";
        //            headerTable = "<Table> "
        //                + "<tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "'  style = 'font-size:20px; text-align: center'> " + reportPrintCommon.BankName + "</td> </tr>"
        //                + "<tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "' style = 'font-size:16px; text-align: center'> " + reportPrintCommon.BranchName + " </td> </tr>"
        //                //+ "<tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "' style = 'font-size:20px; text-align: center'>" + reportPrintCommon.ReportedBranchName + "</td> </tr>"
        //                + "<tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "' style = 'font-size:18px; text-align: center'>" + reportPrintCommon.ReportTitle + "</td> </tr>";
        //            if (!string.IsNullOrEmpty(reportPrintCommon.ReportSubTitle))
        //            {
        //                headerTable = headerTable + "<tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "' style = 'font-size:14px; text-align: center'>" + reportPrintCommon.ReportSubTitle + "</td> </tr>";
        //            }

        //            if (reportPrintCommon.ReportFormDetails != null)
        //            {
        //                if (reportPrintCommon.ReportFormDetails.Count > 0)
        //                {
        //                    for (int i = 0; i < reportPrintCommon.ReportFormDetails.Count; i++)
        //                    {
        //                        if (reportPrintCommon.ReportFormDetails[i].UserInputValue != "")
        //                        {
        //                            if ((reportPrintCommon.ReportFormDetails[i].ControlTypeId == (int)FieldType.Dropdown) || (reportPrintCommon.ReportFormDetails[i].ControlTypeId == (int)FieldType.EmbededCheckBox))
        //                            {
        //                                headerTable = headerTable + "<tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "' style = 'font-size:14px; text-align: center'>" + reportPrintCommon.ReportFormDetails[i].DisplayName + " : " + reportPrintCommon.ReportFormDetails[i].UserInputValueName + "</td> </tr>";
        //                            }
        //                            else
        //                            {
        //                                headerTable = headerTable + "<tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "' style = 'font-size:14px; text-align: center'>" + reportPrintCommon.ReportFormDetails[i].DisplayName + " : " + reportPrintCommon.ReportFormDetails[i].UserInputValue + "</td> </tr>";
        //                            }
        //                        }
        //                    }
        //                }
        //            }

        //            headerTable = headerTable + "<tr> <td colspan = '" + gv.HeaderRow.Cells.Count.ToString() + "' style = 'font-size:14px; text-align: center'> Print Date: " + reportPrintCommon.ReportPrintDate + "</td> </tr>";

        //            headerTable = headerTable + "</Table> ";
        //            HttpContext.Current.Response.Write(headerTable);
        //        }
        //        else
        //        {
        //            //headerTable = "<Table> <tr> <td rowspan='2'><img src='D:\\Flora Bank\\Release\\bank_logo.png' style='height: 60px'\\></td> <td  style = 'font-size:20px;'> " + paramValues[0] + "</td> </tr> <tr> <td> " + paramValues[1] + " </td> </tr> <tr> <td colspan = '5' style = 'font-size:20px; text-align: center'> Report Title : " + paramValues[2] + "</td> </tr> <tr> <td colspan = '5' style = 'font-size:12px; text-align: center'> Report Date : " + paramValues[3] + "</td> </tr> </Table> ";
        //            headerTable = "<Table> <tr>  <td colspan = '5' style = 'font-size:20px; text-align: center'> " + reportPrintCommon.BankName + "</td> </tr> <tr> <td  colspan = '5' style = 'font-size:16px; text-align: center'> " + reportPrintCommon.BranchName + " </td> </tr> <tr> <td colspan = '5' style = 'font-size:20px; text-align: center'>" + reportPrintCommon.ReportName + "</td> </tr> <tr> <td colspan = '5' style = 'font-size:14px; text-align: center'> Report Date : " + reportPrintCommon.ReportPrintDate + "</td> </tr> </Table> ";
        //            HttpContext.Current.Response.Write(headerTable);
        //            HttpContext.Current.Response.Write("<br><br>");
        //            HttpContext.Current.Response.Write("No data found <br>");

        //        }

        //        HttpContext.Current.Response.Write("<br><br>");
        //    }
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
        //        {

        //            //  Create a table to contain the grid
        //            Table table = new Table();

        //            //  include the gridline settings
        //            table.GridLines = gv.GridLines;

        //            //  add the header row to the table
        //            if (gv.HeaderRow != null)
        //            {
        //                //GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
        //                table.Rows.Add(gv.HeaderRow);
        //            }

        //            //  add each of the data rows to the table
        //            foreach (GridViewRow row in gv.Rows)
        //            {
        //                //GridViewExportUtil.PrepareControlForExport(row);
        //                table.Rows.Add(row);
        //            }

        //            //  add the footer row to the table
        //            //if (gv.FooterRow != null)
        //            //{
        //            //    GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
        //            //    table.Rows.Add(gv.FooterRow);
        //            //}

        //            //  render the table into the htmlwriter
        //            table.RenderControl(htw);

        //            //  render the htmlwriter into the response
        //            HttpContext.Current.Response.Write(sw.ToString());
        //            HttpContext.Current.Response.End();
        //        }
        //    }
        //}

    }
}
