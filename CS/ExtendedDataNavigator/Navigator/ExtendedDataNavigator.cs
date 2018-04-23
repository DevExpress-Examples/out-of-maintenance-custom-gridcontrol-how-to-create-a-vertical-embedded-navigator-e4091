using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System.ComponentModel;
using System.Windows.Forms;

namespace VerticalDataNavigator.Navigator
{
    [System.ComponentModel.DesignerCategory("")]
    public class ExtendedDataNavigator : ControlNavigator
    {
        private NavigatorOrientation _NavigatorOrientation;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public NavigatorOrientation NavigatorOrientation
        {
            get { return _NavigatorOrientation; }
            set 
            { 
                _NavigatorOrientation = value;
                ViewInfo.CalcViewInfo(
                    null, 
                    Control.MouseButtons, 
                    PointToClient(Control.MousePosition), 
                    ClientRectangle);
            }
        }

        public ExtendedDataNavigator()
        { NavigatorOrientation = NavigatorOrientation.Horizontal; }

        
        public ExtendedDataNavigator(GridControl control)
            : this()
        { NavigatableControl = control; }

        protected override NavigatorButtonsBase CreateButtons()
        { return new ExtendedDataNavigatorButtons(this); }

    }

    public enum NavigatorOrientation { Horizontal = 0, Vertical = 1 }

}
