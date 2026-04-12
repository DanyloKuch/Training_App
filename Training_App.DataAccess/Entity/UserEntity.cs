using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Training_App.Domain.Models;

namespace Training_App.DataAccess.Entity
{
    public class UserEntity : IdentityUser<Guid>
    {
        public ICollection<TrainingEntity> Training { get; set; }
        public ICollection<ExerciseEntity> Exercises { get; set; }
        public ICollection<MusclesEntity> Muscles { get; set; } 

    }
}
