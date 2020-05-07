using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics;
using Accord.Statistics.Testing;
using Accord.Statistics.Distributions;
using Accord.Statistics.Distributions.Univariate;
using System.Windows;

namespace ExcelWorkbook1
{

    public static class DistributionFitter
    {
        public static DistributionEstimate FitData(List<double> data)
        {
            var estimates = new List<DistributionEstimate>();
            var returnEstimate1 = new UniformEstimate(data);
            var returnEstimate2 = new NormalEstimate(data);
            var returnEstimate3 = new ExponentialEstimate(data);
            var returnEstimate4 = new PoissonEstimate(data);
            var returnEstimate5 = new LognormalEstimate(data);
            estimates.Add(returnEstimate1);
            estimates.Add(returnEstimate2);
            estimates.Add(returnEstimate3);
            estimates.Add(returnEstimate4);
            estimates.Add(returnEstimate5);
            var bestFit = estimates.OrderBy(x => x.score).Last();
            bestFit.Construct();
            return bestFit;
        }
        
    }


}
