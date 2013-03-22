using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.core.Models
{
    public class PhoneCodeModel
    {
        //[DataType(DataType.EmailAddress)]
        public String phoneCode { get; set; }
        public String phoneCodeDescription { get; set; }
        public DateTime lastModifiedDate { get; set; }
    }
}
