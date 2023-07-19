using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practs.Data;
using Practs.Modules;
using Practs.Modules.DTO;
using Practs.Modules.Report;
using Practs.Modules.DTO_Requests;
using Practs.Modules.Main;


namespace Practs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbGetController : ControllerBase //Класс контроллера, отвечающий за вывод данных.
    {
        private readonly DataBaseContext _context;

        public DbGetController(DataBaseContext context)
        {
            //получение переменной DataBaseContext
            _context = context;
        }

        // получение процедур с возможностью ограничения выборки
        // api/DbGet/ZTINMM_TK_H/GetAllProcedures
        [HttpGet("ZTINMM_TK_H/GetAllProcedures")]

        public IActionResult GetAllProcedures(int Restriction) {
            var temp = _context.ZTINMM_TK_H.ToList(); //создание списка из класса элементов таблицы.

            var results = new List<ZTINMM_TK_H_DTO>(); //создание списка из класса ZTINMM_TK_H_DTO
            foreach (var item in temp)
            {
                results.Add(new ZTINMM_TK_H_DTO() //добавление в список элементов из класса ZTINMM_TK_H_DTO, которым присваивается информация из класса элементов таблицы
                {
                    KONKURS_ID = item.KONKURS_ID,
                    KONKURS_NR = item.KONKURS_NR,
                    KONKURS_NAME = item.KONKURS_NAME,
                    BURKS = item.BURKS,
                    ORG_KEY = item.ORG_KEY,
                    STAT = item.STAT,
                    CRT_DATE = item.CRT_DATE,
                    CRT_TIME = item.CRT_TIME,
                    CRT_USER = item.CRT_USER,
                });

            }
            return Ok(results.Take(Restriction)); //вывод списка с ограничением выборки


        }
        // Данные процедуры по KONKURS_ID
        // api/DbGet/ZTINMM_TK_H/GetProcedureById
        [HttpGet("ZTINMM_TK_H/GetProcedureById")] 
        public IActionResult GetProcedureId(int id)
        {
            var Res = _context.ZTINMM_TK_H.Find(id); //поиск строки со значением ключевого элемента по заданному значению int id 
            if (Res == null) {
                return NotFound(); //проверка на нахождение. Если элемент не нашелся, вызывается ответ с 404 ошибкой

            }
            return Ok(Res); //вывод строки 
        }
        // Данные лота по LOT_ID лота
        // api/DbGet/ZINMM_SOF_LOT_H/GetLotById
        [HttpGet("ZINMM_SOF_LOT_H/GetLotById")] 
        public IActionResult GetLotById(int id)
        {

            var Res = _context.ZINMM_SOF_LOT_H.Find(id);
            if (Res == null)
            {
                return NotFound();

            }
            return Ok(Res);
        }
        // Список всех лотов по KONKURS_ID процедуры
        // api/DbGet/ZINMM_SOF_LOT_H/GetLotByProcId
        [HttpGet("ZINMM_SOF_LOT_H/GetLotByProcId")]
        public IActionResult GetLotsByProcId(int id)
        {
            var Res = _context.ZINMM_SOF_LOT_H.Where(x => x.KONKURS_ID == id.ToString()); // поиск строки с совпадением значения элемента таблицы с заданным значением
            if (Res == null)
            {
                return NotFound();

            }
            return Ok(Res);
        }
        // Список всех оферт по LOT_ID лота
        // api/DbGet/ZTINMM_TK_OFR/GetOffersByLotId
        [HttpGet("ZTINMM_TK_OFR/GetOffersByLotId")]
        
        public IActionResult GetOffersByLotId(int id)
        {
            var Res = _context.ZTINMM_TK_OFR.Where(x => x.LOT_ID == id.ToString());
            if (Res == null)
            {
                return NotFound();

            }
            return Ok(Res);
        }
        // Данные оферт  по TABIX оферты
        // api/DbGet/ZINMM_TK_OFR/GetOffersByTABIX
        [HttpGet("ZINMM_TK_OFR/GetOffersByTABIX")] 
        public IActionResult GetOffersByTABIX(int tabix)
        {
            var ResultId = _context.ZTINMM_TK_OFR.Where(x=>x.TABIX == tabix);
            if (ResultId == null)
            {
                return NotFound();

            }
            return Ok(ResultId);
        }
        // Вывод отчета
        // api/DbGet/Report
        [HttpGet("Report")]
        
        public IActionResult GetReport(int Restriction) {
            //получение списка из элементов таблиц. Понадобится в будущем. 
            var temp1 = _context.ZTINMM_TK_H.ToList();
            var temp2 = _context.ZINMM_SOF_LOT_H.ToList();
            var temp3 = _context.ZTINMM_TK_OFR.ToList();
            var temp4 = _context.T001.ToList();

            //отчет состоит из двух частей
            //заполним первую часть
            var list1 = new FirstPart(); //конструирование класса для первой части
            list1.Date = DateTime.Now; //записываем текущее время
            list1.ProcCount = temp1.Count; //считываем количество процедур
            foreach (var item in temp4) {
                list1.CompName += item.BUTXT+", "; //записываем имена компаний
            }

            //заполняем вторую часть
            //для второй части необходимо выводить все данные из таблиц
            var list2 = new SecondPart();
            list2.ZTINMM_TK_H1 = new ZTINMM_TK_H();
            foreach (var item in temp1) {
                list2.ZTINMM_TK_H1.KONKURS_ID = item.KONKURS_ID;
                list2.ZTINMM_TK_H1.KONKURS_NR = item.KONKURS_NR;
                list2.ZTINMM_TK_H1.KONKURS_NAME = item.KONKURS_NAME;
                list2.ZTINMM_TK_H1.BURKS = item.BURKS;
                list2.ZTINMM_TK_H1.ORG_KEY = item.ORG_KEY;
                list2.ZTINMM_TK_H1.STAT = item.STAT;
                list2.ZTINMM_TK_H1.CRT_DATE = item.CRT_DATE;
                list2.ZTINMM_TK_H1.CRT_TIME = item.CRT_TIME;
                list2.ZTINMM_TK_H1.CRT_USER = item.CRT_USER;
            
            }
            list2.ZINMM_SOF_LOT_H1 = new ZINMM_SOF_LOT_H();
            foreach (var item in temp2) {
                list2.ZINMM_SOF_LOT_H1.LOT_ID = item.LOT_ID;
                list2.ZINMM_SOF_LOT_H1.LOT_NR = item.LOT_NR;
                list2.ZINMM_SOF_LOT_H1.LOT_NAME = item.LOT_NAME;
                list2.ZINMM_SOF_LOT_H1.EKORG = item.EKORG;
                list2.ZINMM_SOF_LOT_H1.FINAN_LIMIT_WVAT = item.FINAN_LIMIT_WVAT;
                list2.ZINMM_SOF_LOT_H1.FINAN_LIMIT_WOVAT = item.FINAN_LIMIT_WOVAT;
                list2.ZINMM_SOF_LOT_H1.VAT_RATE = item.VAT_RATE;
                list2.ZINMM_SOF_LOT_H1.CALC_NDS = item.CALC_NDS;
            
            }
            list2.ZTINMM_TK_OFR1 = new ZTINMM_TK_OFR();
            foreach (var item in temp3) { 
                list2.ZTINMM_TK_OFR1.TABIX = item.TABIX;
                list2.ZTINMM_TK_OFR1.LIFNR = item.LIFNR;
                list2.ZTINMM_TK_OFR1.LIFNR_NAME = item.LIFNR_NAME;
                list2.ZTINMM_TK_OFR1.OFR_DATE = item.OFR_DATE;
                list2.ZTINMM_TK_OFR1.OFR_TIME = item.OFR_TIME;
                list2.ZTINMM_TK_OFR1.PRICE_NDS = item.PRICE_NDS;
                list2.ZTINMM_TK_OFR1.PRICE_S_NDS = item.PRICE_S_NDS;
                list2.ZTINMM_TK_OFR1.DELIVER_DATE = item.DELIVER_DATE;
                list2.ZTINMM_TK_OFR1.DELIVER_TIME = item.DELIVER_TIME;
                list2.ZTINMM_TK_OFR1.WIN_FLG = item.WIN_FLG;
            
            }
            var report = new List<REPORT_REQUEST_DTO> //формируем список класса для отчета, состоящий из двух частей, что мы собирали ранее
            {
                new REPORT_REQUEST_DTO()
                {
                    FirstPart = list1,
                    SecondPart = list2

                }
            };

            if (report == null) {
                return NotFound();
            }
            return Ok(report.Take(Restriction)); //вывод отчета с ограничением выборки 
        }

    }
}
