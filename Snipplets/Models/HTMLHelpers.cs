using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Snipplets.Models
{
    public class HTMLHelpers
    {
        public int id { get; set; }
        public string TextBox { get; set; }

        [DataType(DataType.MultilineText)]
        public string TextArea { get; set; }

        public bool CheckBox { get; set; }

        public bool CheckBox2 { get; set; }    
        public bool CheckBox3 { get; set; }

        public radiotype RadioButton { get; set; }

        public dropdowntype DropDown1 { get; set; }

        public IEnumerable<string> DropDown2 { get; set; }

        public IEnumerable<string> ListBox { get; set; }

        public int Hidden { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.MultilineText)]
        public string Editor { get; set; }

    }


    public enum radiotype
    {
        radio1, radio2
    }

    public enum dropdowntype 
    {
        FirstItem,
        SecondItem,
        ThirdItem
    }
}