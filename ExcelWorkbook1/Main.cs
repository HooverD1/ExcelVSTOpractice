using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Models.Regression.Linear;

namespace ExcelWorkbook1
{
    public delegate T ListToPoint<T>(List<T> inputList);
    public class Main
    {        
        public ListToPoint<double> average = new ListToPoint<double>(GetAverage);
        public ListToPoint<double> max = new ListToPoint<double>(GetMax);
        public ListToPoint<double> min = new ListToPoint<double>(GetMin);
        private Excel.Worksheet worksheet { get; set; }
        private Excel.Application application { get; set; }
        private int sheetCount { get; set; }
        public Main(Excel.Application app)
        {
            application = app;
            worksheet = application.ActiveSheet;
            //sheetCount = workbook.Worksheets.Count;
        }
        public void RunMain()
        {
            //do stuff
            var mc = new MonteCarlo();
            //var data1 = mc.GetRandomizedData(new NormalDistribution(0,1));
            //var data1 = mc.GetRandomizedData(new PoissonDistribution(1));
            //var data1 = mc.GetRandomizedData(new LognormalDistribution(1, 1));
            var data1 = mc.GetRandomizedData(new ExponentialDistribution(1));
            //var data1 = mc.GetRandomizedData(new UniformContinuousDistribution());
            var reg = new SimpleLinearRegression();
            reg.Slope = 0.35;
            reg.Intercept = 3;
            //var data1 = mc.GetOutputDistribution(new TriangularDistribution(0, 10, 5), reg);
            //var data2 = mc.GetOutputDistribution(new TriangularDistribution(2, 14, 8), reg);
            //data1.AddRange(data2);      //can we add price outputs like this? No. Need to do a joint PDF I believe. MultivariateEmpiricalDistribution?
            var estim = DistributionFitter.FitData(data1);
            worksheet.Cells[1, 1] = estim.DistributionType.ToString();
            worksheet.Cells[2, 1] = estim.score * 100;
            int index = 2;
            foreach (double value in data1)
                worksheet.Cells[++index, 1] = value;
        }

        public static double GetAverage(List<double> inputList)
        {
            return inputList.Average();
        }
        public static double GetMax(List<double> inputList)
        {
            return inputList.Max();
        }
        public static double GetMin(List<double> inputList)
        {
            return inputList.Min();
        }
        
    }
}
