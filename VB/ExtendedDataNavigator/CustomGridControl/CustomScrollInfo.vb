Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Scrolling
Imports DevExpress.XtraGrid.Views.Base
Imports System.Drawing
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

                Dim hscrollRectFieldInfo As FieldInfo = Nothing
                Dim navigatorRectFieldInfo As FieldInfo = Nothing
                Dim vscrollRectFieldInfo As FieldInfo = Nothing
                GetReflectionFields(hscrollRectFieldInfo, navigatorRectFieldInfo, vscrollRectFieldInfo)

                Dim vscrollRect As Rectangle = Nothing
                Dim navigatorRect As Rectangle = Nothing
                Dim hscrollRect As Rectangle = Nothing

                CalcVerticalRects(vscrollRect, navigatorRect, hscrollRect)

                SetReflectionRectangles(hscrollRectFieldInfo, navigatorRectFieldInfo, vscrollRectFieldInfo, vscrollRect, navigatorRect, hscrollRect)
            Else
                MyBase.CalcRects()
            End If
        End Sub

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
            Dim hscrollRect As Rectangle = Rectangle.Empty
            If HScrollVisible Then
                hscrollRect.Size = New Size(ClientRect.Width - (If(VScrollVisible, vscrollRect.Width, 0)), ScrollSize)
                hscrollRect.Location = New Point(ClientRect.Left, ClientRect.Bottom - hscrollRect.Size.Height)

            End If
            Return hscrollRect
        End Function
        Public Function GetNavigatorRect() As Rectangle
            Dim navigatorRect As Rectangle = Rectangle.Empty
            If (Navigator IsNot Nothing) AndAlso IsVSizeEnough() Then
                navigatorRect.Size = Navigator.MinSize
                navigatorRect.Location = New Point(ClientRect.Right - navigatorRect.Width, ClientRect.Bottom - navigatorRect.Height - ScrollSize)
            End If
            Return navigatorRect
        End Function

        Public Function GetVscrollRect() As Rectangle
            VScrollVisible = True

            Dim vscrollRect As Rectangle = Rectangle.Empty
            If Navigator IsNot Nothing Then
                vscrollRect.Size = New Size(Navigator.MinSize.Width, ClientRect.Height - (If(IsVSizeEnough(), Navigator.MinSize.Height, 0)) - (If(HScrollVisible, ScrollSize, 0)))
                vscrollRect.Location = New Point(ClientRect.Right - vscrollRect.Size.Width, ClientRect.Top)
            End If
            Return vscrollRect
        End Function

        Private Function IsVSizeEnough() As Boolean
            Dim newVariable As Boolean = (Navigator.MinSize.Height < ClientRect.Height - ScrollSize)
            Return newVariable
        End Function

    End Class
End Namespace
