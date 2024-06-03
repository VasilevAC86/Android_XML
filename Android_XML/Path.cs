using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android_XML
{
   public class Path
    {
        public string PathData { get; set; } // Данные нашего пути
        public Gradient Gradient { get; set; }
        public string FillColor { get; set; } // Парсим первоначальное окно андройд-приложения
        public string FillType { get; set; }
        public string StrokeWigth { get; set; }
        public string StrokeColor { get; set; }
    }
}
