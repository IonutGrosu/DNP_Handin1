using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FileData;
using Models;

namespace DNP_Handin1.Data
{
    public class FileAdapter : IFileAdapter
    {
        private FileContext FileContext = new FileContext();
        private int AdultID = 15;

        public List<Family> GetAllFamilies()
        {
            return (List<Family>) FileContext.Families;
        }

        public Family GetFamilyWithAdult(int adultId)
        {
            foreach (Family family in GetAllFamilies())
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

        public Family GetFamilyWithChild(int childId)
        {
            foreach (Family family in GetAllFamilies())
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

        public List<Adult> GetAllAdults()
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

        public Adult GetAdultById(int id)
        {
            return FileContext.Adults.FirstOrDefault(adult => adult.Id == id);
        }

        public void AddAdult(Adult adult)
        {
            adult.Id = AdultID++;
            // FileContext.Adults.Add(adult);
            // FileContext.SaveChanges();
            Console.WriteLine(JsonSerializer.Serialize(adult, new JsonSerializerOptions
            {
                WriteIndented = true
            }));
        }

        public void RemoveAdult(int id)
        {
            FileContext.Adults.Remove(FileContext.Adults.First(t => t.Id==id));
            FileContext.SaveChanges();
        }

        public void EditAdult(Adult editedAdult)
        {
            foreach (Adult fileContextAdult in FileContext.Adults)
            {
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

        public List<Child> GetAllChildren()
        {
            List<Child> allChildren = new List<Child>();
            foreach (Family family in GetAllFamilies())
            {
                foreach (Child familyChild in family.Children)
                {
                    allChildren.Add(familyChild);
                }
            }
            return allChildren;
        }

        public Child GetChildById(int id)
        {
            return GetAllChildren().FirstOrDefault(child => child.Id == id);
        }

        public void RemoveChild(int id)
        {
            foreach (Family fileContextFamily in FileContext.Families)
            {
                fileContextFamily.Children.Remove(fileContextFamily.Children.FirstOrDefault(t => t.Id == id));
            }
            FileContext.SaveChanges();
        }

        public void EditChild(Child editedChild)
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

        public List<Job> GetAllJobs()
        {
            List<Job> jobs = new List<Job>();
            List<Adult> adults = GetAllAdults();
            foreach (Adult adult in adults)
            {
                jobs.Add(adult.JobTitle);
            }

            return jobs;
        }
    }
}