using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Snipplets.Models
{
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }

        public SexType Sex { get; set; }

        public string FileNamePicture { get; set; }

        public bool Active { get; set; }
    }

    public enum SexType
    {
        Male, Female, NonHuman

    }
}