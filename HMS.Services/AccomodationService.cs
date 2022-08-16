using HMSII.Data;
using HMSII.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class AccomodationService
    {
        public IEnumerable<Accomodation> GetAllAccomodations()
        {
            var context = new HMSContext();

            return context.Accomodations.ToList();
        }

        public IEnumerable<Accomodation> SearchAccomodation(string searchTerm, int? accomodationPackageID, int page, int pageSize)
        {

            var context = new HMSContext();

            var accomodation = context.Accomodations.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodation = accomodation.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accomodationPackageID.HasValue && accomodationPackageID.Value > 0)
            {
                accomodation = accomodation.Where(a => a.AccomodationPackageID == accomodationPackageID.Value);
            }

            var skip = (page - 1) * pageSize;

            return accomodation.OrderBy(x => x.AccomodationPackageID).Skip(skip).Take(pageSize).ToList();
        }

        public int SearchAccomodationCount(string searchTerm, int? accomodationPackageID)
        {

            var context = new HMSContext();

            var accomodation = context.Accomodations.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                accomodation = accomodation.Where(a => a.Name.ToLower().Contains(searchTerm.ToLower()));
            }

            if (accomodationPackageID.HasValue && accomodationPackageID.Value > 0)
            {
                accomodation = accomodation.Where(a => a.AccomodationPackageID == accomodationPackageID.Value);
            }

            return accomodation.Count();
        }

        public Accomodation GetAccomodationByID(int ID)
        {
            using (var context = new HMSContext())
            {
                return context.Accomodations.Find(ID);
            }
        }

        public bool SaveAccomodation(Accomodation accomodation)
        {
            var context = new HMSContext();

            context.Accomodations.Add(accomodation);

            return context.SaveChanges() > 0;
        }

        public bool UpdateAccomodation(Accomodation accomodation)
        {
            var context = new HMSContext();

            context.Entry(accomodation).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool DeleteAccomodation(Accomodation accomodation)
        {
            var context = new HMSContext();

            context.Entry(accomodation).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
