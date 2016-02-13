using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guitar.Entities;

namespace Guitar.BL
{
    public interface IGuitarService
    {
        Project GetOne(int Id);
        Guitars GetOneGuitar(int Id);
        IEnumerable<Project> GetAllProjects();
        void Create(Project Model);
        void Create(Guitars Model);
        IEnumerable<GuitarBody> GetAllGuitarBodys();
        IEnumerable<GuitarNeck> GetAllGuitarNecks();
        IEnumerable<GuitarBridge> GetAllGuitarBridges();
        IEnumerable<GuitarPickup> GetAllGuitarPickups();
        void Update(Project Model);
        void Delete(Project Model);
        IEnumerable<Guitars> GetGuitars();
        void Update(Guitars Model);
    }
}
