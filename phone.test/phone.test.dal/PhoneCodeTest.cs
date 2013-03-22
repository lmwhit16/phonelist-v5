using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using scholarship.dal;
using scholarship.dal.Repositories;
using System.Collections.Generic;
using phone.dal;
namespace phone.test.dal
{
    [TestClass]
    public class PhoneCodeTest
    {
        private PhoneCodeRepo repo = null;
        private PhoneCD phone = null;
        private PhoneCD newPhone = null;

        [TestInitialize]
        public void phoneCodeSetup() {
            repo = new PhoneCodeRepo();
            newPhone = new PhoneCD();

            newPhone = new PhoneCD();
            newPhone.PHONE_CD = "BB";
            newPhone.PHONE_TX = "Home Phone Number";
            newPhone.MOD_DT = DateTime.Now;
            repo.add(newPhone);

            newPhone = new PhoneCD();
            newPhone.PHONE_CD = "CC";
            newPhone.PHONE_TX = "Home Phone Number";
            newPhone.MOD_DT = DateTime.Now;
            repo.add(newPhone);
        }

        [TestMethod]
        public void phoneCodeTest() {
            phone = repo.getById(new PhoneCD{PHONE_CD="BB"});
            Assert.AreEqual(newPhone.PHONE_TX, phone.PHONE_TX);

            phone.PHONE_TX = "New Home";
            repo.update(phone);

            newPhone = repo.getById(new PhoneCD { PHONE_CD = "BB" });
            Assert.AreEqual(newPhone.PHONE_TX, phone.PHONE_TX);

            phone.PHONE_TX = "Old Home";
            repo.update(phone);

            IEnumerable<PhoneCD> results = (IEnumerable<PhoneCD>)repo.query(t => t.PHONE_CD == phone.PHONE_CD);
            foreach(PhoneCD p in results){
                if (p.PHONE_CD == phone.PHONE_CD) {
                    Assert.AreEqual(newPhone.PHONE_TX, phone.PHONE_TX);
                }
            } 
        }
        [TestCleanup]
        public void cleanUp() {
            phone = repo.getById(new PhoneCD { PHONE_CD = "BB" });
            repo.remove(phone);
            phone = repo.getById(new PhoneCD { PHONE_CD = "BB" });
            Assert.AreEqual(null, phone);
            phone = repo.getById(new PhoneCD { PHONE_CD = "CC" });
            repo.remove(phone);
        }
    }
}
