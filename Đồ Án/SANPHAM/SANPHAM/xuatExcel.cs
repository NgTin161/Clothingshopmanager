using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SANPHAM
{
    internal class xuatExcel
    {
        public void ToExcel(DataGridView dataGridView1, string fileName)
        {
            //khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                string day = DateTime.Now.ToString("dd");
                string month = DateTime.Now.ToString("MM");
                string year = DateTime.Now.ToString("yyyy");

                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                Microsoft.Office.Interop.Excel.Range titleRange = worksheet.get_Range("A1", "F1"); // Điều chỉnh khoảng cụ thể tùy theo số cột trong sheet
                titleRange.Font.Name = "Times New Roman";
                titleRange.Font.Size = 16;
                titleRange.Font.Bold = true;
                titleRange.Merge();
                worksheet.Name = "BÁO CÁO NGÀY (" + day + "_" + month + "_" + year + ")";
                worksheet.Cells[1, 1] = "BÁO CÁO BÁN HÀNG (" + day + "/" + month + "/" + year + ")";
                
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[3, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            worksheet.Cells[i + 4, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        }
                       
                    }
                }
                decimal sum = 0;
                int thanhTienColumnIndex = 6; 
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[thanhTienColumnIndex].Value != null)
                    {
                        decimal cellValue;
                        if (decimal.TryParse(dataGridView1.Rows[i].Cells[thanhTienColumnIndex].Value.ToString(), out cellValue))
                        {
                            sum += cellValue;
                        }
                    }
                }

           
                worksheet.Cells[dataGridView1.RowCount + 4, thanhTienColumnIndex ] = "Tổng";
                worksheet.Cells[dataGridView1.RowCount + 4, thanhTienColumnIndex + 1] = sum + " VND";
                Microsoft.Office.Interop.Excel.Range headerRange = (Microsoft.Office.Interop.Excel.Range)worksheet.Rows[3];
               
           
                Microsoft.Office.Interop.Excel.Font headerFont = headerRange.Font;

                
                headerFont.Bold = true;

                Microsoft.Office.Interop.Excel.Range startCell = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[3, 1]; 

                Microsoft.Office.Interop.Excel.Range dataRange = startCell.get_Resize(worksheet.UsedRange.Rows.Count, worksheet.UsedRange.Columns.Count);

        
                Microsoft.Office.Interop.Excel.Borders borders = dataRange.Borders;

            
                borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                
                workbook.SaveAs(fileName);
              
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }
    }
}
