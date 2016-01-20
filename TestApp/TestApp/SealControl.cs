using System;
using System.Windows.Forms;
using Seal.Platform;
using Seal.Media;
using Seal.Geometries;
using Seal.Platform.Direct2D;
namespace TestApp
{
    public partial class SealControl : UserControl,IPlatformHandle
    {
        IEngine engine;
        IRenderTarget target;
        IBrush brush;
        IBrush brush1;
        PathGeometry p;
        Seal.Images.IBitmap bitmap;
        public SealControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserPaint, true);
            engine = new Engine();
            target = engine.CreateRenderTarget(this, this.Width, this.Height);
            var gm = engine.CreateGeometryManager();
            p = new PathGeometry(gm.CreatePath("M 100,200 C 200,100 100,100 100,100 C 100,200 200,200 200,200"));
            brush = target.CreateSolidColorBrush(Seal.Colors.Black);
            brush1 = target.CreateSolidColorBrush(Seal.Colors.Red);
            var provider = target.CreateBitmapProvider();
            //if (!DesignMode)
            //{
            //    OpenFileDialog ofd = new OpenFileDialog();
            //    if (ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        bitmap = provider.Get(ofd.FileName);
            //    }
            //}
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            using (var ctx = target.CreateDrawingContext())
            {
                ctx.BeginDraw();
                ctx.Clear(Seal.Colors.White);
               // ctx.DrawBitmap(bitmap);
               // ctx.DrawLine(new Seal.Location(100, 200), new Seal.Location(200, 100), brush1);
                ctx.DrawPath(p.Path, this.brush);
                
            };
        }

        public PlatformType Type
        {
            get { return PlatformType.D2D; }
        }

        private void SealControl_Resize(object sender, EventArgs e)
        {
            target.Resize(this.Width, this.Height);
        }
    }
}
