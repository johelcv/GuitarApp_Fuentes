using Guitar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guitar.DAC
{
    public interface IGuitarRepositorio
    {
        IEnumerable<Project> GetAllProjects();
        Project GetOne(int id);
        Guitars GetOneGuitar(int id);
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
