using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2D = SharpDX.Direct2D1;
using WIC = SharpDX.WIC;
using SharpDX;
using Seal.Images;
namespace Seal.Platform.Direct2D.Imaging
{
    class WicBitmapProvider :IBitmapProvider
    {
        public static Dictionary<string, D2D.Bitmap> Bitmaps = new Dictionary<string, D2D.Bitmap>();
        private D2D.RenderTarget target;
        private static D2D.Bitmap LoadFromFile(string filename,D2D.RenderTarget Direct2DTarget )
        {
            var factory = new WIC.ImagingFactory();
            // Decode image
            var decoder = new WIC.BitmapDecoder(factory, filename, WIC.DecodeOptions.CacheOnLoad);
            
            var frameDecode = decoder.GetFrame(0);
            var source = new WIC.BitmapSource(frameDecode.NativePointer);
            var fc = new WIC.FormatConverter(factory);
            fc.Initialize(
                source,
                SharpDX.WIC.PixelFormat.Format32bppPBGRA,
                SharpDX.WIC.BitmapDitherType.None,
                null,
                0.0f,
                SharpDX.WIC.BitmapPaletteType.Custom
            );
            double dpX = 96.0f;
            double dpY = 96.0f;
            fc.GetResolution(out dpX, out dpY);
            D2D.BitmapProperties props = new D2D.BitmapProperties(
                new SharpDX.Direct2D1.PixelFormat(SharpDX.DXGI.Format.B8G8R8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Premultiplied));
            WIC.Bitmap bmp = new WIC.Bitmap(factory, fc, WIC.BitmapCreateCacheOption.CacheOnLoad);
            // Формируем изображения
            var Direct2DBitmap = D2D.Bitmap.FromWicBitmap(Direct2DTarget,fc);
            // Cleanup
            factory.Dispose();
            decoder.Dispose();
            source.Dispose();
            fc.Dispose();
            return Direct2DBitmap;
        }
        public WicBitmapProvider(D2D.RenderTarget target)
        {
            this.target = target;
        }
        public IBitmap Get(string filename)
        {
            if(Bitmaps.ContainsKey(filename))
            {
                return new Bitmap(Bitmaps[filename]);
            }
            else
            {
                var bitmap = LoadFromFile(filename, target);
                Bitmaps.Add(filename, bitmap);
                return new Bitmap(bitmap);
            }
        }
    }
}
