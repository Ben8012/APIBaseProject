namespace DAL.Models.Forms.Training
{
    public class AddTrainingFormDal
    {
        public string Name { get; set; }
        public int PrerequisId { get; set; }
        public bool IsSpeciality { get; set; }
        public int OrganisationId { get; set; }

        public string Description { get; set; }
    }
}
