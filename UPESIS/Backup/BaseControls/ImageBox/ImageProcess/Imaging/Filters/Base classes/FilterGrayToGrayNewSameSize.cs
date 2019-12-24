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

	/// <summary>
	/// Base class for filtering grayscale images without changing pixel format, but
	/// creating new image
	/// </summary>
	/// 
	/// <remarks>The abstract class is the base class for all filters, which can
	/// be applied to grayscale images without changing their pixel format
	/// and image dimension. The base class is used for filters, which can not be applied
	/// directly to the specified source image updating them. Instead of this, these
	/// filters return new image as a result of processing routine.</remarks>
	/// 
	public abstract class FilterGrayToGrayNewSameSize : IFilter
	{
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
			// lock source bitmap data
			BitmapData srcData = image.LockBits(
				new Rectangle( 0, 0, image.Width, image.Height ),
				ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed );

			// apply the filter
			Bitmap dstImage = Apply( srcData );

			// unlock source image
			image.UnlockBits( srcData );

			return dstImage;
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
			if ( imageData.PixelFormat != PixelFormat.Format8bppIndexed )
				throw new ArgumentException( );

			// get image dimension
			int width = imageData.Width;
			int height = imageData.Height;

			// create new image
			Bitmap dstImage = BaseControls.ImageBox.Imaging.Image.CreateGrayscaleImage( width, height );

			// lock destination bitmap data
			BitmapData dstData = dstImage.LockBits(
				new Rectangle( 0, 0, width, height ),
				ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed );

			// process the filter
			ProcessFilter( imageData, dstData );

			// unlock destination images
			dstImage.UnlockBits( dstData );

			return dstImage;
		}

		/// <summary>
		/// Process the filter on the specified image
		/// </summary>
		/// 
		/// <param name="sourceData">Source image data</param>
		/// <param name="destinationData">Destination image data</param>
		/// 
		protected abstract unsafe void ProcessFilter( BitmapData sourceData, BitmapData destinationData );
	}
}
