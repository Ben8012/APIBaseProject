namespace API.Models.Forms.Organisation
{
    public class AddOrganisationParticipeForm
    {
        public int UserId { get; set; }
        public int OrganisationId { get; set; }
        public int Level { get; set; }
        public string RefNumber { get; set; }
    }
}
