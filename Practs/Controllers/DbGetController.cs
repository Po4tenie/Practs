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
    public class DbGetController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public DbGetController(DataBaseContext context)
        {
            _context = context;
        }

        // получение процедур с возможностью ограничения выборки
        [HttpGet("ZTINMM_TK_H/GetAllProcedures")]

        public IActionResult GetAllProcedures(int Restriction) {
            var temp = _context.ZTINMM_TK_H.ToList();

            var results = new List<ZTINMM_TK_H_DTO>();
            foreach (var item in temp)
            {
                results.Add(new ZTINMM_TK_H_DTO()
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
            return Ok(results.Take(Restriction));


        }
        [HttpGet("ZTINMM_TK_H/GetProcedureById")] //Данные процедуры по KONKURS_ID 
        public IActionResult GetProcedureId(int id)
        {
            var Res = _context.ZTINMM_TK_H.Find(id);
            if (Res == null) {
                return NotFound();

            }
            return Ok(Res);
        }
        [HttpGet("ZINMM_SOF_LOT_H/GetLotById")] // Данные лота по LOT_ID лота
        public IActionResult GetLotById(int id)
        {

            var Res = _context.ZINMM_SOF_LOT_H.Find(id);
            if (Res == null)
            {
                return NotFound();

            }
            return Ok(Res);
        }
        [HttpGet("ZINMM_SOF_LOT_H/GetLotByProcId")] // Список всех лотов по KONKURS_ID процедуры
        public IActionResult GetLotsByProcId(int id)
        {
            var Res = _context.ZINMM_SOF_LOT_H.Where(x => x.KONKURS_ID == id.ToString());
            if (Res == null)
            {
                return NotFound();

            }
            return Ok(Res);
        }
        
        [HttpGet("ZTINMM_TK_OFR/GetOffersByLotId")] //  Список всех оферт по LOT_ID лота
        
        public IActionResult GetOffersByLotId(int id)
        {
            var Res = _context.ZTINMM_TK_OFR.Where(x => x.LOT_ID == id.ToString());
            if (Res == null)
            {
                return NotFound();

            }
            return Ok(Res);
        }

        [HttpGet("ZINMM_TK_OFR/GetOffersByTABIX")] // Данные оферт  по TABIX оферты
        public IActionResult GetOffersByTABIX(int tabix)
        {
            var ResultId = _context.ZTINMM_TK_OFR.Where(x=>x.TABIX == tabix);
            if (ResultId == null)
            {
                return NotFound();

            }
            return Ok(ResultId);
        }

        [HttpGet("Report")]

        public IActionResult GetReport(int Restriction) {

            var temp1 = _context.ZTINMM_TK_H.ToList();
            var temp2 = _context.ZINMM_SOF_LOT_H.ToList();
            var temp3 = _context.ZTINMM_TK_OFR.ToList();
            var temp4 = _context.T001.ToList();

            var list1 = new FirstPart();
            list1.Date = DateTime.Now;
            list1.ProcCount = temp1.Count;
            foreach (var item in temp4) {
                list1.CompName = item.BUTXT;
            }

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
            var report = new List<REPORT_REQUEST_DTO>
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
            return Ok(report.Take(Restriction));
        }

    }
}
