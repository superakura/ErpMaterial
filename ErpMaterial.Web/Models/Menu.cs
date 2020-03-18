using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpMaterial.Web.Models
{
    public class Menu
    {
        public string code { get; set; }
        public string msg { get; set; }
        public List<MenuData> data { get; set; }
    }
}
