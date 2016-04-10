namespace dx.misv.donations.data.Profiles
{
    public class LargeFamilyProfile : BaseProfile, IProfile
    {
        public LargeFamilyProfile()
        {
            INCOMEselect = -1;
            AGEselect = new[] { 38, 63 };
            CHILDRENselect = new[] { 1, 41, 71, 91, 100 };
            DEVICEselect = new[] { 50, 60, 100 };
            EDUCATIONselect = new[] { 5, 35, 95, 100 };
            HOURselect = new[] { 7, 15 };
            INTERACTIONselect = new[] { 5, 15 };
            MARITALSTATUSselect = new[] { 5, 85, 100 };
            SEXselect = new[] { 35, 100 };
            ZIPselect = new[] {1, 350};
            AMOUNTselect = new[] {1, 1};
        }
    }
}