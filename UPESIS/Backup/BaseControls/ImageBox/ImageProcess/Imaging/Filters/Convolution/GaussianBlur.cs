// BaseControls.ImageBox Image Processing Library
//
// Copyright ?Andrew Kirillov, 2005-2007
// andrew.kirillov@gmail.com
//

namespace BaseControls.ImageBox.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	
	/// <summary>
	/// Gaussian blur filter
	/// </summary>
    /// 
    /// <remarks></remarks>
    /// 
	public sealed class GaussianBlur : IFilter
	{
		private Correlation	filter;
		private double		sigma = 1.4;
		private int			size = 5;

        /// <summary>
        /// Gaussian sigma value
        /// </summary>
        /// 
        /// <remarks>Sigma value for Gaussian function used to calculate
        /// the kernel. Default value is 1.4. Minimum value is 0.5. Maximum
        /// value is 5.0.</remarks>
        /// 
		public double Sigma
		{
			get { return sigma; }
			set
			{
				// get new sigma value
				sigma = Math.Max( 0.5, Math.Min( 5.0, value ) );
				// create filter
				CreateFilter( );
			}
		}

        /// <summary>
        /// Kernel size
        /// </summary>
        /// 
        /// <remarks>Size of Gaussian kernel. Default value is 5. Minimum value is 3.
        /// Maximum value is 5. The value should be odd.</remarks>
        /// 
		public int Size
		{
			get { return size; }
			set
			{
				size = Math.Max( 3, Math.Min( 21, value | 1 ) );
				CreateFilter( );
			}
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Correlation"/> class
        /// </summary>
        /// 
		public GaussianBlur( )
		{
			CreateFilter();
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Correlation"/> class
        /// </summary>
        /// 
        /// <param name="sigma">Gaussian sigma value</param>
        /// 
		public GaussianBlur( double sigma )
		{
			Sigma = sigma;
		}

        /// <summary>
        /// Initializes a new instance of the <see cref="Correlation"/> class
        /// </summary>
        /// 
        /// <param name="sigma">Gaussian sigma value</param>
        /// <param name="size">Kernel size</param>
        /// 
		public GaussianBlur( double sigma, int size )
		{
			Sigma = sigma;
			Size = size;
		}


        /// <summary>
        /// Apply filter to an image
        /// </summary>
        /// 
        /// <param name="image">Source image to apply filter to</param>
        /// 
        /// <returns>Returns filter's result obtained by applying the filter to
        /// the source image</returns>
        /// 
        /// <remarks>The method keeps the source image unchanged and returns the
        /// the result of image processing filter as new image.</remarks> 
        ///
        public Bitmap Apply( Bitmap image )
		{
            return filter.Apply( image );
		}

		/// <summary>
		/// Apply filter to an image
		/// </summary>
		/// 
		/// <param name="imageData">Source image to apply filter to</param>
		/// 
		/// <returns>Returns filter's result obtained by applying the filter to
		/// the source image</returns>
		/// 
		/// <remarks>The filter accepts birmap data as input and returns the result
		/// of image processing filter as new image. The source image data are kept
		/// unchanged.</remarks>
		/// 
        public Bitmap Apply( BitmapData imageData )
        {
            return filter.Apply( imageData );
        }

		// Private members
		#region Private Members

		// Create Gaussian filter
		private void CreateFilter( )
		{
			// create Gaussian function
			BaseControls.ImageBox.Math.Gaussian gaus = new BaseControls.ImageBox.Math.Gaussian( sigma );
			// create kernel
			int[,] kernel = gaus.KernelDiscret2D( size );
			// create filter
			filter = new Correlation( kernel );
		}
		#endregion
	}
}
