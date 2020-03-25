using System;
using System.Collections.Generic;
using System.Text;

namespace ErpMaterial.Service.ViewModel
{
    public class ViewMaterialScrap
    {
        public int ErpDetailId { get; set; }
        public string Mblnr { get; set; }
        public string Mjahr { get; set; }
        public string Budat { get; set; }
        public string Bldat { get; set; }
        public string Belnr { get; set; }
        public string Bwart { get; set; }
        public string Matnr { get; set; }
        public string Maktx { get; set; }
        public string Matkl { get; set; }
        public string Werks { get; set; }
        public string Lgort { get; set; }
        public string LgortDesc { get; set; }
        public string Sobkz { get; set; }
        public string Lifnr { get; set; }
        public string LifnrDesc { get; set; }
        public string Kunnr { get; set; }
        public double? Menge { get; set; }
        public string Meins { get; set; }
        public string Ebeln { get; set; }
        public string Ebelp { get; set; }
        public string Rsnum { get; set; }
        public string Rspos { get; set; }
        public string Umwrk { get; set; }
        public string Umlgo { get; set; }
        public string UmlgoDesc { get; set; }
        public string Kostl { get; set; }
        public string Ktext { get; set; }
        public string Pspel { get; set; }
        public string GdNum { get; set; }
        public string Zthdw { get; set; }
        public string UserNum { get; set; }
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 领用人姓名
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 领用部门
        /// </summary>
        public string userDept { get; set; }

        /// <summary>
        /// 报废原因
        /// </summary>
        public string scrapReason { get; set; }

        /// <summary>
        /// 是否移交物资中心
        /// </summary>
        public string isMoveWuZi { get; set; }

        /// <summary>
        /// 移交日期
        /// </summary>
        public DateTime? moveDate { get; set; }

        /// <summary>
        /// 分厂交付人
        /// </summary>
        public string movePersonNum { get; set; }

        /// <summary>
        ///物资中心接受人
        /// </summary>
        public string acceptPersonNum { get; set; }
    }
}
