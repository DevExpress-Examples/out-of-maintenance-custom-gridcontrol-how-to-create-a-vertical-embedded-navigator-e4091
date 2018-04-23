using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid;

namespace VerticalDataNavigator.Navigator
{
    public class CustomGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return "CustomGridView"; } }

        public override BaseView CreateView(GridControl grid)
        {
            return new CustomGridView(grid as GridControl);
        }

        public override BaseViewInfo CreateViewInfo(BaseView view)
        {
            return new CustomGridViewInfo(view as CustomGridView);
        }
    }
}
