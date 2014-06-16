using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

namespace Comum.Framework.Relatorios
{
    class TableRdlGenerator
    {
        private List<string> m_fields;
        private List<string> m_headers;
        private List<double> m_widths;
        private const double widthGrid = 20;

        public List<string> Fields
        {
            get { return m_fields; }
            set { m_fields = value; }
        }

        public List<string> Headers
        {
            get { return m_headers; }
            set { m_headers = value; }
        }

        public List<double> Widths
        {
            get { return m_widths; }
            set { m_widths = value; }
        }

        private void CalculateWitdhs()
        {
            for (int i = 0; i < m_widths.Count; i++)
                m_widths[i] = Math.Round(widthGrid * (m_widths[i] / 13.6) / 100);

            double sum = this.RetornarSoma(m_widths);

            if (sum > widthGrid)
            {
                //logica para diminuir o tamanho das colunas.
                double widthMinus = sum - widthGrid;

                for (int i = 0; i < m_widths.Count; i++)
                {
                    if (this.RetornarSoma(m_widths) > widthGrid)
                        m_widths[i] = Math.Round(m_widths[i] - widthMinus);
                }
            }
            else
            {
                if (widthGrid > sum)
                {
                    //logica para aumentar o tamanho das colunas.
                    double widthPlus = (widthGrid - sum) / m_widths.Count;

                    for (int i = 0; i < m_widths.Count; i++)
                    {
                        double sumAct = this.RetornarSoma(m_widths);

                        if (sumAct + widthPlus < widthGrid)
                            m_widths[i] = Math.Round(m_widths[i] + widthPlus);
                        else
                            m_widths[i] = Math.Round(m_widths[i] + (widthGrid - sumAct));

                        //Se for o ultimo para fechar 20
                        if (i == m_fields.Count - 1)
                        {
                            sumAct = this.RetornarSoma(m_widths);
                            m_widths[i] = m_widths[i] + (widthGrid - sumAct);
                        }
                    }
                }
            }
        }

        private double RetornarSoma(List<double> widths)
        {
            double sum = 0.0;

            foreach (double width in widths)
                sum += width;

            return sum;
        }

        public TableType CreateTable()
        {
            TableType table = new TableType();
            this.CalculateWitdhs();
            table.Name = "Table1";
            table.Items = new object[]
                {
                    CreateTableColumns(),
                    CreateHeader(),
                    CreateDetails(),
                    widthGrid.ToString() + "cm",
                };
            table.ItemsElementName = new ItemsChoiceType21[]
                {
                    ItemsChoiceType21.TableColumns,
                    ItemsChoiceType21.Header,
                    ItemsChoiceType21.Details,
                    ItemsChoiceType21.Width,
                };

            
            return table;
        }

        private HeaderType CreateHeader()
        {
            HeaderType header = new HeaderType();
            header.Items = new object[]
                {
                    CreateHeaderTableRows(),
                };
            header.ItemsElementName = new ItemsChoiceType20[]
                {
                    ItemsChoiceType20.TableRows,
                };
            return header;
        }

        private TableRowsType CreateHeaderTableRows()
        {
            TableRowsType headerTableRows = new TableRowsType();
            headerTableRows.TableRow = new TableRowType[] { CreateHeaderTableRow() };
            return headerTableRows;
        }

        private TableRowType CreateHeaderTableRow()
        {
            TableRowType headerTableRow = new TableRowType();
            headerTableRow.Items = new object[] { CreateHeaderTableCells(), "0.25in" };
            return headerTableRow;
        }

        private TableCellsType CreateHeaderTableCells()
        {
            TableCellsType headerTableCells = new TableCellsType();
            headerTableCells.TableCell = new TableCellType[m_headers.Count];
            for (int i = 0; i < m_headers.Count; i++)
            {
                headerTableCells.TableCell[i] = CreateHeaderTableCell(m_headers[i]);
            }
            return headerTableCells;
        }

