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
    public class BangBaoGiumsController : Controller
    {
        private readonly QuanLyBanHangContext _context;

        public BangBaoGiumsController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: BangBaoGiums
        public async Task<IActionResult> Index()
        {
            return View(await _context.BangBaoGia.ToListAsync());
        }

        // GET: BangBaoGiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bangBaoGium = await _context.BangBaoGia
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (bangBaoGium == null)
            {
                return NotFound();
            }

            return View(bangBaoGium);
        }

        // GET: BangBaoGiums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BangBaoGiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,SanPham,Dvt,Thue")] BangBaoGium bangBaoGium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bangBaoGium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bangBaoGium);
        }

        // GET: BangBaoGiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bangBaoGium = await _context.BangBaoGia.FindAsync(id);
            if (bangBaoGium == null)
            {
                return NotFound();
            }
            return View(bangBaoGium);
        }

        // POST: BangBaoGiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSp,SanPham,Dvt,Thue")] BangBaoGium bangBaoGium)
        {
            if (id != bangBaoGium.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bangBaoGium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BangBaoGiumExists(bangBaoGium.MaSp))
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
            return View(bangBaoGium);
        }

        // GET: BangBaoGiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bangBaoGium = await _context.BangBaoGia
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (bangBaoGium == null)
            {
                return NotFound();
            }

            return View(bangBaoGium);
        }

        // POST: BangBaoGiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bangBaoGium = await _context.BangBaoGia.FindAsync(id);
            _context.BangBaoGia.Remove(bangBaoGium);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BangBaoGiumExists(int id)
        {
            return _context.BangBaoGia.Any(e => e.MaSp == id);
        }
    }
}
