using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using Windows.UI.Xaml.Media.Imaging;
//using static System.Windows.Media.Imaging.BitmapImage;
namespace Datebase_
{
    internal class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public Image Image { get; set; }
        //public string Image { get; set; }
        public int OrganizationID { get; set; }
    }
}
