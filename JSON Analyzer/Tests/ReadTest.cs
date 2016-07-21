using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Web;

namespace JSON_Analyzer.Tests
{
    [TestClass]
    public class ReadTest
    {
        [TestMethod]
        public void Read()
        {
            //string path = HttpContext.Current.Server.MapPath("~/Data/data.json");
            string path = "C:\\Users\\Александр\\Source\\Workspaces\\Рабочая область\\JSON Analyzer\\JSON Analyzer\\Data\\data.json";
            string fileContent = File.ReadAllText(path);
            dynamic items = JsonConvert.DeserializeObject<dynamic>(fileContent);
            foreach(var item in items.ChildrenTokens)
            {
                var name = item.Name;
            }

            //var i = items.GetType().GetProperty("ChildrenTokens").GetValue(items, null);
            //var nameOfProperty = "ChildrenTokens";
            //var propertyInfo = items.GetType().GetProperty(nameOfProperty);
            //var value = propertyInfo.GetValue(items, null);
        }
    }
}