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
	/// Base class for filtering colored images without changing pixel format
	/// </summary>
	/// 
	/// <remarks>The abstract class is the base class for all filters, which can
	/// be applied to color images without changing their pixel format and image
	/// dimension. The base class is used for filters, which can be applied as
	/// directly to the specified image modifying it, as to the specified image
	/// returning new image, which represent result of image processing filter.
	/// </remarks>
	/// 
	public abstract class FilterColorToColor : IFilter, IInPlaceFilter
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
		public virtual Bitmap Apply( Bitmap image )
		{
			// lock source bitmap data
			BitmapData srcData = image.LockBits(
				new Rectangle( 0, 0, image.Width, image.Height ),
				ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb );

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
		public virtual Bitmap Apply( BitmapData imageData )
		{
			if ( imageData.PixelFormat != PixelFormat.Format24bppRgb )
				throw new ArgumentException( );

			// get image dimension
			int width = imageData.Width;
			int height = imageData.Height;

			// create new image
			Bitmap dstImage = new Bitmap( width, height, PixelFormat.Format24bppRgb );

			// lock destination bitmap data
			BitmapData dstData = dstImage.LockBits(
				new Rectangle( 0, 0, width, height ),
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb );

			// copy image
			Win32.memcpy( dstData.Scan0, imageData.Scan0, imageData.Stride * height );

			// process the filter
			ProcessFilter( dstData );

			// unlock destination images
			dstImage.UnlockBits( dstData );

			return dstImage;
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
		public virtual void ApplyInPlace( Bitmap image )
		{
			// lock source bitmap data
			BitmapData data = image.LockBits(
				new Rectangle( 0, 0, image.Width, image.Height ),
				ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb );

			// apply the filter
			ApplyInPlace( data );

			// unlock image
			image.UnlockBits( data );
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
		public virtual void ApplyInPlace( BitmapData imageData )
		{
			if ( imageData.PixelFormat != PixelFormat.Format24bppRgb )
				throw new ArgumentException( );

			// process the filter
			ProcessFilter( imageData );
		}

		/// <summary>
		/// Process the filter on the specified image
		/// </summary>
		/// 
		/// <param name="imageData">Image data</param>
		/// 
		protected abstract unsafe void ProcessFilter( BitmapData imageData );
	}
 }
