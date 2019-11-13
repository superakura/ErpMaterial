using System;
using System.Collections.Generic;
using System.Text;

namespace ErpMaterial.Service.ViewModel
{
    public class PageLayUI<T>
    {
        public int code { get; set; } = 0;
        public string msg { get; set; } = "";
        public int count { get; set; }
        public List<T> data { get; set; }
    }
}
