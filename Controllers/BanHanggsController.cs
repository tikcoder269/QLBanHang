using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLBH.Models;

namespace QLBH.Controllers
{
    public class BanHanggsController : Controller
    {
        private readonly QuanLyBanHangContext _context;

        public BanHanggsController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: BanHanggs
        public async Task<IActionResult> Index()
        {
            return View(await _context.BanHanggs.ToListAsync());
        }

        // GET: BanHanggs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banHangg = await _context.BanHanggs
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (banHangg == null)
            {
                return NotFound();
            }

            return View(banHangg);
        }

        // GET: BanHanggs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BanHanggs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,TenSp,HangSx,Dvt,SoLuong")] BanHangg banHangg)
        {
            if (ModelState.IsValid)
            {
                _context.Add(banHangg);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banHangg);
        }

        // GET: BanHanggs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banHangg = await _context.BanHanggs.FindAsync(id);
            if (banHangg == null)
            {
                return NotFound();
            }
            return View(banHangg);
        }

        // POST: BanHanggs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSp,TenSp,HangSx,Dvt,SoLuong")] BanHangg banHangg)
        {
            if (id != banHangg.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banHangg);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanHanggExists(banHangg.MaSp))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(banHangg);
        }

        // GET: BanHanggs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var banHangg = await _context.BanHanggs
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (banHangg == null)
            {
                return NotFound();
            }

            return View(banHangg);
        }

        // POST: BanHanggs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var banHangg = await _context.BanHanggs.FindAsync(id);
            _context.BanHanggs.Remove(banHangg);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BanHanggExists(int id)
        {
            return _context.BanHanggs.Any(e => e.MaSp == id);
        }
    }
}
