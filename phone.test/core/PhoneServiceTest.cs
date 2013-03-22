using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using phone.core.Services;
using phone.core.Models;

namespace phone.test.core
{
    [TestClass]
    public class PhoneServiceTest
    {
        [TestMethod]
        public void simplePhoneServiceTest() {

            IService service = new PhoneService();
            ICollection<PhoneModel> phones = service.listPhonesByUser(1);


            foreach (PhoneModel phone in phones) {
                Assert.AreEqual(1, phone.applicantId);
                if (phone.phoneCd.ToUpper().Equals("HM")){
                    Assert.AreEqual(5028011112, phone.phoneNumber);
                }
            }
        }
        [TestMethod]
        public void simplePhoneServiceTestWithFake() {
            IService service = new PhoneServiceFake();
            ICollection<PhoneModel> phones = service.listPhones();
            Assert.AreEqual(3, phones.Count);
        }
        [TestMethod]
        public void simplePhoneServiceByUserTestWithFake()
        {
            IService service = new PhoneServiceFake();
            ICollection<PhoneModel> phones = service.listPhonesByUser(1);
            Assert.AreEqual(2, phones.Count);
        }
    }
}
