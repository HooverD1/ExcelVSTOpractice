using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Testing;
using Accord.Statistics.Distributions;

namespace ExcelWorkbook1
{
    public class UniformEstimate : DistributionEstimate
    {
        public UniformEstimate(List<double> data) : base(data)
        {
            this.DistributionType = Distribution.Uniform;
            this.testDistribution = UniformContinuousDistribution.Standard;
            this.RunTestOfFit();
        }
        public override void Construct()
        {
            this.ParameterDictionary.Add(Statistic.Mean, data.Average());
            this.ParameterDictionary.Add(Statistic.Min, data.Min());
            this.ParameterDictionary.Add(Statistic.Max, data.Max());
            this.ParameterDictionary.Add(Statistic.Median, data[(data.Count / 2) - 1]);
        }

    }
}