        private TableCellType CreateHeaderTableCell(string fieldName)
        {
            TableCellType headerTableCell = new TableCellType();
            headerTableCell.Items = new object[] { CreateHeaderTableCellReportItems(fieldName) };
            return headerTableCell;
        }

        private ReportItemsType CreateHeaderTableCellReportItems(string fieldName)
        {
            ReportItemsType headerTableCellReportItems = new ReportItemsType();
            headerTableCellReportItems.Items = new object[] { CreateHeaderTableCellTextbox(fieldName) };
            return headerTableCellReportItems;
        }

        private TextboxType CreateHeaderTableCellTextbox(string fieldName)
        {
            TextboxType headerTableCellTextbox = new TextboxType();
            headerTableCellTextbox.Name = fieldName.Replace(" ", "") + "_Header";
            headerTableCellTextbox.Items = new object[] 
                {
                    fieldName,
                    CreateHeaderTableCellTextboxStyle(),
                    true,
                };
            headerTableCellTextbox.ItemsElementName = new ItemsChoiceType14[] 
                {
                    ItemsChoiceType14.Value,
                    ItemsChoiceType14.Style,
                    ItemsChoiceType14.CanGrow,
                };
            return headerTableCellTextbox;
        }

        private StyleType CreateHeaderTableCellTextboxStyle()
        {
            //borderColor
            BorderColorStyleWidthType borderColor = new BorderColorStyleWidthType();
            borderColor.Items = new object[]
                {
                    "Black"
                };
            borderColor.ItemsElementName = new ItemsChoiceType3[] 
                {
                    ItemsChoiceType3.Default
                };

            //borderStyle
            BorderColorStyleWidthType borderStyle = new BorderColorStyleWidthType();
            borderStyle.Items = new object[]
                {
                    "Solid"
                };
            borderStyle.ItemsElementName = new ItemsChoiceType3[] 
                {
                    ItemsChoiceType3.Default
                };

            //borderStyle
            BorderColorStyleWidthType borderWidth = new BorderColorStyleWidthType();
            borderWidth.Items = new object[]
                {
                    "1pt"
                };
            borderWidth.ItemsElementName = new ItemsChoiceType3[] 
                {
                    ItemsChoiceType3.Default
                };

            StyleType headerTableCellTextboxStyle = new StyleType();
            headerTableCellTextboxStyle.Items = new object[]
                {
                    "700",
                    "12pt",
                    borderColor,
                    borderStyle,
                    borderWidth,
                    "2pt",
                    "2pt",
                    "2pt",
                    "2pt"
                };
            headerTableCellTextboxStyle.ItemsElementName = new ItemsChoiceType5[]
                {
                    ItemsChoiceType5.FontWeight,
                    ItemsChoiceType5.FontSize,
                    ItemsChoiceType5.BorderColor,
                    ItemsChoiceType5.BorderStyle,
                    ItemsChoiceType5.BorderWidth,
                    ItemsChoiceType5.PaddingBottom,
                    ItemsChoiceType5.PaddingLeft,
                    ItemsChoiceType5.PaddingRight,
                    ItemsChoiceType5.PaddingTop,
                };
            return headerTableCellTextboxStyle;
        }

        private DetailsType CreateDetails()
        {
            DetailsType details = new DetailsType();
            details.Items = new object[] { CreateTableRows() };
            return details;
        }

        private TableRowsType CreateTableRows()
        {
            TableRowsType tableRows = new TableRowsType();
            tableRows.TableRow = new TableRowType[] { CreateTableRow() };
            return tableRows;
        }

        private TableRowType CreateTableRow()
        {
            TableRowType tableRow = new TableRowType();
            tableRow.Items = new object[] { CreateTableCells(), "0.25in" };
            return tableRow;
        }

        private TableCellsType CreateTableCells()
        {
            TableCellsType tableCells = new TableCellsType();
            tableCells.TableCell = new TableCellType[m_fields.Count];
            for (int i = 0; i < m_fields.Count; i++)
            {
                tableCells.TableCell[i] = CreateTableCell(m_fields[i].Replace(".", "_"));
            }
            return tableCells;
        }

