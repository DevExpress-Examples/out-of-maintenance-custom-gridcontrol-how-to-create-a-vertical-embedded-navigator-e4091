using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using VerticalDataNavigator.Navigator;

namespace VerticalDataNavigator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            customGridControl1.DataSource = CreateDataSet();
            customGridControl1.DataMember = "FirstTable";

        }

        private DataSet CreateDataSet()
        {
            DataSet itsDataSet;

            DataTable table = new DataTable("FirstTable");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "number1";
            column.AutoIncrement = false;
            column.Caption = "Number1";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);


            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "number2";
            column.AutoIncrement = false;
            column.Caption = "Number2";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = typeof(int);
            column.ColumnName = "number3";
            column.AutoIncrement = false;
            column.Caption = "Number3";
            column.ReadOnly = false;
            column.Unique = false;

            table.Columns.Add(column);

            itsDataSet = new DataSet();
            itsDataSet.Tables.Add(table);

            for (int i = 0; i <= 1000; i++)
            {
                row = table.NewRow();
                row["number1"] = i;
                row["number2"] = 10 * i;
                row["number3"] = 100 * i;
                table.Rows.Add(row);
            }

            return itsDataSet;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customGridControl1.EmbeddedNavigatorOrientation =
                NavigatorOrientation.Vertical;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            customGridControl1.EmbeddedNavigatorOrientation =
                NavigatorOrientation.Horizontal;
        }

    }
}
