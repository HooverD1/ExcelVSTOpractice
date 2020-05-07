using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Testing;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Distributions;
using Accord.Math;
using Accord.Math.Metrics;
using MathNet.Numerics.Statistics;

namespace ExcelWorkbook1
{
    public class NormalEstimate : DistributionEstimate
    {
        public NormalEstimate(List<double> data) : base(data)
        {
            this.DistributionType = Distribution.Normal;
            testDistribution = new NormalDistribution(data.Average(),data.StandardDeviation());
            this.RunTestOfFit();
        }
        public override void Construct()
        {
            this.ParameterDictionary.Add(Statistic.Max, data.Max());
            this.ParameterDictionary.Add(Statistic.Min, data.Min());
            this.ParameterDictionary.Add(Statistic.Mean, data.Average());
            this.ParameterDictionary.Add(Statistic.Median, data[(data.Count / 2) - 1]);
        }
    }
}
