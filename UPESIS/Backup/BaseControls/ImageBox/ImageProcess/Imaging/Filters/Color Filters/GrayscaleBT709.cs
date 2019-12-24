// BaseControls.ImageBox Image Processing Library
//
// Copyright ?Andrew Kirillov, 2005-2006
// andrew.kirillov@gmail.com
//

namespace BaseControls.ImageBox.Imaging.Filters
{
	using System.Drawing;
	using System.Drawing.Imaging;

	/// <summary>
	/// Grayscale using BT709 algorithm
	/// </summary>
	/// 
	/// <remarks>The class uses <b>BT709</b> algorithm to convert color image
	/// to grayscale. The conversion coefficients are:
	/// <list type="bullet">
	/// <item>Red: 0.2125;</item>
	/// <item>Green: 0.7154;</item>
	/// <item>Blue: 0.0721.</item>
	/// </list>
	/// </remarks>
	/// 
	public sealed class GrayscaleBT709 : Grayscale
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="GrayscaleBT709"/> class
		/// </summary>
		public GrayscaleBT709( ) : base( 0.2125, 0.7154, 0.0721 )
		{
		}
	}
}
