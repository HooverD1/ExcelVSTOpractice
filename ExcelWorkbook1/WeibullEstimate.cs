using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Distributions.Univariate;
using MathNet.Numerics;
using Accord.Statistics.Distributions;
using Accord.Statistics.Testing;

namespace ExcelWorkbook1
{
    public class WeibullEstimate : DistributionEstimate
    {
        public WeibullEstimate(List<double> data) : base(data)
        {
            this.DistributionType = Distribution.Weibull;
            testDistribution = new WeibullDistribution(1, 1);   //need to get estimates for params
            
            this.RunTestOfFit();
        }
        public override void Construct()
        {
            var thisDistrib = new WeibullDistribution(1, 1);
            thisDistrib.Fit(data.ToArray());
            this.ParameterDictionary.Add(Statistic.Scale, thisDistrib.Scale);
            this.ParameterDictionary.Add(Statistic.Shape, thisDistrib.Shape);
            this.ParameterDictionary.Add(Statistic.Min, data.Min());
            this.ParameterDictionary.Add(Statistic.Max, data.Max());
            this.ParameterDictionary.Add(Statistic.Median, data[(data.Count / 2) - 1]);

        }
        //protected override void RunTestOfFit()
        //{
        //    var test = new KolmogorovSmirnovTest(this.data.ToArray(), testDistribution);
        //    this.score = test.PValue;
        //}
    }
}
