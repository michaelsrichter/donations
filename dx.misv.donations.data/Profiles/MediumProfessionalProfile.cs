namespace dx.misv.donations.data.Profiles
{
    public class MediumProfessionalProfile : BaseProfile, IProfile
    {
        public MediumProfessionalProfile()
        {
            INCOMEselect = -5;
            AGEselect = new[] { 25, 40 };
            CHILDRENselect = new[] { 60, 85, 95, 98, 100 };
            DEVICEselect = new[] { 20, 60, 100 };
            EDUCATIONselect = new[] { 10, 30, 90, 100 };
            HOURselect = new[] { 8, 18 };
            INTERACTIONselect = new[] { 1, 5 };
            MARITALSTATUSselect = new[] { 60, 93, 100 };
            SEXselect = new[] { 70, 100 };
            ZIPselect = new[] { 200, 600 };
            AMOUNTselect = new[] { 1, 1 };
        }
    }
}