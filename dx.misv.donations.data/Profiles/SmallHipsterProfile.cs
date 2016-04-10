namespace dx.misv.donations.data.Profiles
{
    public class SmallHipsterProfile : BaseProfile, IProfile
    {
        public SmallHipsterProfile()
        {
            INCOMEselect = -30;
            AGEselect = new[] { 25, 35 };
            CHILDRENselect = new[] { 60, 94, 98, 99, 100 };
            DEVICEselect = new[] { 20, 60, 100 };
            EDUCATIONselect = new[] { 30, 70, 90, 100 };
            HOURselect = new[] { 20, 24 };
            INTERACTIONselect = new[] { 1, 10 };
            MARITALSTATUSselect = new[] { 75, 95, 100 };
            SEXselect = new[] { 30, 100 };
            ZIPselect = new[] { 200, 1000 };
            AMOUNTselect = new[] { 1, 1 };
        }
    }
}