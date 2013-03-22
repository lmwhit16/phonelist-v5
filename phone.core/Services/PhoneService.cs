using phone.core.Models;
using phone.dal;
using phone.dal.respositories;
using scholarship.dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phone.core.Services
{
    public class PhoneService : phone.core.Services.IService
    {
        public ICollection<PhoneModel> listPhonesByUser(decimal userId){
            PhoneRepo phoneRepo = new PhoneRepo();
            IEnumerable<Phone> phones = phoneRepo.query(p => p.APPLICANT_ID == userId);

            ICollection<PhoneModel> phoneModels = new List<PhoneModel>();
            PhoneModel phoneModel = null;
            foreach (Phone p1 in phones)
            {
                phoneModel = new PhoneModel();
                phoneModel.phoneCd = p1.PHONE_CD;
                phoneModel.phoneNumber = p1.PHONE_TX;
                phoneModel.lastModifiedDate = p1.MOD_DT;
                phoneModel.applicantId = userId;
                phoneModel.createDate = p1.CREATE_DT;
                phoneModel.phoneId = p1.PHONE_ID;
                
                phoneModels.Add(phoneModel);
            }
            phoneRepo = null;
            return phoneModels;
        }

        public ICollection<PhoneModel> listPhones()
        {
            PhoneRepo phoneRepo = new PhoneRepo();
            IEnumerable<Phone> phones = phoneRepo.getAll();

            ICollection<PhoneModel> phoneModels = new List<PhoneModel>();
            PhoneModel phoneModel = null;
            foreach (Phone phoneData in phones)
            {
                phoneModel = new PhoneModel();
                phoneModel.phoneCd = phoneData.PHONE_CD;
                phoneModel.phoneNumber = phoneData.PHONE_TX;
                phoneModel.lastModifiedDate = phoneData.MOD_DT;
                phoneModel.applicantId = phoneData.APPLICANT_ID;
                phoneModel.createDate = phoneData.CREATE_DT;
                phoneModel.phoneId = phoneData.PHONE_ID;

                phoneModels.Add(phoneModel);
            }
            phoneRepo = null;
            return phoneModels;
        }


        public PhoneModel getPhoneById(decimal phoneId)
        {
            PhoneRepo phoneRepo = new PhoneRepo();
            Phone phoneData = phoneRepo.getById(new Phone{PHONE_ID=phoneId});
            PhoneModel phoneModel = new PhoneModel();
            phoneModel.phoneId = phoneData.PHONE_ID;
            phoneModel.applicantId = phoneData.APPLICANT_ID;
            phoneModel.createDate = phoneData.CREATE_DT;
            phoneModel.lastModifiedDate = phoneData.MOD_DT;
            phoneModel.phoneCd = phoneData.PHONE_CD;
            phoneModel.phoneNumber = phoneData.PHONE_TX;

            return phoneModel;
        }




        public ICollection<PhoneCodeModel> getPhoneCds()
        {
            ICollection<PhoneCodeModel> codeModels = new List<PhoneCodeModel>();

            PhoneCodeRepo repo = new PhoneCodeRepo();
            PhoneCD[] codes = repo.getAll();
            foreach (PhoneCD codeData in codes) {
                PhoneCodeModel codeModel = new PhoneCodeModel();
                codeModel.lastModifiedDate = codeData.MOD_DT;
                codeModel.phoneCode = codeData.PHONE_CD;
                codeModel.phoneCodeDescription = codeData.PHONE_TX;
                codeModels.Add(codeModel);
            }
            return codeModels;
        }
    }
}
