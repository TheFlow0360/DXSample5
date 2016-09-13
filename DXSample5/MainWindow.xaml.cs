using System;
using System.Collections.Generic;
using System.Windows.Data;
using DevExpress.Data;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;

namespace DXSample5
{
    public partial class MainWindow : DXWindow
    {
        private List<DataRow> Data = new List<DataRow>()
        {
            new DataRow()
            {
                new DataField("Id", typeof(int), 0),
                new DataField("Text", typeof(string), "First Item"),
                new DataField("Option", typeof(bool), false),
                new DataField("DateTime", typeof(DateTime), DateTime.MinValue)
            },
            new DataRow()
            {
                new DataField("Id", typeof(int), 1),
                new DataField("Text", typeof(string), "Second Item"),
                new DataField("Option", typeof(bool), true),
                new DataField("DateTime", typeof(DateTime), DateTime.MaxValue)
            },
            new DataRow()
            {
                new DataField("Id", typeof(int), 2),
                new DataField("Text", typeof(string), "Third Item"),
                new DataField("Option", typeof(bool), false),
                new DataField("DateTime", typeof(DateTime), DateTime.Now)
            },
            new DataRow()
            {
                new DataField("Id", typeof(int), 3),
                new DataField("Text", typeof(string), "Forth Item"),
                new DataField("Option", typeof(bool), true),
                new DataField("DateTime", typeof(DateTime), DateTime.Today)
            },
            new DataRow()
            {
                new DataField("Id", typeof(int), 4),
                new DataField("Text", typeof(string), "Fifth Item"),
                new DataField("Option", typeof(bool), false),
                new DataField("DateTime", typeof(DateTime), DateTime.UtcNow)
            }
        };

        public MainWindow()
        {
            InitializeComponent();
            CreateColumns();
            Grid.ItemsSource = Data;
        }

        private void CreateColumns()
        {
            Grid.Columns.Add(CreateColumn("Id", typeof(int)));
            Grid.Columns.Add(CreateColumn("Text", typeof(string)));
            Grid.Columns.Add(CreateColumn("Option", typeof(bool)));
            Grid.Columns.Add(CreateColumn("DateTime", typeof(DateTime)));
        }

        private GridColumn CreateColumn(string name, Type type)
        {
            return new GridColumn()
            {
                Header = "name",
                Binding = new Binding("[" + name + "]"),
                UnboundExpression = "[" + name + "]",
                UnboundType = this.GetDevExpColumnType(type)
            };
        }

        private UnboundColumnType GetDevExpColumnType(Type columnType)
        {
            System.TypeCode typeCode = Type.GetTypeCode(columnType);
            switch (typeCode)
            {
                case TypeCode.String:
                case TypeCode.Char:
                    return UnboundColumnType.String;
                case TypeCode.Boolean:
                    return UnboundColumnType.Boolean;
                case TypeCode.DateTime:
                    return UnboundColumnType.DateTime;
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                    return UnboundColumnType.Integer;
                case TypeCode.Single:
                case TypeCode.Decimal:
                case TypeCode.Double:
                    return UnboundColumnType.Decimal;
                default:
                    return UnboundColumnType.Object;
            }
        }
    }
}
