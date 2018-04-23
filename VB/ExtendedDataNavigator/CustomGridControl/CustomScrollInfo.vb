Imports DevExpress.XtraGrid.Scrolling
Imports DevExpress.XtraGrid.Views.Base
Imports System
Imports System.Drawing
Imports System.Linq
Imports System.Reflection
Imports VerticalDataNavigator.Navigator

Namespace VerticalDataNavigator
	Public Class CustomScrollInfo
		Inherits ScrollInfo

		Public Sub New(ByVal view As BaseView)
			MyBase.New(view)
		End Sub
		Protected Overrides Sub CalcRects()
			If (Navigator IsNot Nothing) AndAlso ((TryCast(Navigator, ExtendedDataNavigator)).NavigatorOrientation = NavigatorOrientation.Vertical) Then

				Dim hscrollRectFieldInfo As FieldInfo
				Dim navigatorRectFieldInfo As FieldInfo
				Dim vscrollRectFieldInfo As FieldInfo
				GetReflectionFields(hscrollRectFieldInfo, navigatorRectFieldInfo, vscrollRectFieldInfo)

'INSTANT VB NOTE: The variable vscrollRect was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim vscrollRect_Renamed As Rectangle
'INSTANT VB NOTE: The variable navigatorRect was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim navigatorRect_Renamed As Rectangle
'INSTANT VB NOTE: The variable hscrollRect was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim hscrollRect_Renamed As Rectangle

				CalcVerticalRects(vscrollRect_Renamed, navigatorRect_Renamed, hscrollRect_Renamed)

				SetReflectionRectangles(hscrollRectFieldInfo, navigatorRectFieldInfo, vscrollRectFieldInfo, vscrollRect_Renamed, navigatorRect_Renamed, hscrollRect_Renamed)
			Else
				MyBase.CalcRects()
			End If
		End Sub

		Public Overrides ReadOnly Property HScrollSize() As Integer
			Get
				If (TryCast(View.GridControl.EmbeddedNavigator, ExtendedDataNavigator)).NavigatorOrientation = NavigatorOrientation.Vertical Then
					Return (TryCast(View, CustomGridView)).HscrollRect.Height
				Else
					Return MyBase.HScrollSize
				End If
			End Get
		End Property

		Public ReadOnly Property ScrollSize() As Integer
			Get
				Return Me.VScrollSize
			End Get
		End Property

		Private Sub GetReflectionFields(ByRef hscrollRectFieldInfo As FieldInfo, ByRef navigatorRectFieldInfo As FieldInfo, ByRef vscrollRectFieldInfo As FieldInfo)
			Dim itsType As Type = GetType(ScrollInfo)

			Dim si As ScrollInfo = Me

			hscrollRectFieldInfo = itsType.GetField("hscrollRect", BindingFlags.NonPublic Or BindingFlags.Instance)

			navigatorRectFieldInfo = itsType.GetField("navigatorRect", BindingFlags.NonPublic Or BindingFlags.Instance)

			vscrollRectFieldInfo = itsType.GetField("vscrollRect", BindingFlags.NonPublic Or BindingFlags.Instance)
		End Sub

		Private Sub CalcVerticalRects(ByRef vscrollRect As Rectangle, ByRef navigatorRect As Rectangle, ByRef hscrollRect As Rectangle)
			vscrollRect = GetVscrollRect()

			navigatorRect = GetNavigatorRect()

			hscrollRect = GetHscrollRect(vscrollRect)
		End Sub

		Private Sub SetReflectionRectangles(ByVal hscrollRectFieldInfo As FieldInfo, ByVal navigatorRectFieldInfo As FieldInfo, ByVal vscrollRectFieldInfo As FieldInfo, ByRef vscrollRect As Rectangle, ByRef navigatorRect As Rectangle, ByRef hscrollRect As Rectangle)
			vscrollRectFieldInfo.SetValue(Me, vscrollRect)
			navigatorRectFieldInfo.SetValue(Me, navigatorRect)
			hscrollRectFieldInfo.SetValue(Me, hscrollRect)
		End Sub

		Public Function GetHscrollRect(ByVal vscrollRect As Rectangle) As Rectangle
'INSTANT VB NOTE: The variable hscrollRect was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim hscrollRect_Renamed As Rectangle = Rectangle.Empty
			If HScrollVisible Then
				hscrollRect_Renamed.Size = New Size(ClientRect.Width - (If(VScrollVisible, vscrollRect.Width, 0)), ScrollSize)
				hscrollRect_Renamed.Location = New Point(ClientRect.Left, ClientRect.Bottom - hscrollRect_Renamed.Size.Height)

			End If
			Return hscrollRect_Renamed
		End Function
		Public Function GetNavigatorRect() As Rectangle
'INSTANT VB NOTE: The variable navigatorRect was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim navigatorRect_Renamed As Rectangle = Rectangle.Empty
			If (Navigator IsNot Nothing) AndAlso IsVSizeEnough() Then
				navigatorRect_Renamed.Size = Navigator.MinSize
				navigatorRect_Renamed.Location = New Point(ClientRect.Right - navigatorRect_Renamed.Width, ClientRect.Bottom - navigatorRect_Renamed.Height - ScrollSize)
			End If
			Return navigatorRect_Renamed
		End Function

		Public Function GetVscrollRect() As Rectangle
			VScrollVisible = True

'INSTANT VB NOTE: The variable vscrollRect was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim vscrollRect_Renamed As Rectangle = Rectangle.Empty
			If Navigator IsNot Nothing Then
				vscrollRect_Renamed.Size = New Size(Navigator.MinSize.Width, ClientRect.Height - (If(IsVSizeEnough(), Navigator.MinSize.Height, 0)) - (If(HScrollVisible, ScrollSize, 0)))
				vscrollRect_Renamed.Location = New Point(ClientRect.Right - vscrollRect_Renamed.Size.Width, ClientRect.Top)
			End If
			Return vscrollRect_Renamed
		End Function

		Private Function IsVSizeEnough() As Boolean
			Dim newVariable As Boolean = (Navigator.MinSize.Height < ClientRect.Height - ScrollSize)
			Return newVariable
		End Function

	End Class
End Namespace
