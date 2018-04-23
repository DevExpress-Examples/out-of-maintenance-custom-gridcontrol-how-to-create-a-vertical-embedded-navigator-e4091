Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Registrator
Imports VerticalDataNavigator.Navigator


Namespace VerticalDataNavigator

    <System.ComponentModel.DesignerCategory("")> _
    Public Class CustomGridControl
        Inherits GridControl

        Protected Overrides Function CreateEmbeddedNavigator() As ControlNavigator
            Dim nav As New ExtendedDataNavigator(Me)
            AddHandler nav.SizeChanged, AddressOf OnEmbeddedNavigator_SizeChanged
            Return nav
        End Function

        Protected Overrides Sub RegisterAvailableViewsCore(ByVal collection As InfoCollection)
            MyBase.RegisterAvailableViewsCore(collection)
            collection.Add(New CustomGridViewInfoRegistrator())
        End Sub

        Public Property EmbeddedNavigatorOrientation() As NavigatorOrientation
            Get
                Return (TryCast(EmbeddedNavigator, ExtendedDataNavigator)).NavigatorOrientation
            End Get
            Set(ByVal value As NavigatorOrientation)
                Dim customizableNavigator As ExtendedDataNavigator = TryCast(EmbeddedNavigator, ExtendedDataNavigator)

                If value <> customizableNavigator.NavigatorOrientation Then
                    customizableNavigator.NavigatorOrientation = value
                    Invalidate()
                End If
            End Set
        End Property
    End Class
End Namespace
