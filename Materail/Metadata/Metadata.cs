using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Materail.Metadata
{
    public class MemberMetadata
    {  
        [RegularExpression("[B][0-9]{5}",ErrorMessage ="帳號格式錯誤")]
        public string memId { get; set; }
        public string memName { get; set; }
        public string memAct { get; set; }
        public string memPwd { get; set; }
        public string memTel { get; set; }
        
        [EmailAddress]
        public string memEmail { get; set; }
        public bool memGender { get; set; }
        public byte Authority { get; set; }
        public string memTitle { get; set; }
        public string admId { get; set; }
    }
}