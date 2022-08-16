using System.ComponentModel.DataAnnotations;

namespace HMSII.Entities
{
    public class Accomodation
    {
        [Key]
        public int ID { get; set; }

        public int AccomodationPackageID { get; set; }
        public virtual AccomodationPackage AccomodationPackage { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
