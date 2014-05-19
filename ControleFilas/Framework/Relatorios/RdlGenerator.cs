using System;
using System.Data;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Microsoft.Reporting.WebForms;

namespace Ecosistemas.Framework.Relatorios
{
    public class RdlGenerator
    {
        private List<string> m_allFields;
        private List<string> m_selectedFields;
        private List<string> m_headers;
        private List<double> m_widths;
        private List<ReportParameter> m_reportParameters;
        private string m_screenTitle;
        private string m_userName;

        public string ScreenTitle
        {
            get { return m_screenTitle; }
            set { m_screenTitle = value; }
        }

        public List<string> AllFields
        {
            get { return m_allFields; }
            set { m_allFields = value; }
        }

        public List<string> SelectedFields
        {
            get { return m_selectedFields; }
            set { m_selectedFields = value; }
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

        public RdlGenerator(string screenTitle, string userName)
        {
            this.m_reportParameters = new List<ReportParameter>();
            this.m_screenTitle = screenTitle;
            this.m_userName = userName;
        }

        public List<ReportParameter> ReportParameters
        {
            get { return m_reportParameters; }
            set { m_reportParameters = value; }
        }

        private Report CreateReport()
        {
            Report report = new Report();
            report.Items = new object[] 
                {
                    CreateDataSources(),
                    CreateBody(),
                    CreateDataSets(),
                    "6.5in",
                    "1.5cm",
                    "1.5cm",
                    "0.8cm",
                    "0.5cm",
                    //this.CreateParametersType(),
                    new PageHeaderRdlGenerator(this.m_screenTitle).CreatePageHeaderType(),
                    //new PageFooterRdlGenerator(this.m_userName).CreatePageFooterType()
                };
            report.ItemsElementName = new ItemsChoiceType37[]
                { 
                    ItemsChoiceType37.DataSources, 
                    ItemsChoiceType37.Body,
                    ItemsChoiceType37.DataSets,
                    ItemsChoiceType37.Width,    
                    ItemsChoiceType37.BottomMargin,
                    ItemsChoiceType37.TopMargin,
                    ItemsChoiceType37.LeftMargin,
                    ItemsChoiceType37.RightMargin,
                    //ItemsChoiceType37.ReportParameters,
                    ItemsChoiceType37.PageHeader,
                    //ItemsChoiceType37.PageFooter
                };
            return report;
        }

        private ReportParametersType CreateParametersType()
        {
            ReportParametersType listReportParametersType = new ReportParametersType();
            List<ReportParameterType> listReportParameterType = new List<ReportParameterType>();

            foreach (ReportParameter reportParameter in this.m_reportParameters)
                listReportParameterType.Add(this.CreateParameterType(reportParameter));

            listReportParametersType.ReportParameter = listReportParameterType.ToArray();

            return listReportParametersType;
        }

        private ReportParameterType CreateParameterType(ReportParameter reportParameter)
        {
            ReportParameterType reportParameterType = new ReportParameterType();
            reportParameterType.Name = reportParameter.Name;
            reportParameterType.Items = new object[]
                    {
                        ReportParameterTypeDataType.String,
                        reportParameter.Name,
                        true
                    };
            reportParameterType.ItemsElementName = new ItemsChoiceType33[]
                    {
                        ItemsChoiceType33.DataType,
                        ItemsChoiceType33.Prompt,
                        ItemsChoiceType33.AllowBlank
                    };

            return reportParameterType;
        }

        private DataSourcesType CreateDataSources()
        {
            DataSourcesType dataSources = new DataSourcesType();
            dataSources.DataSource = new DataSourceType[] { CreateDataSource() };
            return dataSources;
        }

        private DataSourceType CreateDataSource()
        {
            DataSourceType dataSource = new DataSourceType();
            dataSource.Name = "DummyDataSource";
            dataSource.Items = new object[] { CreateConnectionProperties() };
            return dataSource;
        }

        private ConnectionPropertiesType CreateConnectionProperties()
        {
            ConnectionPropertiesType connectionProperties = new ConnectionPropertiesType();
            connectionProperties.Items = new object[]
                {
                    "",
                    "SQL",
                };
            connectionProperties.ItemsElementName = new ItemsChoiceType[]
                {
                    ItemsChoiceType.ConnectString,
                    ItemsChoiceType.DataProvider,
                };
            return connectionProperties;
        }

        private BodyType CreateBody()
        {
            BodyType body = new BodyType();
            body.Items = new object[]
                {
                    CreateReportItems(),
                    "1in",
                };
            body.ItemsElementName = new ItemsChoiceType30[]
                {
                    ItemsChoiceType30.ReportItems,
                    ItemsChoiceType30.Height,
                };
            return body;
        }

        private ReportItemsType CreateReportItems()
        {
            ReportItemsType reportItems = new ReportItemsType();
            TableRdlGenerator tableGen = new TableRdlGenerator();
            tableGen.Fields = m_selectedFields;
            tableGen.Headers = m_headers;
            tableGen.Widths = m_widths;
            reportItems.Items = new object[] { tableGen.CreateTable() };
            return reportItems;
        }

        //private ImageType RetornarImaeg()
        //{
        //    ImageType text = new ImageType();
        //    text.Items = new object[]
        //            {
        //                "image/bmp",
        //                ImageTypeSource.External,
        //                "=System.Convert.FromBase64String(Parameters!ParameterTeste.Value)",
        //                ImageTypeSizing.FitProportional
        //            };
        //    //"=Parameters!ParameterTeste.Value",
        //    text.Name = "teste";
        //    text.ItemsElementName = new ItemsChoiceType15[]
        //            {
        //                ItemsChoiceType15.MIMEType,
        //                ItemsChoiceType15.Source,
        //                ItemsChoiceType15.Value,
        //                ItemsChoiceType15.Sizing,
        //                //ItemsChoiceType15.
        //            };

        //    return text;

        //    //TableType table = new TableType();
        //    //this.CalculateWitdhs();
        //    //table.Name = "Table1";
        //    //table.Items = new object[]
        //    //    {
        //    //        CreateTableColumns(),
        //    //        CreateHeader(),
        //    //        CreateDetails(),
        //    //        widthGrid.ToString() + "cm",
        //    //    };
        //    //table.ItemsElementName = new ItemsChoiceType21[]
        //    //    {
        //    //        ItemsChoiceType21.TableColumns,
        //    //        ItemsChoiceType21.Header,
        //    //        ItemsChoiceType21.Details,
        //    //        ItemsChoiceType21.Width,
        //    //    };


        //    //return table;
        //}

        private DataSetsType CreateDataSets()
        {
            DataSetsType dataSets = new DataSetsType();
            dataSets.DataSet = new DataSetType[] { CreateDataSet() };
            return dataSets;
        }

        private DataSetType CreateDataSet()
        {
            DataSetType dataSet = new DataSetType();
            dataSet.Name = "MyData";
            dataSet.Items = new object[] { CreateQuery(), CreateFields() };
            return dataSet;
        }

        private QueryType CreateQuery()
        {
            QueryType query = new QueryType();
            query.Items = new object[] 
                {
                    "DummyDataSource",
                    "",
                };
            query.ItemsElementName = new ItemsChoiceType2[]
                {
                    ItemsChoiceType2.DataSourceName,
                    ItemsChoiceType2.CommandText,
                };
            return query;
        }

        private FieldsType CreateFields()
        {
            FieldsType fields = new FieldsType();

            fields.Field = new FieldType[m_allFields.Count];
            for (int i = 0; i < m_allFields.Count; i++)
            {
                fields.Field[i] = CreateField(m_allFields[i]);
            }

            return fields;
        }

        private FieldType CreateField(String fieldName)
        {
            FieldType field = new FieldType();
            field.Name = fieldName;
            field.Items = new object[] { fieldName };
            field.ItemsElementName = new ItemsChoiceType1[] { ItemsChoiceType1.DataField };
            return field;
        }

        public void WriteXml(Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Report));
            serializer.Serialize(stream, CreateReport());
        }
    }
}
