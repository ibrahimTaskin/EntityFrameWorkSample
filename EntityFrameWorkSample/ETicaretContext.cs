using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkSample
{
    class ETicaretContext:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
