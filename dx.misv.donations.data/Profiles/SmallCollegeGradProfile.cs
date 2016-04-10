namespace dx.misv.donations.data.Profiles
{
    public class SmallCollegeGradProfile : BaseProfile, IProfile
    {
        public SmallCollegeGradProfile()
        {
            INCOMEselect = -10;
            AGEselect = new[] { 20, 27 };
            CHILDRENselect = new[] { 80, 90, 95, 99, 100 };
            DEVICEselect = new[] { 40, 60, 100 };
            EDUCATIONselect = new[] { 1, 81, 96, 100 };
            HOURselect = new[] { 20, 24 };
            INTERACTIONselect = new[] { 1, 10 };
            MARITALSTATUSselect = new[] { 80, 95, 100 };
            SEXselect = new[] { 40, 100 };
            ZIPselect = new[] { 200, 1000 };
            AMOUNTselect = new[] { 1, 1 };
        }
    }
}