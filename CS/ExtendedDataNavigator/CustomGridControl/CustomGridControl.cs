using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Registrator;
using VerticalDataNavigator.Navigator;

    
namespace VerticalDataNavigator
{

    [System.ComponentModel.DesignerCategory("")]
    public class CustomGridControl : GridControl
    {

        protected override ControlNavigator CreateEmbeddedNavigator()
        {
            ExtendedDataNavigator nav = new ExtendedDataNavigator(this);
            nav.SizeChanged += OnEmbeddedNavigator_SizeChanged;
            return nav;
        }

        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CustomGridViewInfoRegistrator());
        }

        public NavigatorOrientation EmbeddedNavigatorOrientation
        {
            get { return (EmbeddedNavigator as ExtendedDataNavigator).NavigatorOrientation; }
            set
            {
                ExtendedDataNavigator customizableNavigator = EmbeddedNavigator as ExtendedDataNavigator;

                if (value != customizableNavigator.NavigatorOrientation)
                {
                    customizableNavigator.NavigatorOrientation = value;
                    Invalidate();
                }
            }
        }
    }
}
