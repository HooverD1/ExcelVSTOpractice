using NUnit.Framework;
using ExcelWorkbook1;
using System.Collections.Generic;

namespace Tests
{
    public class Tests
    {
        List<double> test_data;

        [SetUp]
        public void Setup()
        {
            test_data = new List<double>() { 1, 2, 3, 4, 5};
        }

        [Test]
        public void Test_LognormalEstimate_score()
        {
            var logNorm = new LognormalEstimate(test_data);
            logNorm.Construct();
            Assert.AreEqual(logNorm.score, 0.97989354960026254);
        }
        [Test]
        public void Test_NormalEstimate()
        {
            var norm = new NormalEstimate(test_data);
            norm.Construct();
            Assert.AreEqual(norm.score, 0.99975274853711238);
        }
    }
}