using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Distributions;
using Accord.Statistics.Testing;

namespace ExcelWorkbook1
{
    public class LognormalEstimate : DistributionEstimate
    {
        public LognormalEstimate(List<double> data) : base(data)
        {
            if (data.Min() <= 0)
            {
                this.score = -1;        //negative data implies it can't be Lognormal
                return;
            }
            this.DistributionType = Distribution.Lognormal;
            this.testDistribution = LognormalDistribution.Estimate(data.ToArray());
            this.RunTestOfFit();
        }
        public override void Construct()
        {
            this.ParameterDictionary.Add(Statistic.Location, LognormalDistribution.Estimate(data.ToArray()).Location);
            this.ParameterDictionary.Add(Statistic.Shape, LognormalDistribution.Estimate(data.ToArray()).Shape);
            this.ParameterDictionary.Add(Statistic.Min, data.Min());
            this.ParameterDictionary.Add(Statistic.Max, data.Max());
            this.ParameterDictionary.Add(Statistic.Median, data[(data.Count / 2) - 1]);
        }

    }
}
