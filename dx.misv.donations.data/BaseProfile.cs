using System;
using System.Collections.Generic;
using System.Linq;

namespace dx.misv.donations.data
{
    public abstract class BaseProfile
    {
        protected string[] EDUCATION = new string[] { "H", "C", "G", "P" };
        protected string[] MARITALSTATUS = new string[] { "S", "M", "D" };
        protected string[] CHILDREN = new string[] { "0", "1", "2", "3", "4" };
        protected string[] DEVICE = new string[] { "W", "M", "A" };
        protected string[] SEX = new string[] { "M","F" };

        protected string GetValues(string[] values, int itemNumber)
        {
            return values[itemNumber];
        }

        protected int GetNearestIndexInArray(int[]array, int val)
        {
            var newArray = array;
            var arrayVal = newArray.OrderBy(x => Math.Abs((long)x - val)).First();
            return Array.IndexOf(array, arrayVal);
        }

        public Donater GetDonater(Random seed, IEnumerable<ZipsAndIncome> Zips)
        {
            var education = GetValues(EDUCATION, GetNearestIndexInArray(EDUCATIONselect, seed.Next(0, 101)));
            var maritalstatus = GetValues(MARITALSTATUS, GetNearestIndexInArray(MARITALSTATUSselect, seed.Next(0, 101)));
            var children = GetValues(CHILDREN, GetNearestIndexInArray(CHILDRENselect, seed.Next(0, 101)));
            var device = GetValues(DEVICE, GetNearestIndexInArray(DEVICEselect, seed.Next(0, 101)));
            var sex = GetValues(SEX, GetNearestIndexInArray(SEXselect, seed.Next(0, 101)));
            var age = seed.Next(AGEselect[0], AGEselect[1] + 1);
            var hour = seed.Next(HOURselect[0], HOURselect[1] + 1);
            var interaction = seed.Next(INTERACTIONselect[0], INTERACTIONselect[1] + 1);
            var zipId = seed.Next(ZIPselect[0], ZIPselect[1] + 1);
            var zips = Zips.Select(z => z.Rank).ToArray();
            var ZipRank = zips[GetNearestIndexInArray(zips, zipId)];
            var ZipCode = Zips.First(z => z.Rank == ZipRank);
            var weekday = seed.Next(1, 8);
            var month = seed.Next(1, 13);
            var income = ZipCode.Income + (INCOMEselect * .01);
            income = UpdateIncome(income, education, maritalstatus);
            var amount = income * (seed.Next(AMOUNTselect[0], AMOUNTselect[1] + 1) * .001);
            
            var donater = new Donater
            {
                Education = education,
                MaritalStatus = maritalstatus,
                Children = children,
                Device = device,
                Sex = sex,
                Age = age,
                Hour = hour,
                Interactions = interaction,
                Zip = ZipCode.Zip,
                Income = Convert.ToInt32(income),
                WeekDay = weekday,
                Month = month,
                Amount = Convert.ToInt32(amount),
                Profile = this.GetType().Name
                
            };
            donater.Amount = UpdateAmount(donater);
            return donater;
        }

        protected int UpdateIncome(double originalIncome, string education, string married)
        {
            double modifier = 0;
            switch (education)
            {
                case "H": { modifier += originalIncome * -.15; break; }
                case "C": { modifier += 0; break; }
                case "G": { modifier += originalIncome * .20; break; }
                default: { modifier += originalIncome * .35; break; }
            }

            switch (married)
            {
                case "S": { modifier += originalIncome * -.05; break; }
                case "M": { modifier += originalIncome * .35; break; }
                default: { modifier += originalIncome * .15; break; }
            }
            var rawIncome = originalIncome + modifier;

            return 500*(int) Math.Round(rawIncome/500);
        }

        protected int UpdateAmount(Donater donater)
        {
            var originalAmount = donater.Amount;
            double modifier = 0;
            switch (donater.Device)
            {
                case "W": { modifier += originalAmount * .1; break; }
                case "M": { modifier += originalAmount * -.1; break; }
                default: { modifier += originalAmount * -.15; break; }
            }

            if (donater.Hour >= 1 && donater.Hour <= 8)
            {
                modifier += originalAmount * -.01;
            }

            if (donater.Hour >= 9 && donater.Hour <= 17)
            {
                modifier += originalAmount * .01;
            }

            if (donater.Interactions >= 6 && donater.Interactions <= 10)
            {
                modifier += originalAmount * .01;
            }

            if (donater.Interactions >= 10)
            {
                modifier += originalAmount * .02;
            }

            switch (donater.Device)
            {
                case "H": { modifier += originalAmount * -.01; break; }
                case "C": { modifier += 0; break; }
                default:  { modifier += originalAmount * .01; break; }
            }

            switch (donater.MaritalStatus)
            {
                case "S": { modifier += originalAmount * .01; break; }
                case "M": { modifier += 0; break; }
                default: { modifier += originalAmount * -.01; break; }
            }
            var children = Convert.ToInt32(donater.Children);
            if (children > 0)
            {
                modifier += originalAmount * (Convert.ToInt32(donater.Children) * -.01);
            }

            var rawAmount = originalAmount + modifier;

            return 10 * (int)Math.Round(rawAmount / 10);
        }

        protected int[] SEXselect;
        protected int[] EDUCATIONselect;
        protected int[] MARITALSTATUSselect;
        protected int[] CHILDRENselect;
        protected int[] DEVICEselect;
        protected int[] AGEselect;
        protected int[] ZIPselect;
        protected int[] INTERACTIONselect;
        protected int[] HOURselect;
        protected int[] AMOUNTselect;
        protected int INCOMEselect;
    }
}