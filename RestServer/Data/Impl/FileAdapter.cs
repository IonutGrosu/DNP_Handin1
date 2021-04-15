using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using FileData;
using Models;

namespace DNP_Handin1.Data
{
    public class FileAdapter : IFileAdapter
    {
        private FileContext FileContext = new FileContext();
        private int AdultID = 15;

        public async Task<List<Family>> GetAllFamiliesAsync()
        {
            return (List<Family>) FileContext.Families;
        }

        public async Task<Family> GetFamilyWithAdultAsync(int adultId)
        {
            foreach (Family family in GetAllFamiliesAsync().Result)
            {
                foreach (Adult familyAdult in family.Adults)
                {
                    if (familyAdult.Id == adultId)
                    {
                        return family;
                    }
                }
            }

            return null;
        }

        public async Task<Family> GetFamilyWithChildAsync(int childId)
        {
            foreach (Family family in GetAllFamiliesAsync().Result)
            {
                foreach (Child familyChild in family.Children)
                {
                    if (familyChild.Id == childId)
                    {
                        return family;
                    }
                }
            }

            return null;
        }

        public async Task<List<Adult>> GetAllAdultsAsync()
        {
            foreach (Adult fileContextAdult in FileContext.Adults)
            {
                if (fileContextAdult.Id > AdultID)
                {
                    AdultID = fileContextAdult.Id;
                }
            }
            return (List<Adult>) FileContext.Adults;
        }

        public async Task<Adult> GetAdultByIdAsync(int id)
        {
            return FileContext.Adults.FirstOrDefault(adult => adult.Id == id);
        }

        public async Task AddAdultAsync(Adult adult)
        {
            adult.Id = AdultID++;
            // FileContext.Adults.Add(adult);
            // FileContext.SaveChanges();
            //TODO uncomment this
            Console.WriteLine(JsonSerializer.Serialize(adult, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }

        public async Task RemoveAdultAsync(int id)
        {
            FileContext.Adults.Remove(FileContext.Adults.First(t => t.Id==id));
            FileContext.SaveChanges();
        }

        public async Task EditAdultAsync(Adult editedAdult)
        {
            foreach (Adult fileContextAdult in FileContext.Adults)
            {
                if (fileContextAdult.Id == editedAdult.Id)
                {
                    fileContextAdult.JobTitle = editedAdult.JobTitle;
                    fileContextAdult.FirstName = editedAdult.FirstName;
                    fileContextAdult.LastName = editedAdult.LastName;
                    fileContextAdult.HairColor = editedAdult.HairColor;
                    fileContextAdult.EyeColor = editedAdult.EyeColor;
                    fileContextAdult.Age = editedAdult.Age;
                    fileContextAdult.Weight = editedAdult.Weight;
                    fileContextAdult.Height = editedAdult.Height;
                    fileContextAdult.Sex = editedAdult.Sex;
                }
            }

            foreach (Family fileContextFamily in FileContext.Families)
            {
                foreach (Adult adult in fileContextFamily.Adults)
                {
                    if (adult.Id == editedAdult.Id)
                    {
                        adult.JobTitle = editedAdult.JobTitle;
                        adult.FirstName = editedAdult.FirstName;
                        adult.LastName = editedAdult.LastName;
                        adult.HairColor = editedAdult.HairColor;
                        adult.EyeColor = editedAdult.EyeColor;
                        adult.Age = editedAdult.Age;
                        adult.Weight = editedAdult.Weight;
                        adult.Height = editedAdult.Height;
                        adult.Sex = editedAdult.Sex;
                    }
                }
            }
            
            FileContext.SaveChanges();
        }

        public async Task<List<Child>> GetAllChildrenAsync()
        {
            List<Child> allChildren = new List<Child>();
            foreach (Family family in GetAllFamiliesAsync().Result)
            {
                foreach (Child familyChild in family.Children)
                {
                    allChildren.Add(familyChild);
                }
            }
            return allChildren;
        }

        public async Task<Child> GetChildByIdAsync(int id)
        {
            return GetAllChildrenAsync().Result.FirstOrDefault(child => child.Id == id);
        }

        public async Task RemoveChildAsync(int id)
        {
            foreach (Family fileContextFamily in FileContext.Families)
            {
                fileContextFamily.Children.Remove(fileContextFamily.Children.FirstOrDefault(t => t.Id == id));
            }
            FileContext.SaveChanges();
        }

        public async Task EditChildAsync(Child editedChild)
        {
            foreach (Family fileContextFamily in FileContext.Families)
            {
                foreach (Child child in fileContextFamily.Children)
                {
                    if (child.Id == editedChild.Id)
                    {
                        child.FirstName = editedChild.FirstName;
                        child.LastName = editedChild.LastName;
                        child.HairColor = editedChild.HairColor;
                        child.EyeColor = editedChild.EyeColor;
                        child.Age = editedChild.Age;
                        child.Weight = editedChild.Weight;
                        child.Height = editedChild.Height;
                        child.Sex = editedChild.Sex;
                    }
                }
            }
            
            FileContext.SaveChanges();
        }

        public async Task<List<Job>> GetAllJobsAsync()
        {
            List<Job> jobs = new List<Job>();
            List<Adult> adults = GetAllAdultsAsync().Result;
            foreach (Adult adult in adults)
            {
                jobs.Add(adult.JobTitle);
            }

            return jobs;
        }
    }
}