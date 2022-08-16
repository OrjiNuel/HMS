using HMSII.Entities;
using HMSII.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSII.Areas.Dashboard.ViewModels
{
    public class AccomodationPackageListingModel
    {
        public IEnumerable<AccomodationPackage> AccomodationPackages { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
        public int? AccomodationTypeID { get; set; }

        public Pager Pager { get; set; }
    }

    public class AccomodationPackageActionModel
    {
        [Key]
        public int ID { get; set; }

        public int AccomodationTypeID { get; set; }
        public AccomodationType AccomodationType { get; set; }

        public string Name { get; set; }
        public int NoOfRoom { get; set; }
        public decimal FeePerNight { get; set; }

        public IEnumerable<AccomodationType> AccomodationTypes { get; set; }
    }
}