using OnlineInspection.Domain.Abstract;
using OnlineInspection.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineInspection.Domain.Concrete
{
    public class EFSupplierRepository : ISupplierRepository
    {
        private readonly EFDbContext context = new EFDbContext();

        public IEnumerable<Supplier> Suppliers
        {
            get { return context.Suppliers; }
        }

        public Supplier DeleteSupplier(int supplierId)
        {
            Supplier DbEntry = context.Suppliers.Find(supplierId);
            if (DbEntry != null)
            {
                context.Suppliers.Remove(DbEntry);
                context.SaveChanges();
            }
            return DbEntry;
        }

        public void SaveSupplier(Supplier supplier)
        {
            if (supplier.SupplierId == 0)
            {
                context.Suppliers.Add(supplier);
            }
            else
            {
                Supplier Dbentry = context.Suppliers.Find(supplier.SupplierId);
                if (Dbentry != null)
                {
                    Dbentry.CompanyName = supplier.CompanyName;
                    Dbentry.Contact = supplier.Contact;
                    Dbentry.Email = supplier.Email;
                }
            }
            context.SaveChanges();
        }
    }
}
