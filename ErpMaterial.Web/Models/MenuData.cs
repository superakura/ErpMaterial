using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErpMaterial.Web.Models
{
    public class MenuData
    {
        public string name { get; set; }

        public string title { get; set; }

        public string icon { get; set; }

        /// <summary>
        /// 转跳地址
        /// </summary>
        public string jump { get; set; }

        /// <summary>
        /// 是否展开
        /// </summary>
        public string spread { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuData> list { get; set; }
    }
}
