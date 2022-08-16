using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Materail.Models;

namespace Materail.Models.ViewModel
{
    public class VMAdministratorsCreate
    {
        [Key]
        [DisplayName("管理員編號")]
        [RegularExpression("[B][S][0-9]{5}", ErrorMessage = "管理員編號格式有誤")]
        public string admId { get; set; }

        [DisplayName("管理員姓名")]
        [Required(ErrorMessage = "管理員姓名為必填")]
        [StringLength(20,ErrorMessage = "管理員姓名最多20個字")]
        public string admName { get; set; }

        
        [DisplayName("管理員帳號")]
        [AdmUnique(ErrorMessage ="此帳號已存在")]
        [Required(ErrorMessage = "請設定管理員帳號")]
        [RegularExpression("A[A-Z]{2}[0-9]{8}", ErrorMessage = ("帳號格式錯誤"))]
        public string admAct { get; set; }

        [DisplayName("管理員密碼")]
        [Required(ErrorMessage = "請設定管理員密碼")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{10}$", ErrorMessage = "密碼格式錯誤")]
        public string admPwd { get; set; }

        [DisplayName("性別")]
        [Required(ErrorMessage = "請選擇性別")]
        public bool admGender { get; set; }

        [DisplayName("管理員電話")]
        [Required(ErrorMessage = "管理員電話為必填")]
        [RegularExpression("^09[0-9]{8}$", ErrorMessage = "電話號碼格式錯誤")]
        public string admTel { get; set; }

        [DisplayName("電子郵件")]
        [Required(ErrorMessage = "電子郵件為必填")]
        [EmailAddress(ErrorMessage = "電子郵件格式錯誤")]
        [StringLength(100)]
        public string admEmail { get; set; }

    }
}
