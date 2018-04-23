Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Scrolling
Imports System.Drawing

Namespace VerticalDataNavigator
	<System.ComponentModel.DesignerCategory("")>
	Public Class CustomGridView
		Inherits GridView

		Public Sub New(ByVal ownerGrid As GridControl)
			MyBase.New(ownerGrid)
		End Sub
		Public Sub New()
			MyBase.New()
		End Sub
		Protected Overrides Function CreateScrollInfo() As ScrollInfo
			Return New CustomScrollInfo(Me)
		End Function

		Public ReadOnly Property VscrollRect() As Rectangle
			Get
				Return (TryCast(ScrollInfo, CustomScrollInfo)).GetVscrollRect()
			End Get
		End Property
		Public ReadOnly Property HscrollRect() As Rectangle
			Get
				Return ScrollInfo.HScrollRect
			End Get
		End Property
		Protected Overrides ReadOnly Property ViewName() As String
			Get
				Return "CustomGridView"
			End Get
		End Property
	End Class
End Namespace
