// BaseControls.ImageBox Image Processing Library
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//
// Original idea from CBaseControls.ImageBox
// http://www.codeproject.com/bitmap/cBaseControls.ImageBox.asp
//
namespace BaseControls.ImageBox.Imaging.Filters
{
	using System;
	using System.Drawing;
	using System.Drawing.Imaging;

	/// <summary>
	/// Dithering using Burkes error diffusion
	/// </summary>
	/// 
	/// <remarks></remarks>
	/// 
	public sealed class BurkesDithering : ErrorDiffusionDithering
	{
		private static int[] coef = new int[] { 2, 4, 8, 4, 2 };

		/// <summary>
		/// Do error diffusion
		/// </summary>
		/// 
		/// <param name="error">Current error value</param>
		/// <param name="ptr">Pointer to current processing pixel</param>
		/// 
		/// <remarks>All parameters of the image and current processing pixel's coordinates
		/// are initialized by base class.</remarks>
		/// 
		protected override unsafe void Diffuse(int error, byte * ptr)
		{
			int ed;	// error diffusion

			// calculate error diffusion
			if ( x < widthM1 )
			{
				// right pixel
				ed = ptr[1] + ( error * 8 ) / 32;
				ed = ( ed < 0 ) ? 0 : ( ( ed > 255 ) ? 255 : ed );
				ptr[1] = (byte) ed;
			}

			if ( x < widthM1 - 1 )
			{
				// right + 1 pixel
				ed = ptr[2] + ( error * 4 ) / 32;
				ed = ( ed < 0 ) ? 0 : ( ( ed > 255 ) ? 255 : ed );
				ptr[2] = (byte) ed;
			}

			if ( y != heightM1 )
			{
				// bottom pixels
				ptr += stride;
				for ( int i = -2, j = 0; i <= 2; i++, j++ )
				{
					if ( ( x + i >= 0 ) && ( x + i < width ) )
					{
						ed = ptr[i] + ( error * coef[j] ) / 32;
						ed = ( ed < 0 ) ? 0 : ( ( ed > 255 ) ? 255 : ed );
						ptr[i] = (byte) ed;
					}
				}
			}
		}
	}
}
