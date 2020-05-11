using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelWorkbook1
{
    public enum Distribution
    {
        Normal,
        Exponential,
        Uniform,
        Lognormal,
        Poisson,
        Triangular,
        Weibull
    }
    public enum Statistic
    {
        Mean,
        Stdev,
        Lambda,
        Location,
        Shape,
        Max,
        Min,
        Median,
        Mode,
        Scale
    }
}
