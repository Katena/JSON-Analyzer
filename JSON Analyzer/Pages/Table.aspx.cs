using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Statistics.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JSON_Analyzer.Pages
{
    class Item
    {
        public Dictionary<string, string> properties = new Dictionary<string, string>();
        public Item(Dictionary<string, string> _properties)
        {
            properties = _properties;
        }
        public Item()
        { }
    }

    public partial class Table : System.Web.UI.Page
    {
        #region Methods
        private List<Item> LoadJson()
        {
            string path = HttpContext.Current.Server.MapPath("~/Data/data.json");
            string fileContent = File.ReadAllText(path);
            JArray items = (JArray)JsonConvert.DeserializeObject(fileContent);
            List<Item> result = new List<Item>();
            foreach (var item in items)
            {
                var jItem = (JObject)item;
                var prasedItem = new Item();
                foreach (var prop in jItem.Properties())
                    prasedItem.properties.Add(prop.Name, jItem.Property(prop.Name).Value.ToString());
                result.Add(prasedItem);
            }
            return result;
        }
        private void SaveJson(List<Item> items)
        {
            string path = HttpContext.Current.Server.MapPath("~/Data/data.json");
            List<JObject> jObjects = new List<JObject>();
            foreach (var item in items)
            {
                JObject jObject = new JObject();
                foreach (var property in item.properties)
                    jObject.Add(property.Key, (JToken)property.Value);
                jObjects.Add(jObject);
            }
            File.WriteAllText(path, JsonConvert.SerializeObject(jObjects));
        }
        private Control CreateTable(List<Item> items)
        {
            if (Page.FindControl("itemTable") == null)
                Page.Controls.Remove(Page.FindControl("itemTable"));

            HtmlControlCreator creator = new HtmlControlCreator();
            var table = creator.CreateHtmlControl("itemsTable", "table", "table");
            if (items.Count > 0)
            {
                var header = creator.CreateHtmlControl(string.Empty, "tr", string.Empty);
                List<string> headerNames = new List<string>();
                foreach (var item in items[0].properties)
                {
                    header.Controls.Add(creator.CreateHtmlControl("th", item.Key));
                    headerNames.Add(item.Key);
                }
                table.Controls.Add(header);
                foreach (var item in items)
                {
                    var row = creator.CreateHtmlControl(string.Empty, "tr", "info");
                    foreach (var name in headerNames)
                    {
                        if (item.properties.ContainsKey(name))
                        {
                            if (!item.properties[name].Contains("https"))
                            {
                                var valueCell = creator.CreateHtmlControl("td", item.properties[name]);
                                row.Controls.Add(valueCell);
                            }
                            else
                            {
                                var valueCell = creator.CreateHtmlControl("td", String.Empty);
                                var image = creator.CreateHtmlControl("img", String.Empty);
                                creator.SetAttributes(ref image, new Dictionary<string, string> { { "src", item.properties[name] } });
                                valueCell.Controls.Add(image);
                                row.Controls.Add(valueCell);
                            }
                            
                        }
                        else
                        {
                            var valueCell = creator.CreateHtmlControl("td", String.Empty);
                            row.Controls.Add(valueCell);
                        }

                    }
                    //кнопки для удаления
                    //TableCell deleteCell = new TableCell();
                    ////var deleteCell = creator.CreateHtmlControl("td", String.Empty);
                    ////var deleteBtn = creator.CreateHtmlControl("button", "delete");
                    //Button deleteBtn = new Button();
                    //deleteCell.Controls.Add(deleteBtn);
                    //row.Controls.Add(deleteCell);




                    table.Controls.Add(row);
                }
            }
            return table;
        }
        private void AddToDropDown(Item item)
        {
            foreach (var property in item.properties)
                searchDropDown.Items.Add(property.Key);
        }
        private List<Item> Search(List<Item> items, String columnName, String value)
        {
            if (!String.IsNullOrEmpty(columnName) && !String.IsNullOrEmpty(value))
            {
                return items.Where(item => item.properties[columnName] == value).ToList();                
            }
            else
                return items;
        }
        private void Remove(List<Item> items, String field, String value)
        {
            try
            {
                items.RemoveAll(x => x.properties[field] == value);
                SaveJson(items);
            }
            catch (Exception ex)
            {

            }
        }
        private void Add(List<Item> items, Item item)
        {
            items.Add(item);
            SaveJson(items);
        }
        private void InitPage(List<Item> items)
        {
            //items = LoadJson();            
            Page.Controls.Add(CreateTable(items));
            if (items.Count > 0) AddToDropDown(items[0]);
        }
        #endregion
        #region Globals
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                InitPage(LoadJson());
        }
        #region Events
        protected void searchBtn_Click(object sender, EventArgs e)
        {
            List<Item> items = LoadJson();
            items = Search(items, searchDropDown.Text, searchTextBox.Text);
            InitPage(items);
        }
       
        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            List<Item> items = LoadJson();
            Remove(items, searchDropDown.Text, searchTextBox.Text);
            InitPage(items);
            searchTextBox.Text = String.Empty;
        }
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            Add(LoadJson(), new Item(new Dictionary<string, string> { { "first_name", "DAT IS TEST" } }));
        }
        protected void restoreBtn_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}