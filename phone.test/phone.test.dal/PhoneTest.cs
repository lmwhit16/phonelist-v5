using Microsoft.VisualStudio.TestTools.UnitTesting;
using phone.dal;
using phone.dal.respositories;
using scholarship.dal;
using scholarship.dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scholarship.test.dal.tests
{
    [TestClass]
    public class PhoneTest
    {
        private PhoneRepo phoneRepo;
        private PhoneCodeRepo codeRepo;

        [TestInitialize]
        public void setup() {
            codeRepo = new PhoneCodeRepo();
            codeRepo.add(new PhoneCD { PHONE_CD = "AA", PHONE_TX = "Home", MOD_DT = DateTime.Now });
            codeRepo.add(new PhoneCD { PHONE_CD = "BB", PHONE_TX = "Mobile", MOD_DT = DateTime.Now });
            codeRepo.add(new PhoneCD { PHONE_CD = "CC", PHONE_TX = "Work", MOD_DT = DateTime.Now });

            phoneRepo = new PhoneRepo();
            phoneRepo.add(new Phone { PHONE_CD = "AA", PHONE_TX = 5028011112, MOD_DT = DateTime.Now, APPLICANT_ID = 1, CREATE_DT = DateTime.Now });
            phoneRepo.add(new Phone { PHONE_CD = "BB", PHONE_TX = 5028011113, MOD_DT = DateTime.Now, APPLICANT_ID = 1, CREATE_DT = DateTime.Now });
            phoneRepo.add(new Phone { PHONE_CD = "CC", PHONE_TX = 5028011114, MOD_DT = DateTime.Now, APPLICANT_ID = 1, CREATE_DT = DateTime.Now });

        }
        [TestMethod]
        public void phoneTest() {
            PhoneCD phoneCd = codeRepo.getById(new PhoneCD { PHONE_CD="AA"});
            Assert.AreNotEqual(null, phoneCd, "Test Data is NOT in the DB");

            IQueryable<Phone> phones = phoneRepo.query(p => p.PHONE_CD == "AA" || p.PHONE_CD == "BB" || p.PHONE_CD == "CC");
            Assert.AreEqual(3, phones.Count());
        }
        [TestCleanup]
        public void cleanUp() {
            //delete from phone where PHONE_CD='AA' or PHONE_CD='BB' or PHONE_CD='CC'
            //delete from PhoneCD where  PHONE_CD='AA' or PHONE_CD='BB' or PHONE_CD='CC'

            IQueryable<Phone> phones = phoneRepo.query(p => p.PHONE_CD == "AA" || p.PHONE_CD == "BB" || p.PHONE_CD == "CC");
            foreach (Phone p in phones.ToList<Phone>()) {
                phoneRepo.remove(p);
            }

            IQueryable<PhoneCD> codes = codeRepo.query(c => c.PHONE_CD == "AA" || c.PHONE_CD == "BB" || c.PHONE_CD == "CC");
            foreach (PhoneCD code in codes.ToList<PhoneCD>()) {
                codeRepo.remove(code); 
            }
        }
    }
}

