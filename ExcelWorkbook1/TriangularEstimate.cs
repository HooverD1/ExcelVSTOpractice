using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Testing;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Distributions;
using MathNet.Numerics.Statistics;

namespace ExcelWorkbook1
{
    public class TriangularEstimate : DistributionEstimate
    {
        public TriangularEstimate(List<double> data) : base(data)
        {
            this.DistributionType = Distribution.Triangular;

            //testDistribution = (IDistribution<double>)(new TriangularDistribution(data.Min(), data.Max(), );
            this.RunTestOfFit();
        }
        public override void Construct()
        {
            
        }

    }
}
