Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports System
Imports System.ComponentModel
Imports System.Linq
Imports System.Windows.Forms

Namespace VerticalDataNavigator.Navigator
	<System.ComponentModel.DesignerCategory("")>
	Public Class ExtendedDataNavigator
		Inherits GridControlNavigator

		Private _NavigatorOrientation As NavigatorOrientation
		Private _PrevTextLocation As NavigatorButtonsTextLocation

		Public Sub New(ByVal control As GridControl)
			MyBase.New(control)
			_PrevTextLocation = Me.TextLocation
			NavigatorOrientation = NavigatorOrientation.Horizontal

		End Sub

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(False)>
		Public Property NavigatorOrientation() As NavigatorOrientation
			Get
				Return _NavigatorOrientation
			End Get
			Set(ByVal value As NavigatorOrientation)
				_NavigatorOrientation = value
				OnOrientationChanged()
				ViewInfo.CalcViewInfo(Nothing, Control.MouseButtons, PointToClient(Control.MousePosition), ClientRectangle)
			End Set
		End Property

		Private Sub OnOrientationChanged()
			If NavigatorOrientation = NavigatorOrientation.Vertical Then
				_PrevTextLocation = Me.TextLocation
				Me.TextLocation = NavigatorButtonsTextLocation.None
				Return
			End If
			Me.TextLocation = _PrevTextLocation
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
