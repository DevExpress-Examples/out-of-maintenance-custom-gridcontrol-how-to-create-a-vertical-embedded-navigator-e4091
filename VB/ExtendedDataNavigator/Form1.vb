Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports VerticalDataNavigator.Navigator

Namespace VerticalDataNavigator
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()

            customGridControl1.DataSource = CreateDataSet()
            customGridControl1.DataMember = "FirstTable"

        End Sub

        Private Function CreateDataSet() As DataSet
            Dim itsDataSet As DataSet

            Dim table As New DataTable("FirstTable")
            Dim column As DataColumn
            Dim row As DataRow

            column = New DataColumn()
            column.DataType = GetType(Integer)
            column.ColumnName = "number1"
            column.AutoIncrement = False
            column.Caption = "Number1"
            column.ReadOnly = False
            column.Unique = False

            table.Columns.Add(column)


            column = New DataColumn()
            column.DataType = GetType(Integer)
            column.ColumnName = "number2"
            column.AutoIncrement = False
            column.Caption = "Number2"
            column.ReadOnly = False
            column.Unique = False

            table.Columns.Add(column)

            column = New DataColumn()
            column.DataType = GetType(Integer)
            column.ColumnName = "number3"
            column.AutoIncrement = False
            column.Caption = "Number3"
            column.ReadOnly = False
            column.Unique = False

            table.Columns.Add(column)

            itsDataSet = New DataSet()
            itsDataSet.Tables.Add(table)

            For i As Integer = 0 To 1000
                row = table.NewRow()
                row("number1") = i
                row("number2") = 10 * i
                row("number3") = 100 * i
                table.Rows.Add(row)
            Next i

            Return itsDataSet
        End Function

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            customGridControl1.EmbeddedNavigatorOrientation = NavigatorOrientation.Vertical
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            customGridControl1.EmbeddedNavigatorOrientation = NavigatorOrientation.Horizontal
        End Sub

    End Class
End Namespace
