using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors;
using System.Drawing;
using System.Collections;

namespace VerticalDataNavigator.Navigator
{
    public class ExtendedDataNavigatorButtonsViewInfo : NavigatorButtonsViewInfo
    {
        public ExtendedDataNavigatorButtonsViewInfo(NavigatorButtonsBase buttons)
            : base(buttons) {}

        public override void CheckSize(ref Size size)
        {
            ExtendedDataNavigator cOwner = (Buttons.Owner as ExtendedDataNavigator);
            if (cOwner.NavigatorOrientation == NavigatorOrientation.Vertical)
            {
                int minWidth = 0;
                int minHeight = 0;
                ArrayList buttonList = CreateButtonList();
            
                Clear();
                NavigatorObjectViewInfoCollection objectCollection = new NavigatorObjectViewInfoCollection();
                for (int i = 0; i < buttonList.Count; i++)
                    AddButtonViewInfo(buttonList[i] as NavigatorButtonBase, objectCollection, ref minWidth, ref minHeight);

                AddTextViewInfo(null, objectCollection, ref minWidth, ref minHeight);

                if (Buttons.Owner.AutoSize)
                {
                    size.Height = minHeight;
                    size.Width = minWidth;
                }
                else
                {
                    if (size.Height < minHeight)
                        size.Height = minHeight;
                    if (size.Width < minWidth)
                        size.Width = minWidth;
                }

                Size buttonSize =
                    new Size(cOwner.Size.Width, cOwner.Size.Height / objectCollection.Count);

                for (int i = 0; i < objectCollection.Count; i++)
                {
                    Point location = new Point(0, i * buttonSize.Height);
                    Rectangle button = new Rectangle(location,buttonSize);
                    objectCollection[i].Bounds = button;
                }
            }
            else base.CheckSize(ref size);
        }

        protected override void AddButtonViewInfo(NavigatorButtonBase button, NavigatorObjectViewInfoCollection objectCollection,
            ref int minWidth, ref int minHeight)
        {
            base.AddButtonViewInfo( button, objectCollection, ref minWidth, ref minHeight);

            RotateButtonImages(button);
        }

        private void RotateButtonImages(NavigatorButtonBase button)
        {
            ExtendedDataNavigator cOwner = (Buttons.Owner as ExtendedDataNavigator);

            int start;
            if (cOwner.NavigatorOrientation == NavigatorOrientation.Vertical)
                start = 13;
            else start = 0;

                switch (button.ButtonType)
                {
                    case NavigatorButtonType.Custom:
                        break;
                    case NavigatorButtonType.First:
                        {
                            button.ImageIndex = start;
                            break;
                        }
                    case NavigatorButtonType.PrevPage:
                        {
                            button.ImageIndex = start + 1;
                            break;
                        }
                    case NavigatorButtonType.Prev:
                        {
                            button.ImageIndex = start + 2;
                            break;
                        }
                    case NavigatorButtonType.Next:
                        {
                            button.ImageIndex = start + 3;
                            break;
                        }
                    case NavigatorButtonType.NextPage:
                        {
                            button.ImageIndex = start + 4;
                            break;
                        }
                    case NavigatorButtonType.Last:
                        {
                            button.ImageIndex = start + 5;
                            break;
                        }
                    case NavigatorButtonType.Append:

                        break;
                    case NavigatorButtonType.Remove:

                        break;
                    case NavigatorButtonType.Edit:

                        break;
                    case NavigatorButtonType.EndEdit:

                        break;
                    case NavigatorButtonType.CancelEdit:

                        break;
                }
        }

        protected override void ApplyViewInfoMinSize(NavigatorObjectViewInfo viewInfo, ref int minWidth, ref int minHeight)
        {
            ExtendedDataNavigator cOwner = (Buttons.Owner as ExtendedDataNavigator);
            if ((cOwner != null) && (cOwner.NavigatorOrientation == NavigatorOrientation.Vertical))
            {
                Size minSize = viewInfo.MinSize;

                if (minSize.Width > minWidth)
                    minWidth = minSize.Width;

                minHeight += minSize.Height;
            }
            else base.ApplyViewInfoMinSize(viewInfo, ref minWidth, ref minHeight);
        }

    }
}
