using System;
using System.Collections.Generic;
using System.Text;

namespace ErpMaterial.Service.ViewModel
{
    public class DeptLayUI
    {
        public int id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public bool spread { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string href { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool @checked { get; set; }

        public List<DeptLayUI> children { get; set; }
    }
}
