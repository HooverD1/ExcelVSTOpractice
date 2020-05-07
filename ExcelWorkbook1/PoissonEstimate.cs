using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Testing;
using Accord.Statistics.Distributions;
using Accord.Statistics.Distributions.Univariate;

namespace ExcelWorkbook1
{
    public class PoissonEstimate : DistributionEstimate
    {
        public double Average { get; set; }
        public PoissonEstimate(List<double> data) : base(data)
        {
            if(data.Min() <= 0)
            {
                this.score = -1;        //negative data implies it can't be Poisson
                return;
            }
            this.DistributionType = Distribution.Poisson;
            this.testDistribution = new PoissonDistribution(data.Average());
            this.RunTestOfFit();
        }
        public override void Construct()
        {
            this.ParameterDictionary.Add(Statistic.Lambda, data.Average());
            this.ParameterDictionary.Add(Statistic.Min, data.Min());
            this.ParameterDictionary.Add(Statistic.Max, data.Max());
            this.ParameterDictionary.Add(Statistic.Median, data[(data.Count / 2) - 1]);
        }
        protected override void RunTestOfFit()
        {
            var chiTest = new ChiSquareTest(data.ToArray(), new PoissonDistribution(data.Average()));
            this.score = chiTest.PValue;
        }
    }
}
