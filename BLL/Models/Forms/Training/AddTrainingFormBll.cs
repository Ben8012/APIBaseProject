namespace BLL.Models.Forms.Training
{
    public class AddTrainingFormBll
    {
        public string Name { get; set; }
        public string Prerequisite { get; set; }
        public string Picture { get; set; }
        public bool IsSpeciality { get; set; }
        public int OrganisationId { get; set; }
    }
}
