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





        // Запись лота
        // api/DbPost/ZINMM_SOF_LOT_H/PostLot
        [HttpPost("ZINMM_SOF_LOT_H/PostLot")]
        public IActionResult PostLot([FromBody] ZINMM_SOF_LOT_H_DTO_REQUEST LotRequest)//получение элементов из  тела 
        {
            //создание класса таблицы и присваивание им элементов, которые получили из тела
            var results = new ZINMM_SOF_LOT_H
            {
                KONKURS_ID = LotRequest.KONKURS_ID,
                LOT_NR = LotRequest.LOT_NR,
                LOT_NAME = LotRequest.LOT_NAME,
                EKORG = LotRequest.EKORG,
                FINAN_LIMIT_WVAT = LotRequest.FINAN_LIMIT_WVAT,
                FINAN_LIMIT_WOVAT = LotRequest.FINAN_LIMIT_WOVAT,
                VAT_RATE = LotRequest.VAT_RATE,
                CALC_NDS = LotRequest.CALC_NDS

            };
            //добавление полученных элементов в таблицу 
            _context.ZINMM_SOF_LOT_H.Add(results);

            try
            {
                //сохранение изменений
                _context.SaveChanges();
            }
            catch (DbException ex)
            {
                //если произойдет ошибка записи, вывод ошибки
                return Problem(ex.Message);
            }
            //создание класса для вывода тех элементов, что мы записали в таблицу
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
            //вывод элементов, что мы внесли в таблицу
            //метод CreatedAtAction используется для единичного ответа. Требует 2 перегрузки: Название действия
            //В нашем случае название метода PostLot и объекта, который мы создали 
            return CreatedAtAction(nameof(PostLot), resDto);

        }

        //запись элементов для следующих таблиц происходит по такому же алгоритму

        // Запись процедуры
        // api/DbPost/ZTINMM_TK_H/PostProcedure
        [HttpPost("ZTINMM_TK_H/PostProcedure")]
        public IActionResult PostProcedure([FromBody] ZTINMM_TK_H_DTO_REQUEST ProcRequest)
        {

            var results = new ZTINMM_TK_H
            {
                KONKURS_NR = ProcRequest.KONKURS_NR,
                KONKURS_NAME = ProcRequest.KONKURS_NAME,
                BURKS = ProcRequest.BURKS,
                ORG_KEY = ProcRequest.ORG_KEY,
                STAT = ProcRequest.STAT,
                CRT_DATE = ProcRequest.CRT_DATE,
                CRT_TIME = ProcRequest.CRT_TIME,
                CRT_USER = ProcRequest.CRT_USER

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
        // Запись офферт
        // api/DbPost/ZTINMM_TK_H/PostProcedure
        [HttpPost("ZTINMM_TK_OFR/PostOffr")]
        public IActionResult PostOffr([FromBody] ZTINMM_TK_OFR_DTO_REQUEST OffrRequest)
        {

            var results = new ZTINMM_TK_OFR
            {
                KONKURS_ID = OffrRequest.KONKURS_ID,
                LOT_ID = OffrRequest.LOT_ID,
                TABIX = OffrRequest.TABIX,
                LIFNR = OffrRequest.LIFNR,
                LIFNR_NAME = OffrRequest.LIFNR_NAME,
                OFR_DATE = OffrRequest.OFR_DATE,
                OFR_TIME = OffrRequest.OFR_TIME,
                PRICE_NDS = OffrRequest.PRICE_NDS,
                PRICE_S_NDS = OffrRequest.PRICE_S_NDS,
                DELIVER_DATE = OffrRequest.DELIVER_DATE,
                DELIVER_TIME = OffrRequest.DELIVER_TIME,
                WIN_FLG = OffrRequest.WIN_FLG
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
        // запись единиц
        // api/DbPost/T001/PostBaseEds
        [HttpPost("T001/PostBaseEds")]
        
        public IActionResult PostBaseEds([FromBody] T001_DTO_REQUEST EdsRequest)
        {

            var results = new T001
            {
                BURKS = EdsRequest.BURKS,
                BUTXT = EdsRequest.BUTXT
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
