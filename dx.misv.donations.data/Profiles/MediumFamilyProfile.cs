namespace dx.misv.donations.data.Profiles
{
    public class MediumFamilyProfile : BaseProfile, IProfile
    {
        public MediumFamilyProfile()
        {
            INCOMEselect = 5;
            AGEselect = new[] { 40, 60 };
            CHILDRENselect = new[] { 5, 30, 60, 80, 100 };
            DEVICEselect = new[] { 50, 80, 100 };
            EDUCATIONselect = new[] { 10, 55, 95, 100 };
            HOURselect = new[] { 9, 15 };
            INTERACTIONselect = new[] { 3, 10 };
            MARITALSTATUSselect = new[] { 5, 80, 100 };
            SEXselect = new[] { 40, 100 };
            ZIPselect = new[] { 300, 700 };
            AMOUNTselect = new[] { 1, 1 };
        }
    }
}