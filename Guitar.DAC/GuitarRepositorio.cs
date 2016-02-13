using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guitar.Entities;
using Dapper;

namespace Guitar.DAC
{
    public class GuitarRepositorio : IGuitarRepositorio
    {
        private string ConnectionString = null;

        public GuitarRepositorio()
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings["GuitarDB"].ConnectionString;
        }

        public void Create(Project Model)
        {

            var context = new GuitarDbContext();
            context.Project.Add(Model);
            context.SaveChanges();
        }

        public void Create(Guitar.Entities.Guitars Model)
        {
            var context = new GuitarDbContext();
            context.Guitar.Add(Model);
            context.SaveChanges();
        }

        public IEnumerable<GuitarBody> GetAllGuitarBodys()
        {
            IEnumerable<GuitarBody> result = new List<GuitarBody>();

            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                result = con.Query<GuitarBody>("usp_obtener_body", commandType: System.Data.CommandType.StoredProcedure);
                con.Close();
            }

            return result;
        }

        public IEnumerable<GuitarBridge> GetAllGuitarBridges()
        {
            IEnumerable<GuitarBridge> result = new List<GuitarBridge>();

            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                result = con.Query<GuitarBridge>("usp_obtener_bridge", commandType: System.Data.CommandType.StoredProcedure);
                con.Close();
            }

            return result;
        }

        public IEnumerable<GuitarNeck> GetAllGuitarNecks()
        {
            IEnumerable<GuitarNeck> result = new List<GuitarNeck>();

            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                result = con.Query<GuitarNeck>("usp_obtener_neck", commandType: System.Data.CommandType.StoredProcedure);
                con.Close();
            }

            return result;
        }

        public IEnumerable<GuitarPickup> GetAllGuitarPickups()
        {
            IEnumerable<GuitarPickup> result = new List<GuitarPickup>();

            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                result = con.Query<GuitarPickup>("usp_obtener_pickup", commandType: System.Data.CommandType.StoredProcedure);
                con.Close();
            }

            return result;
        }

        public IEnumerable<Project> GetAllProjects()
        {
            IEnumerable<Project> result = new List<Project>();

            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                result = con.Query<Project>("usp_obtener_proyectos", commandType: System.Data.CommandType.StoredProcedure);
                con.Close();
            }

                return result;
        }

        public Project GetOne(int id)
        {
            IEnumerable<Project> result = new List<Project>();
            Project res = new Project();

            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();

                var p = new DynamicParameters();
                p.Add("@xId", id);
                result = con.Query<Project>("GetOne", p, commandType: System.Data.CommandType.StoredProcedure);
                con.Close();
            }

            //var context = new GuitarDbContext();

            //var query = (from p in context.Project
            //             join gb in context.GuitarBody on p.BodyID equals gb.Id
            //             where p.Id == id
            //             select new { name = p.Name, description = p.Description, body = gb.Description });


            res = result.FirstOrDefault();

            return res;
        }

        public void Update(Project Model)
        {
            var context = new GuitarDbContext();
            context.Entry(Model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Project Model)
        {
            var context = new GuitarDbContext();
            context.Entry(Model).State = System.Data.Entity.EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Guitars> GetGuitars()
        {
            var entities = new GuitarDbContext();

            var query = (from c in entities.Guitar
                         select c).ToList();
            return query;
        }

        public void Update(Guitars Model)
        {
            var context = new GuitarDbContext();
            context.Entry(Model).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Guitars GetOneGuitar(int id)
        {
            IEnumerable<Guitars> result = new List<Guitars>();
            Guitars res = new Guitars();

            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();

                var p = new DynamicParameters();
                p.Add("@xId", id);
                result = con.Query<Guitars>("GetOneGuitar", p, commandType: System.Data.CommandType.StoredProcedure);
                con.Close();
            }

            res = result.FirstOrDefault();

            return res;
        }
    }
}
