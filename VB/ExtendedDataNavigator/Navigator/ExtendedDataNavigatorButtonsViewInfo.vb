Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraEditors.ViewInfo
Imports DevExpress.XtraEditors
Imports System.Drawing
Imports System.Collections

Namespace VerticalDataNavigator.Navigator
    Public Class ExtendedDataNavigatorButtonsViewInfo
        Inherits NavigatorButtonsViewInfo

        Public Sub New(ByVal buttons As NavigatorButtonsBase)
            MyBase.New(buttons)
        End Sub

        Public Overrides Sub CheckSize(ByRef size As Size)
            Dim cOwner As ExtendedDataNavigator = (TryCast(Buttons.Owner, ExtendedDataNavigator))
            If cOwner.NavigatorOrientation = NavigatorOrientation.Vertical Then
                Dim minWidth As Integer = 0
                Dim minHeight As Integer = 0
                Dim buttonList As ArrayList = CreateButtonList()

                Clear()
                Dim objectCollection As New NavigatorObjectViewInfoCollection()
                For i As Integer = 0 To buttonList.Count - 1
                    AddButtonViewInfo(TryCast(buttonList(i), NavigatorButtonBase), objectCollection, minWidth, minHeight)
                Next i

                AddTextViewInfo(Nothing, objectCollection, minWidth, minHeight)

                If Buttons.Owner.AutoSize Then
                    size.Height = minHeight
                    size.Width = minWidth
                Else
                    If size.Height < minHeight Then
                        size.Height = minHeight
                    End If
                    If size.Width < minWidth Then
                        size.Width = minWidth
                    End If
                End If

                Dim buttonSize As New Size(cOwner.Size.Width, cOwner.Size.Height \ objectCollection.Count)

                For i As Integer = 0 To objectCollection.Count - 1
                    Dim location As New Point(0, i * buttonSize.Height)
                    Dim button As New Rectangle(location,buttonSize)
                    objectCollection(i).Bounds = button
                Next i
            Else
                MyBase.CheckSize(size)
            End If
        End Sub

        Protected Overrides Sub AddButtonViewInfo(ByVal button As NavigatorButtonBase, ByVal objectCollection As NavigatorObjectViewInfoCollection, ByRef minWidth As Integer, ByRef minHeight As Integer)
            MyBase.AddButtonViewInfo(button, objectCollection, minWidth, minHeight)

            RotateButtonImages(button)
        End Sub

        Private Sub RotateButtonImages(ByVal button As NavigatorButtonBase)
            Dim cOwner As ExtendedDataNavigator = (TryCast(Buttons.Owner, ExtendedDataNavigator))

            Dim start As Integer
            If cOwner.NavigatorOrientation = NavigatorOrientation.Vertical Then
                start = 13
            Else
                start = 0
            End If

                Select Case button.ButtonType
                    Case NavigatorButtonType.Custom
                    Case NavigatorButtonType.First
                            button.ImageIndex = start
                            Exit Select
                    Case NavigatorButtonType.PrevPage
                            button.ImageIndex = start + 1
                            Exit Select
                    Case NavigatorButtonType.Prev
                            button.ImageIndex = start + 2
                            Exit Select
                    Case NavigatorButtonType.Next
                            button.ImageIndex = start + 3
                            Exit Select
                    Case NavigatorButtonType.NextPage
                            button.ImageIndex = start + 4
                            Exit Select
                    Case NavigatorButtonType.Last
                            button.ImageIndex = start + 5
                            Exit Select
                    Case NavigatorButtonType.Append

                    Case NavigatorButtonType.Remove

                    Case NavigatorButtonType.Edit

                    Case NavigatorButtonType.EndEdit

                    Case NavigatorButtonType.CancelEdit

                End Select
        End Sub

        Protected Overrides Sub ApplyViewInfoMinSize(ByVal viewInfo As NavigatorObjectViewInfo, ByRef minWidth As Integer, ByRef minHeight As Integer)
            Dim cOwner As ExtendedDataNavigator = (TryCast(Buttons.Owner, ExtendedDataNavigator))
            If (cOwner IsNot Nothing) AndAlso (cOwner.NavigatorOrientation = NavigatorOrientation.Vertical) Then
                Dim minSize As Size = viewInfo.MinSize

                If minSize.Width > minWidth Then
                    minWidth = minSize.Width
                End If

                minHeight += minSize.Height
            Else
                MyBase.ApplyViewInfoMinSize(viewInfo, minWidth, minHeight)
            End If
        End Sub

    End Class
End Namespace
