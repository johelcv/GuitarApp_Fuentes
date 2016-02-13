using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guitar.Entities;
using Guitar.DAC;

namespace Guitar.BL
{
    public class GuitarService : IGuitarService
    {
        private IGuitarRepositorio GuitarRepositorio; // = new GuitarRepositorio();

        //Agregando el Dependency Injection
        //--------------------------------------------------------
        public GuitarService(IGuitarRepositorio GuitarRepositorio)
        {
            this.GuitarRepositorio = GuitarRepositorio;
        }
        //--------------------------------------------------------

        public void Create(Project Model)
        {
            this.GuitarRepositorio.Create(Model);
        }

        public void Create(Guitars Model)
        {

            var Fecha1 = Model.StartDate;
            var Fecha2 = Model.PaintDate;
            var Fecha3 = Model.TestDate;
            var Fecha4 = Model.FinishDate;
            
            if (Fecha1 == Fecha2 && Fecha2 == Fecha3 && Fecha3 == Fecha4) { 

                throw new ApplicationException(
                    string.Format("This dates are invalid, they are all the same!!"));
            }

            this.GuitarRepositorio.Create(Model);
        }

        public IEnumerable<GuitarBody> GetAllGuitarBodys()
        {
            return this.GuitarRepositorio.GetAllGuitarBodys();
        }

        public IEnumerable<GuitarBridge> GetAllGuitarBridges()
        {
            return this.GuitarRepositorio.GetAllGuitarBridges();
        }

        public IEnumerable<GuitarNeck> GetAllGuitarNecks()
        {
            return this.GuitarRepositorio.GetAllGuitarNecks();
        }

        public IEnumerable<GuitarPickup> GetAllGuitarPickups()
        {
            return this.GuitarRepositorio.GetAllGuitarPickups();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            return this.GuitarRepositorio.GetAllProjects();
        }

        public Project GetOne(int Id)
        {
            return this.GuitarRepositorio.GetOne(Id);
        }

        public Guitars GetOneGuitar(int Id)
        {
            return this.GuitarRepositorio.GetOneGuitar(Id);
        }

        public void Update(Project Model)
        {
            this.GuitarRepositorio.Update(Model);
        }

        public void Delete(Project Model)
        {
            this.GuitarRepositorio.Delete(Model);
        }

        public IEnumerable<Guitars> GetGuitars()
        {
            return this.GuitarRepositorio.GetGuitars();
        }

        public void Update(Guitars Model)
        {
            this.GuitarRepositorio.Update(Model);
        }
    }
}
