using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Statistics.Classes
{
    public class HtmlControlCreator
    {
        #region Create html controls


        #region Modify
        public void SetAttributes(ref HtmlGenericControl element, Dictionary<string, string> attributes)
        {
            if (attributes != null)
            {
                foreach (var item in attributes)
                {
                    element.Attributes.Add(item.Key, item.Value);
                }
            }
            //return element;
        }
        private void SetInnerText(ref HtmlGenericControl element, String innerText)
        {
            element.InnerText = innerText;
            //return element;
        }
        #endregion

        #region Create
        public HtmlGenericControl CreateHtmlControl(
string ID, string tag, string attributeName,
string attributeValue, string tagClass,
string height, string width)
        {
            HtmlGenericControl element = new HtmlGenericControl(tag);
            if (!String.IsNullOrEmpty(ID))
            {
                element.ID = ID;
            }
            element.Attributes.Add(attributeName, attributeValue);
            element.Attributes.Add("class", tagClass);
            element.Attributes.Add("height", height);
            element.Attributes.Add("width", width);
            return element;
        }
        public HtmlGenericControl CreateHtmlControl(
string ID, string tag, string attributeName,
string attributeValue, string tagClass)
        {
            HtmlGenericControl element = new HtmlGenericControl(tag);
            if (!String.IsNullOrEmpty(ID))
            {
                element.ID = ID;
            }
            element.Attributes.Add(attributeName, attributeValue);
            element.Attributes.Add("class", tagClass);
            return element;
        }
        public HtmlGenericControl CreateHtmlControl(string ID, string tag, string attributeName, string attributeValue)
        {
            HtmlGenericControl element = new HtmlGenericControl(tag);
            if (!String.IsNullOrEmpty(ID))
            {
                element.ID = ID;
            }
            element.Attributes.Add(attributeName, attributeValue);
            return element;
        }
        public HtmlGenericControl CreateHtmlControl(string ID, string tag, string tagClass)
        {
            HtmlGenericControl element = new HtmlGenericControl(tag);
            if (!String.IsNullOrEmpty(ID))           
                element.ID = ID;           
            if(!String.IsNullOrEmpty(tag))
            element.Attributes.Add("class", tagClass);
            return element;
        }
        public HtmlGenericControl CreateHtmlControl(string tag, string innerText)
        {
            HtmlGenericControl element = new HtmlGenericControl(tag);
            SetInnerText(ref element, innerText);
            return element;
        }
        public HtmlGenericControl CreateHtmlControl(string ID, string tag, Dictionary<string, string> attributes)
        {
            HtmlGenericControl element = new HtmlGenericControl(tag);
            if (!String.IsNullOrEmpty(ID))
            {
                element.ID = ID;
            }
            foreach (var item in attributes)
            {
                element.Attributes.Add(item.Key, item.Value);
            }

            return element;
        }
        public HtmlGenericControl CreateHtmlControl(string ID, string tag, Dictionary<string, string> attributes, string innerText)
        {
            HtmlGenericControl element = new HtmlGenericControl(tag);
            if (!String.IsNullOrEmpty(ID))
            {
                element.ID = ID;
            }
            SetAttributes(ref element, attributes);
            SetInnerText(ref element, innerText);
            return element;
        }
        public void PasteControl(Page page, Control control, string controlToPasteName)
        {
            Control controlToPaste = page.FindControl(controlToPasteName);
            if (controlToPaste != null)
            {
                controlToPaste.Controls.Add(control);
            }
        }
        #endregion
        #endregion
    }
}
