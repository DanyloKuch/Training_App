using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training_App.DataAccess.Entity
{
    public class ApplicationUserEntity
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<TrainingEntity> TrainingEntity { get; set; }
    }
}
