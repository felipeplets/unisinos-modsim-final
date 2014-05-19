using System;
using System.Collections.Generic;
using System.Text;

namespace Salux.Framework.Relatorios
{
    public class PageFooterRdlGenerator : BaseRdlGenerator
    {
        private string userName;

        public PageFooterRdlGenerator()
        {
 
        }

        public PageHeaderFooterType CreatePageFooterType()
        {
            PageHeaderFooterType pageHeaderType = new PageHeaderFooterType();
            pageHeaderType.Items = new object[]
                {
                    this.CreateReportItemsTypeFooter(),
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

        private ReportItemsType CreateReportItemsTypeFooter()
        {
            ReportItemsType reportItemsType = new ReportItemsType();
            reportItemsType.Items = new object[] 
                {
                    this.CreateTextBoxUserName()
                };
            return reportItemsType;
        }

        private TextboxType CreateTextBoxUserName()
        {
            return base.CreateTextBoxType(string.Format("Impresso por: {0}", this.userName), "20cm", "0cm");
        }

        public PageFooterRdlGenerator(string userName)
        {
            this.userName = userName;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
    }
}
