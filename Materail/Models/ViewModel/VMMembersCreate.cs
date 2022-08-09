using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Materail.Models.ViewModel
{
    public class VMMembersCreate
    {
        [Key]
        [DisplayName("員工編號")]
        [RegularExpression("[B][0-9]{5}", ErrorMessage = "員工編號格式有誤")]
        public string memId { get; set; }

        [DisplayName("員工姓名")]
        [Required(ErrorMessage = "員工姓名為必填")]
        [StringLength(20,ErrorMessage ="員工姓名最多20個字")]
        public string memName { get; set; }

        [Unique(ErrorMessage = "此帳號已經存在")]
        [DisplayName("員工帳號")]
        [Required(ErrorMessage = "請設定員工帳號")]
        [RegularExpression("[A-Z]{2}[0-9]{8}", ErrorMessage = ("帳號格式錯誤"))]
        public string memAct { get; set; }

        [DisplayName("員工密碼")]
        [Required(ErrorMessage = "請設定員工密碼")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{10}$", ErrorMessage = "密碼格式錯誤")]
        public string memPwd { get; set; }

        [DisplayName("員工電話")]
        [Required(ErrorMessage = "員工電話為必填")]
        [RegularExpression("^09[0-9]{8}$", ErrorMessage = "電話號碼格式錯誤")]
        public string memTel { get; set; }

        [DisplayName("電子郵件")]
        [EmailAddress(ErrorMessage = "電子郵件格式錯誤")]
        [Required(ErrorMessage = "電子郵件為必填")]
        [StringLength(100)]
        public string memEmail { get; set; }

        [DisplayName("性別")]
        [Required(ErrorMessage = "請選擇性別")]
        public bool memGender { get; set; }

        [DisplayName("權限")]
        [Range(1, 3)]
        public byte Authority { get; set; }

        [DisplayName("職稱")]
        [Required(ErrorMessage = "請填寫職稱")]
        [StringLength(25, ErrorMessage = "職稱最多25個字")]
        public string memTitle { get; set; }

        [DisplayName("主管編號")]
        public string admId { get; set; }

        public virtual List<Administrators> administrators { get; set; }
    }
}