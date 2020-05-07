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
    public class ExponentialEstimate : DistributionEstimate
    {
        public ExponentialEstimate(List<double> data) : base(data)
        {
            if (data.Min() <= 0)
            {
                this.score = -1;        //negative data implies it can't be Exponential
                return;
            }
            this.DistributionType = Distribution.Exponential;
            testDistribution = new ExponentialDistribution(data.Average());
            this.RunTestOfFit();
        }
        public override void Construct()    //if this is the chosen distribution, construct parameters for it
        {
            this.ParameterDictionary.Add(Statistic.Mean, data.Average());
            this.ParameterDictionary.Add(Statistic.Min, data.Min());
            this.ParameterDictionary.Add(Statistic.Max, data.Max());
            this.ParameterDictionary.Add(Statistic.Median, data[(data.Count / 2) - 1]);
        }

    }
}
