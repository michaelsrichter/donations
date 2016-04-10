using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using dx.misv.donations.data.Profiles;

namespace dx.misv.donations.data
{
    public class Program
    {
        private static void Main(string[] args)
        { 


            var seed = new Random();
            var records = new ZipsDataService().GetZips();
            var profiles = new List<IProfile>
            {
                new SmallSeniorProfile(),
                new SmallCollegeGradProfile(),
                new SmallHipsterProfile(),
                new SmallFamilyProfile(),
                new MediumFamilyProfile(),
                new MediumProfessionalProfile(),
                new LargeFamilyProfile(),
                new LargeEntrepreneurProfile()
            };


            var donaters = new List<Donater>();
            for (var i = 0; i < 100000; i++)
            {

                var d = profiles[seed.Next(0,profiles.Count)].GetDonater(seed, records);
                Console.ResetColor();
                if (d.Education == "P")
                    Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(d.Education + ", " + d.Income + ", " + d.Amount +  ", " + d.Profile);
                donaters.Add(d);
            }

            using (TextWriter writer = File.CreateText("C:\\projects\\fakedata.txt"))
            {
                var csvWriter = new CsvWriter(writer);
                csvWriter.WriteRecords(donaters);
            }

            Console.ReadLine();
           
        }
    }
}