using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guitar.Entities
{
    public partial class Project
    {
        [Key]
        public int Id { get; set; }
            
        [Required(ErrorMessage ="Debe ingresar el nombre")]
        public String Name { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripcion")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Seleccionar un body")]
        [Display(Name ="Body")]
        public int BodyID { get; set; }

        [Required(ErrorMessage = "Seleccionar un neck")]
        [Display(Name = "Neck")]
        public int NeckID { get; set; }

        [Required(ErrorMessage = "Seleccionar un bridge")]
        [Display(Name = "Bridge")]
        public int BridgeID { get; set; }

        [Required(ErrorMessage = "Seleccionar pickups")]
        [Display(Name = "Pickup")]
        public int PickupID { get; set; }

        [Display(Name = "Imagen")]
        public string ImgProject { get; set; }

        [ForeignKey("BodyID")]
        public virtual GuitarBody GuitarBody { get; set; }
        [ForeignKey("NeckID")]
        public virtual GuitarNeck GuitarNeck { get; set; }
        [ForeignKey("BridgeID")]
        public virtual GuitarBridge GuitarBridge { get; set; }
        [ForeignKey("PickupID")]
        public virtual GuitarPickup GuitarPickup { get; set; }

        [NotMapped]
        public string Bridge { get; set; }
        [NotMapped]
        public string Neck { get; set; }
        [NotMapped]
        public string Body { get; set; }
        [NotMapped]
        public string Pickup { get; set; }
    }
}
