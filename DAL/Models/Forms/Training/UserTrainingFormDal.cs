using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Forms.Training
{
    public class UserTrainingFormDal
    {
        public int? Id { get; set; }

        public int UserId { get; set; }
        public int TrainingId { get; set; }
        public bool? IsMostlevel { get; set; }
        public string? RefNumber { get; set; }
    }
}
