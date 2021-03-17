using System.Collections;
using System.Collections.Generic;
using Models;

namespace DNP_Handin1.Data
{
    public interface IFileAdapter
    {
        public List<Family> GetAllFamilies();
        public Family GetFamilyWithAdult(int adultId);
        public List<Adult> GetAllAdults();
        public Adult GetAdultById(int id);
        public void AddAdult(Adult adult);
        public void RemoveAdult(int id);
        public List<Job> GetAllJobs();
    }
}