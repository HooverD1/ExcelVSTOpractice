using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Distributions;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Testing;

namespace ExcelWorkbook1
{
    public abstract class DistributionEstimate
    {
        public IUnivariateDistribution<double> testDistribution { get; set; }
        public double score { get; set; }
        public Distribution DistributionType { get; set; }
        public Dictionary<Statistic, double> ParameterDictionary { get; set; }
        public List<double> data { get; set; }
        public DistributionEstimate(List<double> data)
        {
            this.data = data;
            this.data.Sort();
            this.ParameterDictionary = new Dictionary<Statistic, double>();
        }
        public abstract void Construct();
        protected virtual void RunTestOfFit()
        {
            //var test = new AndersonDarlingTest(this.data.ToArray(), testDistribution);
            var test = new KolmogorovSmirnovTest(this.data.ToArray(), testDistribution);
            this.score = test.PValue;
        }
    }
}
