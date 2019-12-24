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
	/// Pixellate filter
	/// </summary>
	/// 
	/// <remarks></remarks>
	/// 
	public class Pixellate : FilterAnyToAny
	{
		private int	pixelWidth = 8;
		private int pixelHeight = 8;

		/// <summary>
		/// Pixel width
		/// </summary>
		/// 
		/// <remarks>Default value is 8. Minimum value is 2. Maximum value is 32.</remarks>
		/// 
		public int PixelWidth
		{
			get { return pixelWidth; }
			set { pixelWidth = Math.Max( 2, Math.Min( 32, value ) ); }
		}

		/// <summary>
		/// Pixel height
		/// </summary>
		/// 
		/// <remarks>Default value is 8. Minimum value is 2. Maximum value is 32.</remarks>
		/// 
		public int PixelHeight
		{
			get { return pixelHeight; }
			set { pixelHeight = Math.Max( 2, Math.Min( 32, value ) ); }
		}

		/// <summary>
		/// Pixel size
		/// </summary>
		/// 
		/// <remarks>The property is used to set both <see cref="PixelWidth"/> and
		/// <see cref="PixelHeight"/> simultaneously.</remarks>
		/// 
		public int PixelSize
		{
			set { pixelWidth = pixelHeight = Math.Max( 2, Math.Min( 32, value ) ); }
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Pixellate"/> class
		/// </summary>
		/// 
		public Pixellate( ) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="Pixellate"/> class
		/// </summary>
		/// 
		/// <param name="pixelSize">Pixel size</param>
		/// 
		public Pixellate( int pixelSize )
		{
			PixelSize = pixelSize;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Pixellate"/> class
		/// </summary>
		/// 
		/// <param name="pixelWidth">Pixel width</param>
		/// <param name="pixelHeight">Pixel height</param>
		/// 
		public Pixellate( int pixelWidth, int pixelHeight )
		{
			PixelWidth	= pixelWidth;
			PixelHeight	= pixelHeight;
		}

		/// <summary>
		/// Process the filter on the specified image
		/// </summary>
		/// 
		/// <param name="imageData">image data</param>
		/// 
		protected override unsafe void ProcessFilter( BitmapData imageData )
		{
			// get source image size
			int width	= imageData.Width;
			int height	= imageData.Height;

			int stride = imageData.Stride;
			int offset = stride - ( ( imageData.PixelFormat == PixelFormat.Format8bppIndexed ) ? width : width * 3 );

			// loop indexes and temp vars
			int i, j, k, x, t1, t2;
			// line length to process
			int len = (int)( ( width - 1 ) / pixelWidth ) + 1;
			// reminder
			int rem = ( ( width - 1 ) % pixelWidth ) + 1;

			// do the job
			byte * src = (byte *) imageData.Scan0.ToPointer( );
			byte * dst = src;

			if ( imageData.PixelFormat == PixelFormat.Format8bppIndexed )
			{
				// Grayscale image
				int[] tmp = new int[len];

				for ( int y1 = 0, y2 = 0; y1 < height; )
				{
					// collect pixels
					Array.Clear( tmp, 0, len );

					// calculate
					for ( i = 0; ( i < pixelHeight ) && ( y1 < height ); i++, y1++ )
					{
						// for each pixel
						for ( x = 0; x < width; x++, src ++ )
						{
							tmp[(int) ( x / pixelWidth )] += (int) *src;
						}
						src += offset;
					}

					// get average values
					t1 = i * pixelWidth;
					t2 = i * rem;

					for ( j = 0; j < len - 1; j++ )
						tmp[j] /= t1;
					tmp[j] /= t2;

					// save average value to destination image
					for ( i = 0; ( i < pixelHeight ) && ( y2 < height ); i++, y2++ )
					{
						// for each pixel
						for ( x = 0; x < width; x++, dst++ )
						{
							*dst = (byte) tmp[(int) ( x / pixelWidth )];
						}
						dst += offset;
					}
				}
			}
			else
			{
				// RGB image
				int[] tmp = new int[len * 3];

				for ( int y1 = 0, y2 = 0; y1 < height; )
				{
					// collect pixels
					Array.Clear( tmp, 0, len * 3 );

					// calculate
					for ( i = 0; ( i < pixelHeight ) && ( y1 < height ); i++, y1++ )
					{
						// for each pixel
						for ( x = 0; x < width; x++, src += 3 )
						{
							k = ( x / pixelWidth ) * 3;
							tmp[k    ] += src[RGB.R];
							tmp[k + 1] += src[RGB.G];
							tmp[k + 2] += src[RGB.B];
						}
						src += offset;
					}

					// get average values
					t1 = i * pixelWidth;
					t2 = i * rem;

					for ( j = 0, k = 0; j < len - 1; j++, k += 3 )
					{
						tmp[k    ] /= t1;
						tmp[k + 1] /= t1;
						tmp[k + 2] /= t1;
					}
					tmp[k    ] /= t2;
					tmp[k + 1] /= t2;
					tmp[k + 2] /= t2;

					// save average value to destination image
					for ( i = 0; ( i < pixelHeight ) && ( y2 < height ); i++, y2++ )
					{
						// for each pixel
						for ( x = 0; x < width; x++, dst += 3 )
						{
							k = ( x / pixelWidth ) * 3;
							dst[RGB.R] = (byte) tmp[k    ];
							dst[RGB.G] = (byte) tmp[k + 1];
							dst[RGB.B] = (byte) tmp[k + 2];
						}
						dst += offset;
					}
				}
			}
		}
	}
}
