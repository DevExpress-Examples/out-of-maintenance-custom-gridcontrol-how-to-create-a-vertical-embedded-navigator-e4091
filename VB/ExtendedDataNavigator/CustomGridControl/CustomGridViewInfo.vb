Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System
Imports System.Drawing
Imports System.Linq
Imports VerticalDataNavigator.Navigator

Namespace VerticalDataNavigator
	Friend Class CustomGridViewInfo
		Inherits GridViewInfo

		Public Sub New(ByVal gridView As GridView)
			MyBase.New(gridView)
		End Sub
		Protected Overrides Function CalcClientRect() As Rectangle
			If IsBaseCalcClientRect() Then
				Dim r As New Rectangle(Bounds.X + 1, Bounds.Y + 1, Bounds.Width - 2, Bounds.Height - 2)

				Return r
			Else
				Return MyBase.CalcClientRect()
			End If
		End Function

		Private Function IsBaseCalcClientRect() As Boolean
			Return (View.GridControl.EmbeddedNavigator IsNot Nothing) AndAlso (View.GridControl.UseEmbeddedNavigator) AndAlso ((TryCast(View.GridControl.EmbeddedNavigator, ExtendedDataNavigator)).NavigatorOrientation = NavigatorOrientation.Vertical)
		End Function
	End Class
End Namespace
