namespace dx.misv.donations.data.Profiles
{
    public class LargeEntrepreneurProfile : BaseProfile, IProfile
    {
        public LargeEntrepreneurProfile()
        {
            INCOMEselect = 10;
            AGEselect = new[] { 27, 40 };
            CHILDRENselect = new[] { 65, 90, 97, 99, 100 };
            DEVICEselect = new[] { 20, 50, 100 };
            EDUCATIONselect = new[] { 40, 90, 98, 100 };
            HOURselect = new[] { 5, 18 };
            INTERACTIONselect = new[] { 1, 5 };
            MARITALSTATUSselect = new[] { 40, 80, 100 };
            SEXselect = new[] { 70, 100 };
            ZIPselect = new[] { 1, 150 };
            AMOUNTselect = new[] { 1,1 };
        }
    }
}