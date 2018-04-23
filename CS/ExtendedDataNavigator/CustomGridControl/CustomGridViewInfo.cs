using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using VerticalDataNavigator.Navigator;

namespace VerticalDataNavigator
{
    class CustomGridViewInfo : GridViewInfo
    {
        public CustomGridViewInfo(GridView gridView) : base(gridView) { }
        protected override Rectangle CalcClientRect()
        {
            if (IsBaseCalcClientRect())
            {
                Rectangle r = new Rectangle(
                Bounds.X + 1,
                Bounds.Y + 1,
                Bounds.Width - 2,
                Bounds.Height - 2);

                CustomGridView cgv = (View as CustomGridView);

                r.Width -= cgv.VscrollRect.Width;
                r.Height -= cgv.HscrollRect.Height;
                return r;
            }
            else return base.CalcClientRect();
        }

        private bool IsBaseCalcClientRect()
        {
            return (View.GridControl.EmbeddedNavigator != null) 
                && (View.GridControl.UseEmbeddedNavigator) 
                && ((View.GridControl.EmbeddedNavigator as ExtendedDataNavigator)
                .NavigatorOrientation == NavigatorOrientation.Vertical);
        }
    }
}
