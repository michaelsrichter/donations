namespace dx.misv.donations.data.Profiles
{
    public class SmallSeniorProfile : BaseProfile, IProfile
    {
        public SmallSeniorProfile()
        {
            INCOMEselect = -20;
            AGEselect = new[] { 60, 80 };
            CHILDRENselect = new[] { 80, 95, 99, 100 };
            DEVICEselect = new[] { 60, 80, 100 };
            EDUCATIONselect = new[] { 10, 60, 97, 100 };
            HOURselect = new[] { 6, 12 };
            INTERACTIONselect = new[] { 5, 20 };
            MARITALSTATUSselect = new[] { 20, 90, 100 };
            SEXselect = new[] { 45, 100 };
            ZIPselect = new[] { 1, 500 };
            AMOUNTselect = new[] { 1, 1 };
        }
    }
}