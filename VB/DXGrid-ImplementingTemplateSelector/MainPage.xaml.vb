Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Xpf.Grid

Namespace DXGrid_ImplementingTemplateSelector
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = New ProductList()
		End Sub
	End Class
	Public Class RowCellTemplateSelector
		Inherits DataTemplateSelector
		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
			Dim cellData As GridCellData = TryCast(item, GridCellData)
			Dim presenter As FrameworkElement = TryCast(container, FrameworkElement)
			If cellData IsNot Nothing AndAlso presenter IsNot Nothing Then
				If cellData.Column.FieldName <> "UnitPrice" Then
					Return MyBase.SelectTemplate(item, container)
				End If
				If Convert.ToDouble(cellData.Value) > 20 Then
					Return RowCellTemplate1
				Else
					Return RowCellTemplate2
				End If
			End If
			Return MyBase.SelectTemplate(item, container)
		End Function
		Private privateRowCellTemplate1 As DataTemplate
		Public Property RowCellTemplate1() As DataTemplate
			Get
				Return privateRowCellTemplate1
			End Get
			Set(ByVal value As DataTemplate)
				privateRowCellTemplate1 = value
			End Set
		End Property
		Private privateRowCellTemplate2 As DataTemplate
		Public Property RowCellTemplate2() As DataTemplate
			Get
				Return privateRowCellTemplate2
			End Get
			Set(ByVal value As DataTemplate)
				privateRowCellTemplate2 = value
			End Set
		End Property
	End Class
End Namespace
