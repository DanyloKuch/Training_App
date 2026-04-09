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
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }
        public Guid? CreatedByUserId { get; set; }
        public UserEntity User { get; set; }
        public ICollection<ExerciseSetEntity> ExerciseSets { get; set; }
        public ICollection<ExerciseMusclesEntity> ExerciseMuscles { get; set; }
    }
}
