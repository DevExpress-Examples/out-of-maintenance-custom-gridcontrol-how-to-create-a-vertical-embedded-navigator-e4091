Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace VerticalDataNavigator.Navigator
    <System.ComponentModel.DesignerCategory("")> _
    Public Class ExtendedDataNavigator
        Inherits ControlNavigator

        Private _NavigatorOrientation As NavigatorOrientation

        <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)> _
        Public Property NavigatorOrientation() As NavigatorOrientation
            Get
                Return _NavigatorOrientation
            End Get
            Set(ByVal value As NavigatorOrientation)
                _NavigatorOrientation = value
                ViewInfo.CalcViewInfo(Nothing, Control.MouseButtons, PointToClient(Control.MousePosition), ClientRectangle)
            End Set
        End Property

        Public Sub New()
            NavigatorOrientation = NavigatorOrientation.Horizontal
        End Sub


        Public Sub New(ByVal control As GridControl)
            Me.New()
        NavigatableControl = control
        End Sub

        Protected Overrides Function CreateButtons() As NavigatorButtonsBase
            Return New ExtendedDataNavigatorButtons(Me)
        End Function

    End Class

    Public Enum NavigatorOrientation
        Horizontal = 0
        Vertical = 1
    End Enum

End Namespace
