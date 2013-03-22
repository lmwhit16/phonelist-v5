using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.core.Services
{
    public class PhoneServiceFake : IService
    {
        private ICollection<Models.PhoneModel> sampleData;
        public PhoneServiceFake(){
            sampleData = new List<Models.PhoneModel>();
            sampleData.Add(new Models.PhoneModel{
                applicantId = 1,
                createDate = DateTime.Now,
                lastModifiedDate = DateTime.Now,
                phoneCd = "AA",
                phoneId = 1,
                phoneNumber = 1234567890
            });
            sampleData.Add(new Models.PhoneModel
            {
                applicantId = 1,
                createDate = DateTime.Now,
                lastModifiedDate = DateTime.Now,
                phoneCd = "AA",
                phoneId = 2,
                phoneNumber = 2224567890
            });
            sampleData.Add(new Models.PhoneModel
            {
                applicantId = 2,
                createDate = DateTime.Now,
                lastModifiedDate = DateTime.Now,
                phoneCd = "AA",
                phoneId = 3,
                phoneNumber = 3334567890
            });
        }

        public ICollection<Models.PhoneModel> listPhones()
        {
            return sampleData;
        }

        public ICollection<Models.PhoneModel> listPhonesByUser(decimal userId)
        {
            var result = (from r in sampleData.AsEnumerable()
              where r.applicantId==userId
              select r).ToList();
            return result;
        }

        public Models.PhoneModel getPhoneById(decimal phoneId)
        {
            var result = (from r in sampleData.AsEnumerable()
                         where r.phoneId == phoneId
                          select r).FirstOrDefault<Models.PhoneModel>();
            return result;
        }

        public ICollection<Models.PhoneCodeModel> getPhoneCds()
        {
            throw new NotImplementedException();
        }
    }
}
