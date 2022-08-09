using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Materail.Models.Metadata
{
    public partial class MembersMetadata
    {
        [MetadataType(typeof(MetaMembers))]
        public class MetaMembers
        {
            [Key]
            [DisplayName("員工編號")]
            [RegularExpression("[B][0-9]{5}",ErrorMessage ="員工編號格式有誤")]
            public string memId { get; set; }

            [DisplayName("員工姓名")]
            [Required(ErrorMessage ="員工姓名為必填")]
            [StringLength(20)]
            public string memName { get; set; }

            [Unique]
            [DisplayName("員工帳號")]
            [Required(ErrorMessage ="請設定員工帳號")]
            [RegularExpression("[A-Z]{2}[0-9]{8}",ErrorMessage =("帳號格式錯誤"))]
            public string memAct { get; set; }

            [DisplayName("員工密碼")]
            [Required(ErrorMessage = "請設定員工密碼")]
            [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{10}$",ErrorMessage ="密碼格式錯誤")]
            public string memPwd { get; set; }

            [DisplayName("員工電話")]
            [Required(ErrorMessage = "員工電話為必填")]
            [RegularExpression("^09[0-9]{8}$",ErrorMessage ="電話號碼格式錯誤")]
            public string memTel { get; set; }

            [EmailAddress]
            public string memEmail { get; set; }
            public bool memGender { get; set; }
            public byte Authority { get; set; }
            public string memTitle { get; set; }
            public string admId { get; set; }

        }
    }
}