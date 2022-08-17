using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Materail.Models.ViewModel
{
    public class VMWareHouse
    {
        [Key]
        [DisplayName("倉庫編號")]
        [Required(ErrorMessage = "倉庫編號為必填")]
        [RegularExpression("[W][0-9]{4}", ErrorMessage = "倉庫編號格式錯誤")]
        public string whId { get; set; }

        [DisplayName("倉庫名稱")]
        [Required(ErrorMessage = "倉庫名稱為必填")]
        [StringLength(10, ErrorMessage = "倉庫名稱最多10個字")]
        public string whName { get; set; }

        [DisplayName("倉庫電話")]
        [Required(ErrorMessage = "倉庫電話為必填")]
        [RegularExpression("0[1-9]{1,2}-?[0-9]{7,8}", ErrorMessage = "電話格式錯誤")]
        public string whTel { get; set; }

        [DisplayName("地址")]
        [Required(ErrorMessage = "地址為必填")]
        [StringLength(50, ErrorMessage = "地址最多50個字")]
        public string whAddress { get; set; }
    }
}