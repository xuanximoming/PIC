// BaseControls.ImageBox Image Processing Library
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace BaseControls.ImageBox.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;
	using BaseControls.ImageBox;

	/// <summary>
	/// Saturation adjusting in HSL color space
	/// </summary>
	/// 
	/// <remarks>The filter operates in <b>HSL</b> color space and adjusts
	/// pixels saturation value.</remarks>
	/// 
	public class SaturationCorrection : IFilter, IInPlaceFilter
	{
		private HSLLinear	baseFilter = new HSLLinear( );
		private double		adjustValue;	// [-1, 1]

		/// <summary>
		/// Saturation adjust value in the range of [-1, 1]. Default value is 0.1.
		/// </summary>
		public double AdjustValue
		{
			get { return adjustValue; }
			set
			{
				adjustValue = Math.Max( -1.0, Math.Min( 1.0, value ) );

				// create saturation filter
				if ( adjustValue > 0 )
				{
					baseFilter.InSaturation		= new DoubleRange( 0.0, 1.0 - adjustValue );
					baseFilter.OutSaturation	= new DoubleRange( adjustValue, 1.0 );
				}
				else
				{
					baseFilter.InSaturation		= new DoubleRange( -adjustValue, 1.0 );
					baseFilter.OutSaturation	= new DoubleRange( 0.0, 1.0 + adjustValue );
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SaturationCorrection"/> class
		/// </summary>
		/// 
		public SaturationCorrection( )
		{
			AdjustValue = 0.1;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SaturationCorrection"/> class
		/// </summary>
		/// 
		/// <param name="adjustValue">Saturation adjust value</param>
		/// 
		public SaturationCorrection( double adjustValue )
		{
			AdjustValue = adjustValue;
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
			return baseFilter.Apply( image );
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
			return baseFilter.Apply( imageData );
		}

		/// <summary>
		/// Apply filter to an image
		/// </summary>
		/// 
		/// <param name="image">Image to apply filter to</param>
		/// 
		/// <remarks>The method applies the filter directly to the provided
		/// image.</remarks>
		/// 
		public void ApplyInPlace( Bitmap image )
		{
			baseFilter.ApplyInPlace( image );
		}

		/// <summary>
		/// Apply filter to an image
		/// </summary>
		/// 
		/// <param name="imageData">Image to apply filter to</param>
		/// 
		/// <remarks>The method applies the filter directly to the provided
		/// image data.</remarks>
		/// 
		public void ApplyInPlace( BitmapData imageData )
		{
			baseFilter.ApplyInPlace( imageData );
		}
	}
}
