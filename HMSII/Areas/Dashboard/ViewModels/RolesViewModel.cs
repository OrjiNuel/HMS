using HMSII.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSII.Areas.Dashboard.ViewModels
{
    public class RolesListViewModel
    {
        public IEnumerable<IdentityRole> Roles { get; set; }

        public string SearchTerm { get; set; }

        public Pager Pager { get; set; }
    }

    public class RoleActionViewModel
    {
        public string ID { get; set; }

        public string Name { get; set; }
    }
}