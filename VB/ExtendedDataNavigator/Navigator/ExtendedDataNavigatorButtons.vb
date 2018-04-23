Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.ViewInfo

Namespace VerticalDataNavigator.Navigator
	Public Class ExtendedDataNavigatorButtons
		Inherits ControlNavigatorButtons

		Public Sub New(ByVal owner As INavigatorOwner)
			MyBase.New(owner)
		End Sub

		Protected Overrides Function CreateViewInfo() As NavigatorButtonsViewInfo
			Return New ExtendedDataNavigatorButtonsViewInfo(Me)
		End Function

	End Class
End Namespace
