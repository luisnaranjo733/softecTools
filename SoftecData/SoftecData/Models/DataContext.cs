    using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftecData.Models
{
    public class DataContext : DbContext
    {
        public DbSet<DataItem> DataItems { get; set; }
    }
}
