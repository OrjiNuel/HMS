using HMSII.Entities;
using HMSII.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HMSII.Areas.Dashboard.ViewModels
{
    public class UsersListModel
    {
        public IEnumerable<HMSUser> Users { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
        public string RoleID { get; set; }

        public string SearchTerm { get; set; }
        public Pager Pager { get; set; }
    }

    public class UserActionViewModel
    {
        public string ID { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }

    public class UserRolesModel
    {
        public string UserID { get; set; }

        public IEnumerable<IdentityRole> UserRoles { get; set; }

        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}