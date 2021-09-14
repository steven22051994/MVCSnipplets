using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Snipplets.Models
{
    public class JSONData
    {
        public int Id { get; set; }

        public int JSONVersion { get; set; }

        public List<Data> data { get; set; }
    }

    public class Data
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string ArticleText { get; set; }

        [Range(0, 5)]
        public float Score { get; set; } = 0;   // Default value is 0 

        [DisplayName("Anzahl Scores")]
        public int ScoresSum { get; set; } = 0;

        [ScaffoldColumn(false)]
        public bool Active { get; set; } = true;

    }
}