        private TableCellType CreateTableCell(string fieldName)
        {
            TableCellType tableCell = new TableCellType();
            tableCell.Items = new object[] { CreateTableCellReportItems(fieldName) };
            return tableCell;
        }

        private ReportItemsType CreateTableCellReportItems(string fieldName)
        {
            ReportItemsType reportItems = new ReportItemsType();
            reportItems.Items = new object[] { CreateTableCellTextbox(fieldName) };
            return reportItems;
        }

        private TextboxType CreateTableCellTextbox(string fieldName)
        {
            TextboxType textbox = new TextboxType();
            textbox.Name = fieldName;
            textbox.Items = new object[] 
                {
                    "=Fields!" + fieldName + ".Value",
                    CreateTableCellTextboxStyle(),
                    true,
                };
            textbox.ItemsElementName = new ItemsChoiceType14[] 
                {
                    ItemsChoiceType14.Value,
                    ItemsChoiceType14.Style,
                    ItemsChoiceType14.CanGrow,
                };
            return textbox;
        }

        private StyleType CreateTableCellTextboxStyle()
        {
            StyleType style = new StyleType();

            //borderColor
            BorderColorStyleWidthType borderColor = new BorderColorStyleWidthType();
            borderColor.Items = new object[]
                {
                    "Black"
                };
            borderColor.ItemsElementName = new ItemsChoiceType3[] 
                {
                    ItemsChoiceType3.Default
                };

            //borderStyle
            BorderColorStyleWidthType borderStyle = new BorderColorStyleWidthType();
            borderStyle.Items = new object[]
                {
                    "Solid"
                };
            borderStyle.ItemsElementName = new ItemsChoiceType3[] 
                {
                    ItemsChoiceType3.Default
                };

            //borderStyle
            BorderColorStyleWidthType borderWidth = new BorderColorStyleWidthType();
            borderWidth.Items = new object[]
                {
                    "1pt"
                };
            borderWidth.ItemsElementName = new ItemsChoiceType3[] 
                {
                    ItemsChoiceType3.Default
                };

            style.Items = new object[]
                {
                    "=iif(RowNumber(Nothing) mod 2, \"AliceBlue\", \"White\")",
                    "Left",
                    borderColor,
                    borderStyle,
                    borderWidth,
                    "2pt",
                    "2pt",
                    "2pt",
                    "2pt"
                };
            style.ItemsElementName = new ItemsChoiceType5[]
                {
                    ItemsChoiceType5.BackgroundColor,
                    ItemsChoiceType5.TextAlign,
                    ItemsChoiceType5.BorderColor,
                    ItemsChoiceType5.BorderStyle,
                    ItemsChoiceType5.BorderWidth,
                    ItemsChoiceType5.PaddingBottom,
                    ItemsChoiceType5.PaddingLeft,
                    ItemsChoiceType5.PaddingRight,
                    ItemsChoiceType5.PaddingTop
                };
            return style;
        }

        private TableColumnsType CreateTableColumns()
        {
            TableColumnsType tableColumns = new TableColumnsType();
            tableColumns.TableColumn = new TableColumnType[m_headers.Count];
            for (int i = 0; i < m_headers.Count; i++)
            {
                tableColumns.TableColumn[i] = CreateTableColumn(m_widths[i]);
            }
            return tableColumns;
        }

        private TableColumnType CreateTableColumn(double width)
        {
            TableColumnType tableColumn = new TableColumnType();
            tableColumn.Items = new object[] { width.ToString().Replace(".", ",") + "cm" };
            return tableColumn;
        }

        private string GetColumnWidth(double width)
        {
            int numberColumns = m_widths.Count;

            //double widthColumn = width * 100 / widthGrid;

            double widthColumn = Math.Round(widthGrid * (width / 13.6) / 100);
            //widthColumn = 
            
            return widthColumn.ToString() + "cm";
        }
    }
}
