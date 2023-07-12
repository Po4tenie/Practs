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
using Practs.Modules.DTO_Requests;
using Practs.Modules.Main;

namespace Practs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbPostController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public DbPostController(DataBaseContext dbContext)
        {
            _context = dbContext;
        }





        //Запись лота
        [HttpPost("ZINMM_SOF_LOT_H/PostLot")]
        public IActionResult PostLot([FromBody] ZINMM_SOF_LOT_H_DTO_REQUEST ZINMM_SOF_LOT_H_DTO_REQUEST)
        {

            var results = new ZINMM_SOF_LOT_H
            {
                KONKURS_ID = ZINMM_SOF_LOT_H_DTO_REQUEST.KONKURS_ID,
                LOT_NR = ZINMM_SOF_LOT_H_DTO_REQUEST.LOT_NR,
                LOT_NAME = ZINMM_SOF_LOT_H_DTO_REQUEST.LOT_NAME,
                EKORG = ZINMM_SOF_LOT_H_DTO_REQUEST.EKORG,
                FINAN_LIMIT_WVAT = ZINMM_SOF_LOT_H_DTO_REQUEST.FINAN_LIMIT_WVAT,
                FINAN_LIMIT_WOVAT = ZINMM_SOF_LOT_H_DTO_REQUEST.FINAN_LIMIT_WOVAT,
                VAT_RATE = ZINMM_SOF_LOT_H_DTO_REQUEST.VAT_RATE,
                CALC_NDS = ZINMM_SOF_LOT_H_DTO_REQUEST.CALC_NDS

            };
            _context.ZINMM_SOF_LOT_H.Add(results);
            try
            {
                _context.SaveChanges();
            }
            catch (DbException ex)
            {
                return Problem(ex.Message);
            }

            var resDto = new ZINMM_SOF_LOT_H_DTO
            {
                KONKURS_ID = results.KONKURS_ID,
                LOT_NR = results.LOT_NR,
                LOT_NAME = results.LOT_NAME,
                EKORG = results.EKORG,
                FINAN_LIMIT_WVAT = results.FINAN_LIMIT_WVAT,
                FINAN_LIMIT_WOVAT = results.FINAN_LIMIT_WOVAT,
                VAT_RATE = results.VAT_RATE,
                CALC_NDS = results.CALC_NDS



            };

            return CreatedAtAction(nameof(PostLot), resDto);

        }
        //Запись процедуры
        [HttpPost("ZTINMM_TK_H/PostProcedure")]
        public IActionResult PostProcedure([FromBody] ZTINMM_TK_H_DTO_REQUEST ZTINMM_TK_H_DTO_REQUEST)
        {

            var results = new ZTINMM_TK_H
            {
                KONKURS_NR = ZTINMM_TK_H_DTO_REQUEST.KONKURS_NR,
                KONKURS_NAME = ZTINMM_TK_H_DTO_REQUEST.KONKURS_NAME,
                BURKS = ZTINMM_TK_H_DTO_REQUEST.BURKS,
                ORG_KEY = ZTINMM_TK_H_DTO_REQUEST.ORG_KEY,
                STAT = ZTINMM_TK_H_DTO_REQUEST.STAT,
                CRT_DATE = ZTINMM_TK_H_DTO_REQUEST.CRT_DATE,
                CRT_TIME = ZTINMM_TK_H_DTO_REQUEST.CRT_TIME,
                CRT_USER = ZTINMM_TK_H_DTO_REQUEST.CRT_USER

            };
            _context.ZTINMM_TK_H.Add(results);
            try
            {
                _context.SaveChanges();
            }
            catch (DbException ex)
            {
                return Problem(ex.Message);
            }

            var resDto = new ZTINMM_TK_H_DTO
            {
                KONKURS_NR = results.KONKURS_NR,
                KONKURS_NAME = results.KONKURS_NAME,
                BURKS = results.BURKS,
                ORG_KEY = results.ORG_KEY,
                STAT = results.STAT,
                CRT_DATE = results.CRT_DATE,
                CRT_TIME = results.CRT_TIME,
                CRT_USER = results.CRT_USER



            };

            return CreatedAtAction(nameof(PostProcedure), resDto);

        }
        //Запись офферт
        [HttpPost("ZTINMM_TK_OFR/PostOffr")]
        public IActionResult PostOffr([FromBody] ZTINMM_TK_OFR_DTO_REQUEST ZTINMM_TK_OFR_DTO_REQUEST)
        {

            var results = new ZTINMM_TK_OFR
            {
                KONKURS_ID = ZTINMM_TK_OFR_DTO_REQUEST.KONKURS_ID,
                LOT_ID = ZTINMM_TK_OFR_DTO_REQUEST.LOT_ID,
                TABIX = ZTINMM_TK_OFR_DTO_REQUEST.TABIX,
                LIFNR = ZTINMM_TK_OFR_DTO_REQUEST.LIFNR,
                LIFNR_NAME = ZTINMM_TK_OFR_DTO_REQUEST.LIFNR_NAME,
                OFR_DATE = ZTINMM_TK_OFR_DTO_REQUEST.OFR_DATE,
                OFR_TIME = ZTINMM_TK_OFR_DTO_REQUEST.OFR_TIME,
                PRICE_NDS = ZTINMM_TK_OFR_DTO_REQUEST.PRICE_NDS,
                PRICE_S_NDS = ZTINMM_TK_OFR_DTO_REQUEST.PRICE_S_NDS,
                DELIVER_DATE = ZTINMM_TK_OFR_DTO_REQUEST.DELIVER_DATE,
                DELIVER_TIME = ZTINMM_TK_OFR_DTO_REQUEST.DELIVER_TIME,
                WIN_FLG = ZTINMM_TK_OFR_DTO_REQUEST.WIN_FLG
            };
            _context.ZTINMM_TK_OFR.Add(results);
            try
            {
                _context.SaveChanges();
            }
            catch (DbException ex)
            {
                return Problem(ex.Message);
            }

            var resDto = new ZTINMM_TK_OFR_DTO
            {
                KONKURS_ID = results.KONKURS_ID,
                LOT_ID = results.LOT_ID,
                TABIX = results.TABIX,
                LIFNR = results.LIFNR,
                LIFNR_NAME = results.LIFNR_NAME,
                OFR_DATE = results.OFR_DATE,
                OFR_TIME = results.OFR_TIME,
                PRICE_NDS = results.PRICE_NDS,
                PRICE_S_NDS = results.PRICE_S_NDS,
                DELIVER_DATE = results.DELIVER_DATE,
                DELIVER_TIME = results.DELIVER_TIME,
                WIN_FLG = results.WIN_FLG

            };

            return CreatedAtAction(nameof(PostLot), resDto);

        }

        [HttpPost("T001/PostBaseEds")]
        public IActionResult PostBaseEds([FromBody] T001_DTO_REQUEST ZTINMM_TK_OFR_DTO_REQUEST)
        {

            var results = new T001
            {
                BURKS = ZTINMM_TK_OFR_DTO_REQUEST.BURKS,
                BUTXT = ZTINMM_TK_OFR_DTO_REQUEST.BUTXT
            };
            _context.T001.Add(results);
            try
            {
                _context.SaveChanges();
            }
            catch (DbException ex)
            {
                return Problem(ex.Message);
            }

            var resDto = new T001_DTO
            {
                BURKS = results.BURKS,
                BUTXT = results.BUTXT
            };

            return CreatedAtAction(nameof(PostLot), resDto);

        }


    }
}
