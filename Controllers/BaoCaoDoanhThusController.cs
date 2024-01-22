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
    public class BaoCaoDoanhThusController : Controller
    {
        private readonly QuanLyBanHangContext _context;

        public BaoCaoDoanhThusController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: BaoCaoDoanhThus
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaoCaoDoanhThus.ToListAsync());
        }

        // GET: BaoCaoDoanhThus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoCaoDoanhThu = await _context.BaoCaoDoanhThus
                .FirstOrDefaultAsync(m => m.SoLuongBan == id);
            if (baoCaoDoanhThu == null)
            {
                return NotFound();
            }

            return View(baoCaoDoanhThu);
        }

        // GET: BaoCaoDoanhThus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaoCaoDoanhThus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoLuongBan,SoLuongMua,Tongthu,Tongchi,LoiNhuan,Thue")] BaoCaoDoanhThu baoCaoDoanhThu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baoCaoDoanhThu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baoCaoDoanhThu);
        }

        // GET: BaoCaoDoanhThus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoCaoDoanhThu = await _context.BaoCaoDoanhThus.FindAsync(id);
            if (baoCaoDoanhThu == null)
            {
                return NotFound();
            }
            return View(baoCaoDoanhThu);
        }

        // POST: BaoCaoDoanhThus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoLuongBan,SoLuongMua,Tongthu,Tongchi,LoiNhuan,Thue")] BaoCaoDoanhThu baoCaoDoanhThu)
        {
            if (id != baoCaoDoanhThu.SoLuongBan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baoCaoDoanhThu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaoCaoDoanhThuExists(baoCaoDoanhThu.SoLuongBan))
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
            return View(baoCaoDoanhThu);
        }

        // GET: BaoCaoDoanhThus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoCaoDoanhThu = await _context.BaoCaoDoanhThus
                .FirstOrDefaultAsync(m => m.SoLuongBan == id);
            if (baoCaoDoanhThu == null)
            {
                return NotFound();
            }

            return View(baoCaoDoanhThu);
        }

        // POST: BaoCaoDoanhThus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baoCaoDoanhThu = await _context.BaoCaoDoanhThus.FindAsync(id);
            _context.BaoCaoDoanhThus.Remove(baoCaoDoanhThu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaoCaoDoanhThuExists(int id)
        {
            return _context.BaoCaoDoanhThus.Any(e => e.SoLuongBan == id);
        }
    }
}
