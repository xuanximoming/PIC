// BaseControls.ImageBox Math Library
//
// Copyright ?Andrew Kirillov, 2005-2007
// andrew.kirillov@gmail.com
//

namespace BaseControls.ImageBox.Math
{
    using System;

    /// <summary>
    /// Histogram for discrete random values
    /// </summary>
    /// 
    /// <remarks></remarks>
    /// 
    public class Histogram
    {
		private int[]	values;
		private double	mean = 0;
		private double	stdDev = 0;
		private int		median = 0;
		private int		min;
		private int		max;

        /// <summary>
        /// Values of the histogram
        /// </summary>
        /// 
		public int[] Values
		{
			get { return values; }
		}

        /// <summary>
        /// Mean value
        /// </summary>
        /// 
		public double Mean
		{
			get { return mean; }
		}

        /// <summary>
        /// Standard deviation
        /// </summary>
        /// 
		public double StdDev
		{
			get { return stdDev; }
		}

        /// <summary>
        /// Median value
        /// </summary>
        /// 
		public int Median
		{
			get { return median; }
		}

        /// <summary>
        /// Minimum value
        /// </summary>
        /// 
        /// <remarks>Minimum value of the histogram with non zero
        /// hits count.</remarks>
        /// 
		public int Min
		{
			get { return min; }
		}

        /// <summary>
        /// Maximum value
        /// </summary>
        /// 
        /// <remarks>Maximum value of the histogram with non zero
        /// hits count.</remarks>
        /// 
        public int Max
		{
			get { return max; }
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Histogram"/> class
        /// </summary>
        /// 
        /// <param name="values">Values of the histogram</param>
        /// 
		public Histogram( int[] values )
		{
			this.values = values;

			int i, n = values.Length;

			max = 0;
			min = n;

			// calculate min and max
			for ( i = 0; i < n; i++ )
			{
				if ( values[i] != 0 )
				{
					// max
					if ( i > max )
						max = i;
					// min
					if ( i < min )
						min = i;
				}
			}

			mean	= Statistics.Mean( values );
			stdDev	= Statistics.StdDev( values );
			median	= Statistics.Median( values );
		}

        /// <summary>
        /// Get range around median containing specified percentage of values
        /// </summary>
        /// 
        /// <param name="percent">Values percentage around median</param>
        /// 
        /// <returns>Returns the range which containes specifies percentage
        /// of values.</returns>
        /// 
		public IntRange GetRange( double percent )
		{
			return Statistics.GetRange( values, percent );
		}
    }
}
