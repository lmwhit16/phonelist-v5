using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.core.Models
{
    public class PhoneModel
    {
        public decimal phoneId { get; set; }
        public String phoneCd { get; set; }
        public Decimal phoneNumber { get; set; }
        public DateTime createDate { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public decimal applicantId { get; set; }
        public ICollection<PhoneCodeModel> phoneCodes { get; set; }
    }
}
