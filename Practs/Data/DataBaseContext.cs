using Microsoft.EntityFrameworkCore;
using Practs.Modules.Main;

namespace Practs.Data
{
    public class DataBaseContext : DbContext
    {


    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base (options) { 
     

        }

        public DbSet<ZTINMM_TK_H> ZTINMM_TK_H { get; set; }
        public DbSet<ZINMM_SOF_LOT_H> ZINMM_SOF_LOT_H { get; set; }
        public DbSet<ZTINMM_TK_OFR> ZTINMM_TK_OFR { get; set; }
        public DbSet<T001> T001 { get; set; }



    }
}
