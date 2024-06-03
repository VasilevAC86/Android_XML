using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android_XML
{
    public class Vector // Класс для корневого каталога vector
    {
        // Атрибуты будут обычными полями
        public string Width { get; set; }
        public string Height { get; set; }
        public string ViewporWidth { get; set; }
        public string ViewporHeight { get; set; }
        public List<Path> Paths { get; set;}
    }
}
