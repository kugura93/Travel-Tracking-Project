using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using ProjectIntern_.NET.Data;
using ProjectIntern_.NET.Models;

namespace ProjectIntern_.NET.Pages
{
    public class homeModel : PageModel
    {
        private readonly ProjectIntern_.NET.Data.ProjectIntern_NETContext _context;

        public homeModel(ProjectIntern_.NET.Data.ProjectIntern_NETContext context)
        {
            _context = context;
        }

        public IList<ES_YDENPYO> ES_YDENPYO { get; set; } = default!;
        public SelectList YearGenerator { get; set; }
        public int? kaikeiND { get; set; }
        public string? suitoKBOpt1 { get; set; }
        public string? suitoKBOpt2 { get; set; }
        public DateTime? denpyoDTFrom { get; set; }
        public DateTime? denpyoDTTo { get; set; }
        public DateTime? uketukeDTFrom { get; set; }
        public DateTime? uketukeDTTo { get; set; }
        public int? denpyoNOFrom { get; set; }
        public int? denpyoNOTo { get; set; }
        public List<SelectListItem> YearGen => Enumerable.Range(1970, (DateTime.Now.Year - 1970) + 2)
        .Select(es => new SelectListItem
        {
            Value = es.ToString(),
            Text = es.ToString()
        }).ToList();

        public List<SelectListItem> SuitoKB => _context.ES_YDENPYO
            .Select(es => new SelectListItem
            {
                Value = es.suitoKB,
                Text = es.suitoKB
            }).Distinct().ToList();

        public async Task OnGetAsync(int? kaikeiND, int? denpyoNOFrom, int? denpyoNOTo, string? suitoKBOpt1, string? suitoKBOpt2, DateTime? denpyoDTFrom, DateTime? denpyoDTTo,
                                        DateTime? uketukeDTFrom, DateTime? uketukeDTTo)
        {
            //get list records
            var query = from es in _context.ES_YDENPYO
                        select es;

            //get maxID
            var maxId = (from es in _context.ES_YDENPYO
                         select es.denpyoNO).Max() + 1;
            ViewData["maxId"] = maxId;
            //kaikeiND search
            if (kaikeiND != null)
            {
                query = query.Where(es => es.kaikeiND.Equals(kaikeiND)).OrderBy(e => e.kaikeiND);
            }
            //denpyoNO search
            if (denpyoNOFrom != null && denpyoNOTo != null)
            {
                query = query.Where(es => es.denpyoNO >= denpyoNOFrom && es.denpyoNO <= denpyoNOTo).OrderBy(e => e.denpyoNO);
            }
            else if (denpyoNOFrom != null)
            {
                query = query.Where(es => es.denpyoNO >= denpyoNOFrom).OrderBy(e => e.denpyoNO);
            }
            else if (denpyoNOTo != null)
            {
                query = query.Where(es => es.denpyoNO <= denpyoNOTo).OrderBy(e => e.denpyoNO);
            }
            //denpyoDT search
            if (denpyoDTFrom != null && denpyoDTTo != null)
            {
                query = query.Where(es => es.denpyoDT >= denpyoDTFrom && es.denpyoDT <= denpyoDTTo).OrderBy(e => e.denpyoDT);
            }
            else if (denpyoDTFrom != null)
            {
                query = query.Where(es => es.denpyoDT >= denpyoDTFrom).OrderBy(e => e.denpyoDT);
            }
            else if (denpyoDTTo != null)
            {
                query = query.Where(es => es.denpyoDT <= denpyoDTTo).OrderBy(e => e.denpyoDT);
            }
            //uketukeDT search
            if (uketukeDTFrom != null && uketukeDTTo != null)
            {
                query = query.Where(es => es.uketukeDT >= uketukeDTFrom && es.uketukeDT <= uketukeDTTo).OrderBy(e => e.uketukeDT);
            }
            else if (uketukeDTFrom != null)
            {
                query = query.Where(es => es.uketukeDT >= uketukeDTFrom).OrderBy(e => e.uketukeDT);
            }
            else if (uketukeDTTo != null)

            {
                query = query.Where(es => es.uketukeDT <= uketukeDTTo).OrderBy(e => e.uketukeDT);
            }
            //suitoKB search
            if (!string.IsNullOrEmpty(suitoKBOpt1) || !string.IsNullOrEmpty(suitoKBOpt2))
            {
                query = query.Where(es => es.suitoKB == suitoKBOpt1 || es.suitoKB == suitoKBOpt2).OrderBy(e => e.suitoKB);
            }   

            //display
            if (kaikeiND != null || denpyoNOFrom != null || denpyoNOTo != null || denpyoDTFrom != null || denpyoDTTo != null || uketukeDTFrom != null || uketukeDTTo != null || !string.IsNullOrEmpty(suitoKBOpt1) || !string.IsNullOrEmpty(suitoKBOpt2))
            {
                ES_YDENPYO = await query.ToListAsync();
            }
            else
            {
                ES_YDENPYO = await _context.ES_YDENPYO.ToListAsync();
            }

        }

    }
}
