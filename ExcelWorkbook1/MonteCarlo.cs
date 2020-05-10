using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Distributions;
using Accord.Statistics.Models.Regression.Linear;
using Accord.MachineLearning;

namespace ExcelWorkbook1
{
    public class MonteCarlo
    {
        public List<double> samplingDistributionData { get; set; }
        private Random rando = new Random();
        public MonteCarlo()
        {
            samplingDistributionData = new List<double>();
        }
        
        public List<double> GetRandomizedData(ISampleableDistribution<double> distribution)
        {
            var returnList = new List<double>();
            for(int i=0;i<1000;i++)
                returnList.Add(distribution.Generate());
            return returnList;
        }
        internal List<double> GetSamplingDistributionData(ISampleableDistribution<double> distribution)
        {
            samplingDistributionData.Clear();
            for(int i = 0; i < 1000; i++)
            {
                var data = GetRandomizedData(distribution);
                samplingDistributionData.Add(data.Average());
            }
            return samplingDistributionData;
        }
        internal List<double> GetOutputDistribution(ISampleableDistribution<double> inputDistribution, SimpleLinearRegression regression)
        {
            var returnList = new List<double>();
            for(int i = 0; i < 1000; i++)
            {
                returnList.Add(regression.Transform(inputDistribution.Generate()));
            }
            return returnList;
        }
        internal double GetContinuousDistResult(UnivariateContinuousDistribution continuousDistribution, ListToPoint<double> function)
        {
            var inputList = new List<double>();
            for(int i=0;i<1000;i++)
                inputList.Add(continuousDistribution.Generate());
            return function(inputList);
        }
        internal double GetDiscreteDistResult(UnivariateDiscreteDistribution discreteDistribution, ListToPoint<double> function)
        {
            var inputList = new List<double>();
            for (int i = 0; i < 1000; i++)
                inputList.Add(discreteDistribution.Generate());
            return function(inputList);
        }

    }
}
