using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Seal;
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
        PathGeometry p;
        public SealControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.ResizeRedraw | ControlStyles.Selectable | ControlStyles.UserPaint, true);
            engine = new Engine();
            target = engine.CreateRenderTarget(this, this.Width, this.Height);
            var gm = engine.CreateGeometryManager();
            p = new PathGeometry(gm.CreatePath("M 10,10 C 300,200 50,5 60,40 C 10,10 200,160 100,110"));
            brush = target.CreateSolidColorBrush(Seal.Colors.DarkGoldenrod);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            using (var ctx = target.CreateDrawingContext())
            {
                ctx.BeginDraw();
                ctx.Clear(Seal.Colors.White);
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
