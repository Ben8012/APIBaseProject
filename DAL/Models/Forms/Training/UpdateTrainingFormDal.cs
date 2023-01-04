namespace DAL.Models.Forms.Training
{
    public class UpdateTrainingFormDal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prerequisite { get; set; }
        public string Picture { get; set; }
        public bool IsSpeciality { get; set; }
        public int OrganisationId { get; set; }
    }
}
