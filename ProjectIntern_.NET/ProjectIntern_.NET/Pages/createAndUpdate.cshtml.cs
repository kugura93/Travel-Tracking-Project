using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ProjectIntern_.NET.Data;
using ProjectIntern_.NET.Models;

namespace ProjectIntern_.NET.Pages
{
    public class createAndUpdateModel : PageModel
    {
        private readonly ProjectIntern_.NET.Data.ProjectIntern_NETContext _context;

        public createAndUpdateModel(ProjectIntern_.NET.Data.ProjectIntern_NETContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ES_YDENPYO? ES_YDENPYO { get; set; }
        [BindProperty]
        public BUMON? BUMON { get; set; }
        [BindProperty]
        public ES_YDENPYOD? ES_YDENPYOD { get; set; }
        public IList<ES_YDENPYO>? listES_YDENPYO { get; set; } = default!;
        public IList<BUMON>? listBUMON { get; set; } = default!;
        public IList<ES_YDENPYOD>? listES_YDENPYOD_ById { get; set; } = default!;
        public IList<ES_YDENPYOD>? listES_YDENPYOD_Tbl { get; set; } = default!;
        public SelectList YearGenerator { get; set; }
        public int? kaikeiND { get; set; }
        public string? suitoKB { get; set; }
        public DateTime? denpyoDT { get; set; }
        public DateTime? uketukeDT { get; set; }
        public DateTime? shiharaiDT { get; set; }
        public int? denpyoNO { get; set; }
        public string? bumonCD { get; set; }
        public string? bumonNM { get; set; }
        public string? biko { get; set; }
        public string? bumonCD_YKANR { get; set; }
        public int? kingaku { get; set; }
        public List<SelectListItem> YearGen => Enumerable.Range(1970, (DateTime.Now.Year - 1970) + 2)
        .Select(es => new SelectListItem
        {
            Value = es.ToString(),
            Text = es.ToString()
        }).ToList();

        public List<SelectListItem> SuitoKB => _context.ES_YDENPYO
            //.Select(es => es.suitoKB)
            //.Distinct()
            .Select(es => new SelectListItem
            {
                Value = es.suitoKB,
                Text = es.suitoKB
            }).Distinct().ToList();

        public async Task<IActionResult> OnGetAsync(int? denpyoNO)
        {
            ES_YDENPYO = await _context.ES_YDENPYO.FirstOrDefaultAsync(m => m.denpyoNO == denpyoNO);

            if (ES_YDENPYO == null)
            {
                BUMON = null;
            }
            else
            {
                BUMON = await _context.BUMON.FirstOrDefaultAsync(bm => bm.bumonCD == ES_YDENPYO.bumonCD_YKANR);
            }



            listES_YDENPYOD_ById = await _context.ES_YDENPYOD.Where(esd => esd.denpyoNO == denpyoNO).OrderBy(es => es.gyoNO).ToListAsync();


            listES_YDENPYO = await _context.ES_YDENPYO.ToListAsync();

            listBUMON = await _context.BUMON.ToListAsync();

            int maxGyoNoId = (from e in _context.ES_YDENPYOD
                              where e.denpyoNO == denpyoNO
                              select e.gyoNO).DefaultIfEmpty().Max() + 1;
            ViewData["maxGyoNoId"] = maxGyoNoId;


            var maxId = (from e in _context.ES_YDENPYO
                         select e.denpyoNO).DefaultIfEmpty().Max() + 1;
            ViewData["maxId"] = maxId;

            return Page();
        }

        public async Task<IActionResult> OnGetSearchBumon(string? bumonCD, string? bumonNM)
        {
            //query search bumon in modal
            var query = from bm in _context.BUMON
                        select bm;
            if (!string.IsNullOrEmpty(bumonCD))
            {
                query = query.Where(bm => bm.bumonCD == bumonCD);
            }

            if (!string.IsNullOrEmpty(bumonNM))
            {
                query = query.Where(bm => bm.bumonNM.ToLower().Contains(bumonNM.ToLower()));
            }

            //display modal
            if (!string.IsNullOrEmpty(bumonCD) || !string.IsNullOrEmpty(bumonNM))
            {
                listBUMON = await query.ToListAsync();
            }
            else
            {
                listBUMON = await _context.BUMON.ToListAsync();

            }

            return new JsonResult(new { code = 200, listBUMON = listBUMON, mgs = "Success" });
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(ES_YDENPYO es, int? denpyoNO)
        {
            var maxId = (from e in _context.ES_YDENPYO
                         select e.denpyoNO).Max() + 2;

            if (ModelState.IsValid)
            {

                if (denpyoNO == null)
                {
                    return Page();
                }

                if (RecordExists(ES_YDENPYO.denpyoNO))
                {
                    var recordUpdate = ES_YDENPYO;
                    recordUpdate.bumonCD_YKANR = BUMON.bumonCD;
                    if (await TryUpdateModelAsync<ES_YDENPYO>(
                        recordUpdate, "record",
                        es => es.denpyoNO, es => es.denpyoDT, es => es.suitoKB, es => es.kaikeiND, es => es.biko, es => es.uketukeDT, es => es.shiharaiDT,
                        es => es.bumonCD_YKANR, es => es.kingaku))
                    {
                        _context.Update(ES_YDENPYO);
                        await _context.SaveChangesAsync();
                    }
                    return RedirectToPage("/home");

                }
                else
                {
                    var emptyRecord = new ES_YDENPYO();
                    ES_YDENPYO.bumonCD_YKANR = BUMON.bumonCD;
                    if (await TryUpdateModelAsync<ES_YDENPYO>(
                        emptyRecord, "records",
                        es => es.denpyoDT, es => es.suitoKB, es => es.kaikeiND, es => es.biko, es => es.uketukeDT, es => es.shiharaiDT,
                        es => es.bumonCD_YKANR, es => es.kingaku))
                    {
                        _context.ES_YDENPYO.Add(ES_YDENPYO);
                        await _context.SaveChangesAsync();
                    }
                    return Redirect("/edit/" + maxId);
                }

            }

            return Page();
        }

        public async Task<IActionResult> OnPostSaveYdenpyoD(List<Temp> updateData)
        {
            var maxId = (from e in _context.ES_YDENPYO
                         select e.denpyoNO).Max() + 1;

            //gan gia tri cho item cua updatedata
            if (updateData.Count > 0)
            {
                foreach (var item in updateData)
                {
                    if (item.denpyoNO == maxId)
                    {
                        Thread.Sleep(100);
                    }
                }
                foreach (var item in updateData)
                {
                    var testData = new ES_YDENPYOD();
                    testData.denpyoNO = item.denpyoNO;
                    testData.gyoNO = item.gyoNO;
                    testData.shuppatsuPLC = item.shuppatsuPLC;
                    testData.idoDT = item.idoDT;
                    testData.mokutekiPLC = item.mokutekiPLC;
                    testData.keiro = item.keiro;
                    testData.kingaku = item.kingaku;


                    if (RecordExistsYdenpyoD(item.denpyoNO, item.gyoNO))
                    {
                        if (!item.isDelete)
                        {
                            _context.Update(testData);
                        }
                        else
                        {
                            _context.ES_YDENPYOD.Remove(testData);
                        }
                    }
                    else
                    {
                        if (!item.isDelete)
                        {
                            _context.ES_YDENPYOD.Add(testData);
                        }
                    }
                    await _context.SaveChangesAsync();
                }
                return new JsonResult(new { code = 0, msg = "success" });
            }
            return new JsonResult(new { code = 0, msg = "failed" });
        }

        public async Task<IActionResult> OnGetDelete(int denpyoNO)
        {
            var es = await _context.ES_YDENPYO.FindAsync(denpyoNO);
            if (es == null)
            {
                return NotFound();

            }
            _context.ES_YDENPYO.Remove(es);

            await _context.SaveChangesAsync();

            return new JsonResult("");
        }

        public bool RecordExists(int? denpyoNO)
        {
            return _context.ES_YDENPYO.Any(e => e.denpyoNO == denpyoNO);
        }

        public bool RecordExistsYdenpyoD(int? denpyoNO, int? gyoNO)
        {
            return _context.ES_YDENPYOD.Any(n => n.denpyoNO == denpyoNO && n.gyoNO == gyoNO);
        }
    }
}
