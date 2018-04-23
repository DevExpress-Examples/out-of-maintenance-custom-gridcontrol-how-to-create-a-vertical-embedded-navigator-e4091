using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.ViewInfo;

namespace VerticalDataNavigator.Navigator
{
    public class ExtendedDataNavigatorButtons : ControlNavigatorButtons
    {
        public ExtendedDataNavigatorButtons(INavigatorOwner owner)
            : base(owner) {}

        protected override NavigatorButtonsViewInfo CreateViewInfo()
        { return new ExtendedDataNavigatorButtonsViewInfo(this); }

    }
}
