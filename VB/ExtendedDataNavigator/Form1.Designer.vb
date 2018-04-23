' Developer Express Code Central Example:
' Custom GridControl - How  you  can create a vertical embedded Navigator
' 
' This example demonstrates how to create a custom GridControl that supports a
' vertical navigator.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4091

Namespace VerticalDataNavigator
    Partial Public Class Form1
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.button1 = New System.Windows.Forms.Button()
            Me.button2 = New System.Windows.Forms.Button()
            Me.customGridControl1 = New VerticalDataNavigator.CustomGridControl()
            Me.customGridView1 = New VerticalDataNavigator.CustomGridView()
            DirectCast(Me.customGridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.customGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' button1
            ' 
            Me.button1.Location = New System.Drawing.Point(0, 0)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(246, 33)
            Me.button1.TabIndex = 1
            Me.button1.Text = "Vertical navigation orientation"
            Me.button1.UseVisualStyleBackColor = True
            ' 
            ' button2
            ' 
            Me.button2.Location = New System.Drawing.Point(252, 0)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(232, 33)
            Me.button2.TabIndex = 2
            Me.button2.Text = "Horizontal navigation orientation"
            Me.button2.UseVisualStyleBackColor = True
            ' 
            ' customGridControl1
            ' 
            Me.customGridControl1.Dock = System.Windows.Forms.DockStyle.Fill
            ' 
            ' 
            ' 
            Me.customGridControl1.EmbeddedNavigator.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.customGridControl1.EmbeddedNavigator.Buttons.First.ImageIndex = 0
            Me.customGridControl1.EmbeddedNavigator.Buttons.Last.ImageIndex = 5
            Me.customGridControl1.EmbeddedNavigator.Buttons.Next.ImageIndex = 3
            Me.customGridControl1.EmbeddedNavigator.Buttons.NextPage.ImageIndex = 4
            Me.customGridControl1.EmbeddedNavigator.Buttons.Prev.ImageIndex = 2
            Me.customGridControl1.EmbeddedNavigator.Buttons.PrevPage.ImageIndex = 1
            Me.customGridControl1.EmbeddedNavigator.Location = New System.Drawing.Point(1, 588)
            Me.customGridControl1.EmbeddedNavigator.LookAndFeel.UseDefaultLookAndFeel = False
            Me.customGridControl1.EmbeddedNavigator.Name = ""
            Me.customGridControl1.EmbeddedNavigator.NavigatableControl = Me.customGridControl1
            Me.customGridControl1.EmbeddedNavigator.Size = New System.Drawing.Size(189, 19)
            Me.customGridControl1.EmbeddedNavigator.TabIndex = 0
            Me.customGridControl1.EmbeddedNavigatorOrientation = VerticalDataNavigator.Navigator.NavigatorOrientation.Horizontal
            Me.customGridControl1.Location = New System.Drawing.Point(0, 0)
            Me.customGridControl1.MainView = Me.customGridView1
            Me.customGridControl1.Name = "customGridControl1"
            Me.customGridControl1.Size = New System.Drawing.Size(600, 608)
            Me.customGridControl1.TabIndex = 3
            Me.customGridControl1.UseEmbeddedNavigator = True
            Me.customGridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() { Me.customGridView1})
            ' 
            ' customGridView1
            ' 
            Me.customGridView1.GridControl = Me.customGridControl1
            Me.customGridView1.Name = "customGridView1"
            Me.customGridView1.OptionsView.ColumnAutoWidth = False
            Me.customGridView1.Tag = ""
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(600, 608)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.customGridControl1)
            Me.Name = "Form1"
            Me.Text = "VerticallyDataNavigator"
            DirectCast(Me.customGridControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.customGridView1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents button1 As System.Windows.Forms.Button
        Private WithEvents button2 As System.Windows.Forms.Button
        Private customGridControl1 As CustomGridControl
        Private customGridView1 As CustomGridView














    End Class
End Namespace

