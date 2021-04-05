using System.Collections;
using System.Collections.Generic;
using Models;

namespace DNP_Handin1.Data
{
    public interface IFileAdapter
    {
        public List<Family> GetAllFamilies();
        public Family GetFamilyWithAdult(int adultId);
        public Family GetFamilyWithChild(int childId);
        public List<Adult> GetAllAdults();
        public Adult GetAdultById(int id);
        public void AddAdult(Adult adult);
        public void RemoveAdult(int id);
        public void EditAdult(Adult editedAdult);
        public List<Child> GetAllChildren();
        public Child GetChildById(int id);
        public void RemoveChild(int id);
        public void EditChild(Child editedChild);
        public List<Job> GetAllJobs();
    }
}