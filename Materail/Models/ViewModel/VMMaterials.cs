using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Materail.Models.ViewModel
{
    public class VMMaterials
    {
        [Key]
        [DisplayName("料號")]
        [RegularExpression("^[0-4]-[a-zA-z0-9]{1,50}$",ErrorMessage ="料號格式錯誤")]
        public string materialId { get; set; }

        [DisplayName("物料名稱")]
        [Required(ErrorMessage ="物料名稱不可為空")]
        [StringLength(50,ErrorMessage ="物料名稱長度不可超過50個字")]
        public string materialName { get; set; }

        [DisplayName("原廠料號")]
        [Required(ErrorMessage = "原廠料號不可為空")]
        [StringLength(50, ErrorMessage = "原廠料號長度不可超過50個字")]
        public string goodId { get; set; }

        [DisplayName("物料類別")]
        [Required(ErrorMessage ="請選擇物料類別")]
        public byte materialType { get; set; }
    }
}