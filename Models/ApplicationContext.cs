using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoicesWpf.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<KirmashDBF> KirmashDBFs { get; set; }
        public DbSet<EInvocesXML> EInvocesXMLs { get; set; }
    }
}
