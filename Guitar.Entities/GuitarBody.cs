using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar.Entities
{
    public partial class GuitarBody
    {
        public GuitarBody()
        {
            this.Projects = new HashSet<Project>();
        }

        public int Id { get; set; }

        public String Name { get; set; }
        public String Description { get; set; }

        public virtual IEnumerable<Project> Projects { get; set; }
    }
}
