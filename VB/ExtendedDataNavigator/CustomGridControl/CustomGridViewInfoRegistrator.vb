Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Registrator
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid

Namespace VerticalDataNavigator.Navigator
    Public Class CustomGridViewInfoRegistrator
        Inherits GridInfoRegistrator

        Public Overrides ReadOnly Property ViewName() As String
            Get
                Return "CustomGridView"
            End Get
        End Property

        Public Overrides Function CreateView(ByVal grid As GridControl) As BaseView
            Return New CustomGridView(TryCast(grid, GridControl))
        End Function

        Public Overrides Function CreateViewInfo(ByVal view As BaseView) As BaseViewInfo
            Return New CustomGridViewInfo(TryCast(view, CustomGridView))
        End Function
    End Class
End Namespace
