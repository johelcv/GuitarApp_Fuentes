using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Guitar.Entities
{
    public partial class Guitars
    {
        public Guitars()
        {
            Reviews = new HashSet<Review>();
        }

        [Key]
        public int Id { get; set; }
            
        public String Name { get; set; }
        public String Description { get; set; }

        
        public int BodyID { get; set; }
        
        public int NeckID { get; set; }
        
        public int BridgeID { get; set; }
        
        public int PickupID { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime PaintDate { get; set; }
        public DateTime TestDate { get; set; }
        public DateTime FinishDate { get; set; }

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

        [NotMapped]
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
