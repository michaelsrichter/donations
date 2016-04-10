namespace dx.misv.donations.data.Profiles
{
    public class SmallFamilyProfile : BaseProfile, IProfile
    {
        public SmallFamilyProfile()
        {
            INCOMEselect = 10;
            AGEselect = new[] { 35, 55 };
            CHILDRENselect = new[] { 5, 45, 75, 95, 100 };
            DEVICEselect = new[] { 50, 80, 100 };
            EDUCATIONselect = new[] { 20, 60, 95, 100 };
            HOURselect = new[] { 9, 15 };
            INTERACTIONselect = new[] { 1, 15 };
            MARITALSTATUSselect = new[] { 10, 70, 100 };
            SEXselect = new[] { 45, 100 };
            ZIPselect = new[] { 700, 1000 };
            AMOUNTselect = new[] { 1, 1 };
        }
    }
}