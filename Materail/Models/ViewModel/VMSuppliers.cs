using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Materail.Models.ViewModel
{
    public class VMSuppliers
    {
        [Key]
        [DisplayName("供應商編號")]
        [Required(ErrorMessage ="供應商編號為必填")]
        [RegularExpression("[S][0-9]{5}",ErrorMessage ="供應商編號格式錯誤")]
        public string supId { get; set; }

        [DisplayName("供應商名稱")]
        [Required(ErrorMessage = "供應商名稱為必填")]
        [StringLength(50,ErrorMessage ="供應商名稱最多50個字")]
        public string supName { get; set; }

        [DisplayName("聯絡電話")]
        [Required(ErrorMessage ="聯絡電話為必填")]
        [RegularExpression("0[1-9]{1,2}-?[0-9]{7,8}",ErrorMessage ="電話格式錯誤")]
        public string supTel { get; set; }

        [DisplayName("地址")]
        [Required(ErrorMessage ="地址為必填")]
        [StringLength(50,ErrorMessage ="地址最多50個字")]
        public string supAddress { get; set; }

        [DisplayName("備註")]
        [StringLength(1000,ErrorMessage ="備註最多1000個字")]
        public string supNotes { get; set; }
    }
}