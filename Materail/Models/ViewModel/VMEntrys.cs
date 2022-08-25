using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Materail.Models.ViewModel
{
    public class VMEntrys
    {
        [Key]
        [DisplayName("入庫單號")]
        public string entryId { get; set; }

        [DisplayName("製單人員")]
        public string memId { get; set; }

        [DisplayName("倉庫編號")]
        public string whId { get; set; }

        [DisplayName("料號")]
        public string materialId { get; set; }

        [DisplayName("數量")]
        public double entryNum { get; set; }

        [DisplayName("單位")]
        public string Unit { get; set; }

        [DisplayName("建立日期")]
        public System.DateTime entryTime { get; set; }

        [DisplayName("批號")]
        public string materialLotNo { get; set; }

        [DisplayName("備註")]
        public string entryNotes { get; set; }
    }
}