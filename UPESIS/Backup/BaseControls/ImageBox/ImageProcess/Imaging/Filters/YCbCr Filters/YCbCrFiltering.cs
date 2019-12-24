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
	/// Color filtering in YCbCr color space
	/// </summary>
	/// 
	/// <remarks>The filter operates in <b>YCbCr</b> color space and filters
	/// pixels, which color is inside or outside of specified YCbCr range.</remarks>
	/// 
	public class YCbCrFiltering : FilterColorToColor
	{
		private DoubleRange yRange  = new DoubleRange(  0.0, 1.0 );
		private DoubleRange cbRange = new DoubleRange( -0.5, 0.5 );
		private DoubleRange crRange = new DoubleRange( -0.5, 0.5 );

		private double fillY  = 0.0;
		private double fillCb = 0.0;
		private double fillCr = 0.0;
		private bool fillOutsideRange = true;

		private bool updateY  = true;
		private bool updateCb = true;
		private bool updateCr = true;

		#region Public properties

		/// <summary>
		/// Range of Y component
		/// </summary>
		/// 
		/// <remarks>Y component is measured in the range of [0, 1].</remarks>
		/// 
		public DoubleRange Y
		{
			get { return yRange; }
			set { yRange = value; }
		}

		/// <summary>
		/// Range of Cb component
		/// </summary>
		/// 
		/// <remarks>Cb component is measured in the range of [-0.5, 0.5].</remarks>
		/// 
		public DoubleRange Cb
		{
			get { return cbRange; }
			set { cbRange = value; }
		}

		/// <summary>
		/// Range of Cr component
		/// </summary>
		/// 
		/// <remarks>Cr component is measured in the range of [-0.5, 0.5].</remarks>
		/// 
		public DoubleRange Cr
		{
			get { return crRange; }
			set { crRange = value; }
		}

		/// <summary>
		/// Fill color used to fill filtered pixels
		/// </summary>
		public YCbCr FillColor
		{
			get { return new YCbCr( fillY, fillCb, fillCr ); }
			set
			{
				fillY  = value.Y;
				fillCb = value.Cb;
				fillCr = value.Cr;
			}
		}

		/// <summary>
		/// Determines, if pixels should be filled inside or outside specified
		/// color range
		/// </summary>
		public bool FillOutsideRange
		{
			get { return fillOutsideRange; }
			set { fillOutsideRange = value; }
		}

		/// <summary>
		/// Determines, if Y value of filtered pixels should be updated.
		/// <b>True</b> by default.
		/// </summary>
		public bool UpdateY
		{
			get { return updateY; }
			set { updateY = value; }
		}

		/// <summary>
		/// Determines, if Cb value of filtered pixels should be updated.
		/// <b>True</b> by default.
		/// </summary>
		public bool UpdateCb
		{
			get { return updateCb; }
			set { updateCb = value; }
		}

		/// <summary>
		/// Determines, if Cr value of filtered pixels should be updated.
		/// <b>True</b> by default.
		/// </summary>
		public bool UpdateCr
		{
			get { return updateCr; }
			set { updateCr = value; }
		}

		#endregion


		/// <summary>
		/// Initializes a new instance of the <see cref="YCbCrFiltering"/> class
		/// </summary>
		public YCbCrFiltering( ) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="YCbCrFiltering"/> class
		/// </summary>
		/// 
		/// <param name="yRange">Range of Y component</param>
		/// <param name="cbRange">Range of Cb component</param>
		/// <param name="crRange">Range of Cr component</param>
		/// 
		public YCbCrFiltering( DoubleRange yRange, DoubleRange cbRange, DoubleRange crRange )
		{
			this.yRange  = yRange;
			this.cbRange = cbRange;
			this.crRange = crRange;
		}


		/// <summary>
		/// Process the filter on the specified image
		/// </summary>
		/// 
		/// <param name="imageData">Image data</param>
		/// 
		protected override unsafe void ProcessFilter( BitmapData imageData )
		{
			int width	= imageData.Width;
			int height	= imageData.Height;
			int offset	= imageData.Stride - width * 3;

			RGB		rgb = new RGB( );
			YCbCr	ycbcr = new YCbCr( );

			bool updated;

			// do the job
			byte *ptr = (byte *) imageData.Scan0.ToPointer( );

			// for each row
			for ( int y = 0; y < height; y++ )
			{
				// for each pixel
				for ( int x = 0; x < width; x++, ptr += 3 )
				{
					updated		= false;
					rgb.Red		= ptr[RGB.R];
					rgb.Green	= ptr[RGB.G];
					rgb.Blue	= ptr[RGB.B];

					// convert to YCbCr
					BaseControls.ImageBox.Imaging.ColorConverter.RGB2YCbCr( rgb, ycbcr );

					// check YCbCr values
					if (
						( ycbcr.Y  >= yRange.Min  ) && ( ycbcr.Y  <= yRange.Max ) &&
						( ycbcr.Cb >= cbRange.Min ) && ( ycbcr.Cb <= cbRange.Max ) &&
						( ycbcr.Cr >= crRange.Min ) && ( ycbcr.Cr <= crRange.Max )
						)
					{
						if ( !fillOutsideRange )
						{
							if ( updateY  ) ycbcr.Y  = fillY;
							if ( updateCb ) ycbcr.Cb = fillCb;
							if ( updateCr ) ycbcr.Cr = fillCr;

							updated = true;
						}
					}
					else
					{
						if ( fillOutsideRange )
						{
							if ( updateY  ) ycbcr.Y  = fillY;
							if ( updateCb ) ycbcr.Cb = fillCb;
							if ( updateCr ) ycbcr.Cr = fillCr;

							updated = true;
						}
					}

					if ( updated )
					{
						// convert back to RGB
						BaseControls.ImageBox.Imaging.ColorConverter.YCbCr2RGB( ycbcr, rgb );

						ptr[RGB.R] = rgb.Red;
						ptr[RGB.G] = rgb.Green;
						ptr[RGB.B] = rgb.Blue;
					}
				}
				ptr += offset;
			}
		}
	}
}
