using Microsoft.EntityFrameworkCore;
using Practs.Modules.Main;

namespace Practs.Data
{
    public class DataBaseContext : DbContext //Создание Context класса с наследованием DbContext
    {


    public DataBaseContext(DbContextOptions<DataBaseContext> options) : base (options) { //создание конструктора options 
     

        }

        public DbSet<ZTINMM_TK_H> ZTINMM_TK_H { get; set; } //добавление в базу данных таблицу ZTINMM_TK_H
        public DbSet<ZINMM_SOF_LOT_H> ZINMM_SOF_LOT_H { get; set; } //добавление в базу данных таблицу ZINMM_SOF_LOT_H
        public DbSet<ZTINMM_TK_OFR> ZTINMM_TK_OFR { get; set; } //добавление в базу данных таблицу ZTINMM_TK_OFR
        public DbSet<T001> T001 { get; set; } //добавление в базу данных таблицу T001



    }
}
