using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Scrolling;
using DevExpress.XtraGrid.Views.Base;
using System.Drawing;
using System.Reflection;
using VerticalDataNavigator.Navigator;

namespace VerticalDataNavigator
{
    public class CustomScrollInfo : ScrollInfo
    {
        public CustomScrollInfo(BaseView view)
            : base(view) { }
        protected override void CalcRects()
        {
            if ((Navigator != null) && ((Navigator as ExtendedDataNavigator).NavigatorOrientation == NavigatorOrientation.Vertical))
            {

                FieldInfo hscrollRectFieldInfo;
                FieldInfo navigatorRectFieldInfo;
                FieldInfo vscrollRectFieldInfo;
                GetReflectionFields(out hscrollRectFieldInfo, out navigatorRectFieldInfo, out vscrollRectFieldInfo);

                Rectangle vscrollRect;
                Rectangle navigatorRect;
                Rectangle hscrollRect;

                CalcVerticalRects(out vscrollRect, out navigatorRect, out hscrollRect);

                SetReflectionRectangles(
                    hscrollRectFieldInfo, navigatorRectFieldInfo, vscrollRectFieldInfo, 
                    ref vscrollRect, ref navigatorRect, ref hscrollRect);
            }
            else base.CalcRects();
        }

        public int ScrollSize { get { return this.VScrollSize; } }

        private void GetReflectionFields(out FieldInfo hscrollRectFieldInfo, out FieldInfo navigatorRectFieldInfo, out FieldInfo vscrollRectFieldInfo)
        {
            Type itsType = typeof(ScrollInfo);

            ScrollInfo si = this;

            hscrollRectFieldInfo = itsType.GetField(
                "hscrollRect",
                BindingFlags.NonPublic | BindingFlags.Instance);

            navigatorRectFieldInfo = itsType.GetField(
                "navigatorRect",
                BindingFlags.NonPublic | BindingFlags.Instance);

            vscrollRectFieldInfo = itsType.GetField(
                "vscrollRect",
                BindingFlags.NonPublic | BindingFlags.Instance);
        }

        private void CalcVerticalRects(out Rectangle vscrollRect, out Rectangle navigatorRect, out Rectangle hscrollRect)
        {
            vscrollRect = GetVscrollRect();

            navigatorRect = GetNavigatorRect();

            hscrollRect = GetHscrollRect(vscrollRect);
        }

        private void SetReflectionRectangles(
            FieldInfo hscrollRectFieldInfo, FieldInfo navigatorRectFieldInfo, FieldInfo vscrollRectFieldInfo, 
            ref Rectangle vscrollRect, ref Rectangle navigatorRect, ref Rectangle hscrollRect)
        {
            vscrollRectFieldInfo.SetValue(this, vscrollRect);
            navigatorRectFieldInfo.SetValue(this, navigatorRect);
            hscrollRectFieldInfo.SetValue(this, hscrollRect);
        }

        public Rectangle GetHscrollRect(Rectangle vscrollRect)
        {
            Rectangle hscrollRect = Rectangle.Empty;
            if (HScrollVisible)
            {
                hscrollRect.Size = new Size(ClientRect.Width - (VScrollVisible ? vscrollRect.Width : 0), ScrollSize);
                hscrollRect.Location = new Point(ClientRect.Left, ClientRect.Bottom - hscrollRect.Size.Height);

            }
            return hscrollRect;
        }
        public Rectangle GetNavigatorRect()
        {
            Rectangle navigatorRect = Rectangle.Empty;
            if ((Navigator != null) && IsVSizeEnough())
            {
                navigatorRect.Size = Navigator.MinSize;
                navigatorRect.Location = new Point(
                ClientRect.Right - navigatorRect.Width,
                ClientRect.Bottom - navigatorRect.Height - ScrollSize);
            }
            return navigatorRect;
        }

        public Rectangle GetVscrollRect()
        {
            VScrollVisible = true;

            Rectangle vscrollRect = Rectangle.Empty;
            if (Navigator != null)
            {
                vscrollRect.Size = new Size(
                    Navigator.MinSize.Width,
                    ClientRect.Height
                    - ((IsVSizeEnough()) ? Navigator.MinSize.Height : 0)
                    - (HScrollVisible ? ScrollSize : 0));
                vscrollRect.Location = new Point(
                    ClientRect.Right - vscrollRect.Size.Width,
                    ClientRect.Top);
            }
            return vscrollRect;
        }

        private bool IsVSizeEnough()
        {
            bool newVariable = (Navigator.MinSize.Height < ClientRect.Height - ScrollSize);
            return newVariable;
        }
    
    }
}
