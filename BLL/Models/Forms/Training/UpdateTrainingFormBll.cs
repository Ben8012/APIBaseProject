namespace BLL.Models.Forms.Training
{
    public class UpdateTrainingFormBll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prerequisite { get; set; }
        public string Picture { get; set; }
        public bool IsSpeciality { get; set; }
        public int OrganisationId { get; set; }
        public string Description { get; set; }
    }
}
