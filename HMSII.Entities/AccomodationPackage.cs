using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HMSII.Entities
{
    public class AccomodationPackage
    {
        [Key]
        public int ID { get; set; }

        public int AccomodationTypeID { get; set; }
        public virtual AccomodationType AccomodationType { get; set; }

        public string Name { get; set; }
        public int NoOfRoom { get; set; }
        public decimal FeePerNight { get; set; }
    }
}
