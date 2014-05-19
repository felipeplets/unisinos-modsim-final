using System;
using System.Collections.Generic;
using System.Text;
using Comum.Framework.Relatorios;

namespace Comum.Framework.Relatorios
{
    public class PageHeaderRdlGenerator : BaseRdlGenerator
    {
        private string screenTitle;

        public PageHeaderRdlGenerator()
        {
            
        }

        public PageHeaderRdlGenerator(string screenTitle)
        {
            this.screenTitle = screenTitle;
        }

        public PageHeaderFooterType CreatePageHeaderType()
        {
            PageHeaderFooterType pageHeaderType = new PageHeaderFooterType();
            pageHeaderType.Items = new object[]
                {
                    this.CreateReportItemsTypeHeader(),
                    true,
                    true,
                    "1in"
                };
            pageHeaderType.ItemsElementName = new ItemsChoiceType34[] 
                {
                    ItemsChoiceType34.ReportItems,
                    ItemsChoiceType34.PrintOnFirstPage,
                    ItemsChoiceType34.PrintOnLastPage,
                    ItemsChoiceType34.Height
                };
            return pageHeaderType;
        }

        private ReportItemsType CreateReportItemsTypeHeader()
        {
            ReportItemsType reportItemsType = new ReportItemsType();
            reportItemsType.Items = new object[] 
                {
                    this.CreateTextBoxTypeDate(),
                    this.CreateTextBoxTypePageNumber(),
                    this.CreateTextBoxTypeTitle()
                };
            return reportItemsType;
        }

        private TextboxType CreateTextBoxTypeDate()
        {
            return base.CreateTextBoxType(DateTime.Now.ToString(), "5cm", "0cm");
        }

        private TextboxType CreateTextBoxTypePageNumber()
        {
            return base.CreateTextBoxType("=Globals!PageNumber & \" / \" & Globals!TotalPages", "5cm", "19cm");
        }

        private TextboxType CreateTextBoxTypeTitle()
        {
            return base.CreateTextBoxType("Listagem - " + this.screenTitle, "20cm", "2cm", "1cm", "18pt", true);
        }

        public string ScreenTitle
        {
            get { return screenTitle; }
            set { screenTitle = value; }
        }
    }
}
