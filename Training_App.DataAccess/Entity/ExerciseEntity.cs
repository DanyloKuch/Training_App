using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_App.DataAccess.Entity
{
    public class ExerciseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Muscles { get; set; } = string.Empty;
        public int CountOfBasicSets { get; set; }
        public int CountOfWurmUpSets { get; set; }
        public decimal Weight { get; set; }
        public List<TrainingEntity> Training { get; set; } = new List<TrainingEntity>();
    }
}
