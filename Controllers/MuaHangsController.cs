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
    public class MuaHangsController : Controller
    {
        private readonly QuanLyBanHangContext _context;

        public MuaHangsController(QuanLyBanHangContext context)
        {
            _context = context;
        }

        // GET: MuaHangs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MuaHangs.ToListAsync());
        }

        // GET: MuaHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muaHang = await _context.MuaHangs
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (muaHang == null)
            {
                return NotFound();
            }

            return View(muaHang);
        }

        // GET: MuaHangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MuaHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHang,TenHang,Dvt,PhiVanChuyen,HinhThucThanhToan")] MuaHang muaHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(muaHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(muaHang);
        }

        // GET: MuaHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muaHang = await _context.MuaHangs.FindAsync(id);
            if (muaHang == null)
            {
                return NotFound();
            }
            return View(muaHang);
        }

        // POST: MuaHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHang,TenHang,Dvt,PhiVanChuyen,HinhThucThanhToan")] MuaHang muaHang)
        {
            if (id != muaHang.MaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(muaHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MuaHangExists(muaHang.MaHang))
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
            return View(muaHang);
        }

        // GET: MuaHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var muaHang = await _context.MuaHangs
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (muaHang == null)
            {
                return NotFound();
            }

            return View(muaHang);
        }

        // POST: MuaHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var muaHang = await _context.MuaHangs.FindAsync(id);
            _context.MuaHangs.Remove(muaHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MuaHangExists(int id)
        {
            return _context.MuaHangs.Any(e => e.MaHang == id);
        }
    }
}
