using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;

namespace DXGrid_ImplementingTemplateSelector {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            grid.DataSource = new ProductList();
        }
    }
    public class RowCellTemplateSelector : DataTemplateSelector {
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            GridCellData cellData = item as GridCellData;
            FrameworkElement presenter = container as FrameworkElement;
            if (cellData != null && presenter != null) {
                if (cellData.Column.FieldName != "UnitPrice")
                    return base.SelectTemplate(item, container);
                if(Convert.ToDouble(cellData.Value) > 20)
                    return RowCellTemplate1;
                else
                    return RowCellTemplate2;
            }
            return base.SelectTemplate(item, container);
        }
        public DataTemplate RowCellTemplate1 { get; set; }
        public DataTemplate RowCellTemplate2 { get; set; }
    }
}
