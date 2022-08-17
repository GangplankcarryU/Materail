using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Materail.Models.ViewModel
{
    public class VMCustomers
    {
        [Key]
        [DisplayName("客戶編號")]
        [Required(ErrorMessage = "客戶編號為必填")]
        [RegularExpression("[C][0-9]{5}", ErrorMessage = "客戶編號格式錯誤")]
        public string cusId { get; set; }

        [DisplayName("客戶名稱")]
        [Required(ErrorMessage = "客戶稱為必填")]
        [StringLength(50, ErrorMessage = "客戶名稱最多50個字")]
        public string cusName { get; set; }

        [DisplayName("聯絡電話")]
        [Required(ErrorMessage = "聯絡電話為必填")]
        [RegularExpression("0[1-9]{1,2}-?[0-9]{7,8}", ErrorMessage = "電話格式錯誤")]
        public string cusTel { get; set; }

        [DisplayName("地址")]
        [Required(ErrorMessage = "地址為必填")]
        [StringLength(50, ErrorMessage = "地址最多50個字")]
        public string cusAdddress { get; set; }


        [DisplayName("備註")]
        [StringLength(1000, ErrorMessage = "備註最多1000個字")]
        public string cusNotes { get; set; }
    }
}