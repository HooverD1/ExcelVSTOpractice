using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelWorkbook1
{
    public static class RangeConverter
    {
        //Grab a range and convert it to a C# data structure so that cell interaction is limited
        public static T[,] ConvertRangeToArray<T>(Excel.Range inputRange)
        {
            int rows = inputRange.Rows.Count;
            int columns = inputRange.Columns.Count;
            int r = 0;
            int c = 0;

            var output = new T[rows, columns];
            foreach (Excel.Range cell in inputRange.Cells)
            {
                output[r, c] = cell.Value;
                c++;
                if (c > columns)
                {
                    c = 0;
                    r++;
                }
            }
            return output;
        }
        public static void PrintArrayToRange<T>(T[,] inputArray, string topCell, Excel.Worksheet sheet)
        {
            int rows = inputArray.GetLength(0);
            int cols = inputArray.GetLength(1);
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    sheet.Cells[r, c] = inputArray[r, c];
                }
            }
        }
    }
}
