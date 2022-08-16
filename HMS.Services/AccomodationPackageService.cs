using HMSII.Data;
using HMSII.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationPackageService
    {
        public IEnumerable<AccomodationPackage> GetAllAccomodationPackages()
        {
            var context = new HMSContext();

            return context.AccomodationPackages.ToList();
        }

        public IEnumerable<AccomodationPackage> SearchAccomodationPackages(string searchTerm, int? accomodationTypeID, int page, int pageSize)
        {
            var context = new HMSContext();

            var accomodationPackages = context.AccomodationPackages.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationPackages = accomodationPackages.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }
            if (accomodationTypeID.HasValue && accomodationTypeID.Value > 0)
            {
                accomodationPackages = accomodationPackages.Where(a => a.AccomodationTypeID == accomodationTypeID.Value);
            }

            var skip = (page - 1) * pageSize;
            // skip = (1  -  1) = 0 * 4 = 0
            // skip = (2  -  1) = 1 * 4 = 4
            // skip = (3  -  1) = 2 * 4 = 8
            // skip = (4  -  1) = 3 * 4 = 12

            return accomodationPackages.OrderBy(x => x.AccomodationType.Name).Skip(skip).Take(pageSize).ToList();
        }

        public int SearchAccomodationPackagesCount(string searchTerm, int? accomodationTypeID)
        {
            var context = new HMSContext();

            var accomodationPackages = context.AccomodationPackages.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodationPackages = accomodationPackages.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }
            if (accomodationTypeID.HasValue && accomodationTypeID.Value > 0)
            {
                accomodationPackages = accomodationPackages.Where(a => a.AccomodationTypeID == accomodationTypeID.Value);
            }

            return accomodationPackages.Count();
        }

        public AccomodationPackage GetAccomodationPackageByID(int ID)
        {
            using (var context = new HMSContext())
            {
                return context.AccomodationPackages.Find(ID);
            }   
        }

        public bool SaveAccomodationPackage(AccomodationPackage accomodationPackage)
        {
            var context = new HMSContext();

            context.AccomodationPackages.Add(accomodationPackage);

            return context.SaveChanges() > 0;
        }

        public bool UpdateAccomodationPackage(AccomodationPackage accomodationPackage)
        {
            var context = new HMSContext();

            try
            {
                context.Entry(accomodationPackage).State = System.Data.Entity.EntityState.Modified;
            }
            catch (Exception e)
            {
                
            }

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccomodationPackage(AccomodationPackage accomodationPackage)
        {
            var context = new HMSContext();

            context.Entry(accomodationPackage).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
