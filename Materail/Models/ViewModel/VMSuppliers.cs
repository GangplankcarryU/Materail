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
        [StringLength(50,ErrorMessage ="供應商名稱")]
        public string supName { get; set; }
        public string supTel { get; set; }
        public string supAddress { get; set; }
        public string supNotes { get; set; }
    }
}