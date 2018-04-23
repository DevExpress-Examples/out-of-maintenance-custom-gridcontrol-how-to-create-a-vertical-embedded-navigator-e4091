using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Scrolling;
using System.Drawing;

namespace VerticalDataNavigator
{
    [System.ComponentModel.DesignerCategory("")]
    public class CustomGridView : GridView
    {
        public CustomGridView(GridControl ownerGrid)
            : base(ownerGrid) { }
        public CustomGridView() : base() { }
        protected override ScrollInfo CreateScrollInfo()
        { return new CustomScrollInfo(this); }

        public Rectangle VscrollRect
        {
            get { return (ScrollInfo as CustomScrollInfo).GetVscrollRect(); }
        }
        public Rectangle HscrollRect
        {
            get { return ScrollInfo.HScrollRect; }
        }
        protected override string ViewName
        {
            get { return "CustomGridView"; }
        }
    }
}
