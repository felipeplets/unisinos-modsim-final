using System;
using System.Collections.Generic;
using System.Text;

namespace Comum.Framework.Relatorios
{
    public class BaseRdlGenerator
    {
        private static int number = 0;

        public TextboxType CreateTextBoxType(string value, string width, string left)
        {
            TextboxType textBoxType = new TextboxType();
            textBoxType.Items = new object[]
                    {
                        value,
                        left,
                        width,
                        this.CreateStyleType()
                    };
            //increment the counter to avoid errors
            textBoxType.Name = "textBoxType" + BaseRdlGenerator.number.ToString();
            BaseRdlGenerator.number = BaseRdlGenerator.number + 1;
            textBoxType.ItemsElementName = new ItemsChoiceType14[]
                    {
                        ItemsChoiceType14.Value,
                        ItemsChoiceType14.Left,
                        ItemsChoiceType14.Width,
                        ItemsChoiceType14.Style
                    };

            return textBoxType;
        }

        public TextboxType CreateTextBoxType(string value, string width, string left, string top)
        {
            TextboxType textBoxType = this.CreateTextBoxType(value, width, left);
            return this.AddProperty(textBoxType, top, ItemsChoiceType14.Top);
        }

        public TextboxType CreateTextBoxType(string value, string width, string left, string top, string fontSize, bool bold)
        {
            TextboxType textBoxType = this.CreateTextBoxType(value, width, left, top);
            this.AddStyle(textBoxType, fontSize, ItemsChoiceType5.FontSize);
            //this.AddStyle(textBoxType, , ItemsChoiceType5.FontSize);
            return textBoxType;
        }

        private StyleType CreateStyleType()
        {
            StyleType styleType = new StyleType();
            styleType.Items = new object[0];
            styleType.ItemsElementName = new ItemsChoiceType5[0];
            return styleType;
        }

        private TextboxType AddProperty(TextboxType textBoxType, object value, ItemsChoiceType14 itemsChoiceType14)
        {
            List<ItemsChoiceType14> listItemsChoiceType14 = new List<ItemsChoiceType14>(textBoxType.ItemsElementName);
            List<object> listItems = new List<object>(textBoxType.Items);
            listItems.Add(value);
            listItemsChoiceType14.Add(itemsChoiceType14);
            textBoxType.Items = listItems.ToArray();
            textBoxType.ItemsElementName = listItemsChoiceType14.ToArray();
            return textBoxType;
        }

        private TextboxType AddStyle(TextboxType textBoxType, object value, ItemsChoiceType5 itemsChoiceType5)
        {
            StyleType styleType = this.GetStyleType(textBoxType);
            List<object> listItems = new List<object>(styleType.Items);
            List<ItemsChoiceType5> listItemsChoiceType5 = new List<ItemsChoiceType5>(styleType.ItemsElementName);

            listItems.Add(value);
            listItemsChoiceType5.Add(itemsChoiceType5);

            styleType.Items = listItems.ToArray();
            styleType.ItemsElementName = listItemsChoiceType5.ToArray();

            return textBoxType;
        }

        private StyleType GetStyleType(TextboxType textBoxType)
        {
            List<object> listItems = new List<object>(textBoxType.Items);
            return (listItems.Find(
                delegate(object testObject) { return testObject is StyleType; }
                )) as StyleType;
        }
    }
}
