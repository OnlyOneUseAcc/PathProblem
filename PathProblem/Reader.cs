using Microsoft.Office.Interop.Excel;
using System;


namespace PathProblem
{
    static class Reader
    {
        public static Graph getGraph(string pathToFile, bool graphType)
        {
            Graph answer = new Graph();
            //string pathToFile = @"D:\kejual projects\Practice\info.xlsx";
            Application excelInfo = new Application();
            Workbook workBook = excelInfo.Workbooks.Open(pathToFile, 0, false, 5, "", "", false, XlPlatform.xlWindows,
                "", true, false, 0, true, false, false);
            Worksheet workSheet = (Worksheet)workBook.Sheets[1];
            var lastCell = workSheet.Cells.SpecialCells(XlCellType.xlCellTypeLastCell);

            int lastColumn = lastCell.Column;
            int lastRow = lastCell.Row;

            for (int i = 1; i < lastRow; i++)
            {
                int first = Int32.Parse(workSheet.Cells[i + 1, 0 + 1].Text.ToString()) - 1;
                int second = Int32.Parse(workSheet.Cells[i + 1, 0 + 2].Text.ToString()) - 1;
                int coast = Int32.Parse(workSheet.Cells[i + 1, 0 + 3].Text.ToString());
                //Console.WriteLine(first + " " + second + " " + coast);
                answer.Add(first, new Tuple<int, int>(second, coast), graphType);
            }

            workBook.Close();
            excelInfo.Quit();
            
            return answer;
        }
    }
}
