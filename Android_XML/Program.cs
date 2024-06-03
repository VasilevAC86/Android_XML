using Newtonsoft.Json;
using System.ComponentModel;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Android_XML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* string xmlFilePath = "file.xml";
             string jsonFilePath = "file.json";
             XDocument xDoc = XDocument.Load(xmlFilePath);
             // Загружаем пространство имён
             XNamespace androidNs = "http://schemas.android.com/apk/res/android";
             XNamespace aaptNs = "http://schemas.android.com/aapt";
             AddItemToGradient(xDoc, androidNs, "#FF0000", "0.5");
             var element = FindElement(xDoc, androidNs + "fillColor", "#FFFFFF");
             if (element != null)
             {
                 Console.WriteLine(element.ToString());
             }
             UpdateGradientAttributes(xDoc, androidNs, "90.0", "95.0", "50.0", "55.0");
             ConvertToJSON(xDoc, jsonFilePath);
             xDoc.Save(xmlFilePath);*/

            // ---- Самостоятельная задача ----
            XDocument xDoc = XDocument.Load("Work2.xml");
            //AddItemToProjects(doc, "01.02.25");
            foreach(var projectElement in xDoc.Descendants("project"))
            {
                projectElement.Add(new XAttribute("newAttribut1", "Value1"));
                projectElement.Add(new XAttribute("newAttribut2", "Value2"));

            }
            xDoc.Save("Work2.xml");
        }
        // Метод обновления атрибутов project
        public static void AddItemToProjects(XDocument xDoc, string date)
        {
            // Ищем по именам project
            var project = xDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "project");
            if (project != null)
            { // Добавляем атрибут в project
                project.Add(new XAttribute("date", date));
            }
        }


        // Метод, добавляющий новый item в gradient
        public static void AddItemToGradient(XDocument xDoc, XNamespace androidNs, string color, string offset)
        {
            // Ищем по именам gradient
            var gradient = xDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "gradient");
            if (gradient != null)
            { // Добавляем item в gradient
                gradient.Add(new XElement("item", new XAttribute(androidNs + "color", color),
                    new XAttribute(androidNs + "ofset", offset)));
            }
        }
        // Метод обновления атрибутов gradient
        public static void UpdateGradientAttributes(XDocument xDoc, XNamespace androidNs, string endX, string endY, string startX, string startY)
        {
            var gradient = xDoc.Descendants().FirstOrDefault(e => e.Name.LocalName == "gradient");
            if (gradient != null)
            {
                gradient.SetAttributeValue(androidNs + "endX", endX);
                gradient.SetAttributeValue(androidNs + "endY", endY);
                gradient.SetAttributeValue(androidNs + "startX", startX);
                gradient.SetAttributeValue(androidNs + "startY", startY);
            }            
        }
        // Метод поиска элемента по атрибутам
        public static XElement FindElement(XDocument xDoc, XName name, string value)
        {
            return xDoc.Descendants().FirstOrDefault(el => el.Attribute(name)?.Value == value); // ? - чтобы не был равным нулю
        }
        // Метод конвертации xml в json
        public static void ConvertToJSON(XDocument xDoc, string filePath)
        {
            // Formatting.Indented указывает на форматирвоание файла в json
            var json = JsonConvert.SerializeXNode(xDoc, Formatting.Indented, omitRootObject: true);
            File.WriteAllText(filePath, json);
        }
    }
}
