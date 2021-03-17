﻿using System;
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