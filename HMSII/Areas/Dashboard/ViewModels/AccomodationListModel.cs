using HMSII.Entities;
using HMSII.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HMSII.Areas.Dashboard.ViewModels
{
    public class AccomodationListModel
    {
        public IEnumerable<Accomodation> Accomodations { get; set; }
        public string SearchTerm { get; set; }
        public IEnumerable<AccomodationPackage> AccomodationPackages { get; set; }
        public int? AccomodationPackageID { get; set; }

        public Pager Pager { get; set; }
    }

    public class AccomodationActionModel
    {
        [Key]
        public int ID { get; set; }

        public int AccomodationPackageID { get; set; }
        public AccomodationPackage AccomodationPackage { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<AccomodationPackage> AccomodationPackages { get; set; }
    }
}