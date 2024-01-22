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
    public class SanPhammsController : Controller
    {
        private readonly QuanLyBanHangContext _context;

        public SanPhammsController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: SanPhamms
        public async Task<IActionResult> Index()
        {
            return View(await _context.SanPhamms.ToListAsync());
        }

        // GET: SanPhamms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamm = await _context.SanPhamms
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPhamm == null)
            {
                return NotFound();
            }

            return View(sanPhamm);
        }

        // GET: SanPhamms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SanPhamms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,TenSp,Dvt,HangSx,ThanhPhan")] SanPhamm sanPhamm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPhamm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sanPhamm);
        }

        // GET: SanPhamms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamm = await _context.SanPhamms.FindAsync(id);
            if (sanPhamm == null)
            {
                return NotFound();
            }
            return View(sanPhamm);
        }

        // POST: SanPhamms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSp,TenSp,Dvt,HangSx,ThanhPhan")] SanPhamm sanPhamm)
        {
            if (id != sanPhamm.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPhamm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhammExists(sanPhamm.MaSp))
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
            return View(sanPhamm);
        }

        // GET: SanPhamms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamm = await _context.SanPhamms
                .FirstOrDefaultAsync(m => m.MaSp == id);
            if (sanPhamm == null)
            {
                return NotFound();
            }

            return View(sanPhamm);
        }

        // POST: SanPhamms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPhamm = await _context.SanPhamms.FindAsync(id);
            _context.SanPhamms.Remove(sanPhamm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhammExists(int id)
        {
            return _context.SanPhamms.Any(e => e.MaSp == id);
        }
    }
}
