using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace VerticalDataNavigator.Navigator
{
    [System.ComponentModel.DesignerCategory("")]
    public class ExtendedDataNavigator : GridControlNavigator
    {
        private NavigatorOrientation _NavigatorOrientation;
        private NavigatorButtonsTextLocation _PrevTextLocation;

        public ExtendedDataNavigator(GridControl control) : base(control) {
            _PrevTextLocation = this.TextLocation;
            NavigatorOrientation = NavigatorOrientation.Horizontal;
            
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public NavigatorOrientation NavigatorOrientation
        {
            get { return _NavigatorOrientation; }
            set 
            { 
                _NavigatorOrientation = value;
                OnOrientationChanged();
                ViewInfo.CalcViewInfo(
                    null, 
                    Control.MouseButtons, 
                    PointToClient(Control.MousePosition), 
                    ClientRectangle);
            }
        }

        void OnOrientationChanged() {
            if(NavigatorOrientation == NavigatorOrientation.Vertical) {
                _PrevTextLocation = this.TextLocation;
                this.TextLocation = NavigatorButtonsTextLocation.None;
                return;
            }
            this.TextLocation = _PrevTextLocation;
        }

        protected override NavigatorButtonsBase CreateButtons()
        { return new ExtendedDataNavigatorButtons(this); }

    }

    public enum NavigatorOrientation { Horizontal = 0, Vertical = 1 }

}
