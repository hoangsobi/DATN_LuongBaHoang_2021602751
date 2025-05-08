using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prj_Ban_Quan_Ao.Models;

namespace Prj_Ban_Quan_Ao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardsController : ControllerBase
    {
        private readonly DbQuanAoContext _context;

        public DashboardsController(DbQuanAoContext context)
        {
            _context = context;
        }

        // GET: api/Dashboards
        [HttpGet("getThongKeHead")]
        public async Task<ActionResult<IEnumerable<object>>> GetThongKeHead()
        {
            var vaiTroId = await _context.VaiTros.Where(x => x.Name == "User").Select(x => x.Id).FirstOrDefaultAsync();
            var thisYear = DateTime.Now.Year;
            var thisMonth = DateTime.Now.Month;
            var nguoiDung = await _context.Accounts.Where(x => x.VaiTroId == vaiTroId).CountAsync();
            var donHang = await _context.DonHangs.Where(x => x.TrangThai != TrangThaiDonHang.GiaoHangThanhCong && x.TrangThai != TrangThaiDonHang.DaHuy).CountAsync();
            var doanhThuThang = await _context.DonHangs.Where(x => x.NgayTao.HasValue && x.NgayTao.Value.Month == thisMonth && x.TrangThai == TrangThaiDonHang.GiaoHangThanhCong).SumAsync(x => x.ThanhTien);
            var doanhThuNam =  await _context.DonHangs.Where(x => x.NgayTao.HasValue && x.NgayTao.Value.Year == thisYear && x.TrangThai == TrangThaiDonHang.GiaoHangThanhCong).SumAsync(x => x.ThanhTien);
            return Ok(new
            {
                nguoiDung, donHang, doanhThuThang, doanhThuNam
            });
        }

        [HttpGet("getDoanhThuTheoThangTrongNam")]
        public async Task<ActionResult<object>> GetDoanhThuTheoThangTrongNam()
        {
            int currentYear = DateTime.Now.Year;

            var orderStats = await (from od in _context.DonHangs
                                    where od.NgayTao.HasValue
                                          && od.NgayTao.Value.Year == currentYear
                                          && od.TrangThai == TrangThaiDonHang.GiaoHangThanhCong
                                    group od by od.NgayTao.Value.Month into g
                                    select new
                                    {
                                        Month = g.Key,
                                        TotalOrders = g.Sum(x => x.ThanhTien),
                                        //CanceledOrders = g.Count(x => x.Tra == OrderStatus.DaHuy)
                                    }).ToListAsync();

            var fullYearData = Enumerable.Range(1, 12).Select(month => new
            {
                Month = month,
                TotalOrders = orderStats.FirstOrDefault(x => x.Month == month)?.TotalOrders ?? 0,
                //CanceledOrders = orderStats.FirstOrDefault(x => x.Month == month)?.CanceledOrders ?? 0
            });

            return Ok(fullYearData);
        }

        [HttpGet("getThongKeDoanhThuChiPhi")]
        public async Task<ActionResult<object>> GetThongKeDoanhThuChiPhi()
        {
            int currentYear = DateTime.Now.Year;

            var doanhThu = await _context.DonHangs.Where(x => x.TrangThai == TrangThaiDonHang.GiaoHangThanhCong).SumAsync(x => x.ThanhTien);
            var chiPhi = await _context.ChiPhis.SumAsync(x => x.SoTien);

            return Ok(new
            {
                doanhThu,
                chiPhi,
            });
        }

        [HttpGet("getKhachThanThiet")]
        public async Task<ActionResult<object>> GetKhachThanThiet()
        {
             var listKhachHang = await (from ac in _context.Accounts
                                     join dh in _context.DonHangs on ac.Id equals dh.AccountId
                                     group new { ac, dh } by new
                                     {
                                         ac.TenHienThi,
                                         ac.SoDienThoai,
                                         ac.Email
                                     } into Grouped
                                     orderby Grouped.Sum(x => x.dh.ThanhTien) descending
                                     select new
                                     {
                                         Grouped.Key.TenHienThi,
                                         Grouped.Key.SoDienThoai,
                                         Grouped.Key.Email,
                                         SoDon = Grouped.Count(),
                                         SoTien = Grouped.Sum(x => x.dh.ThanhTien)
                                     }).Take(10).ToListAsync();

            return Ok(listKhachHang);
        }

        [HttpGet("getDonHangGanNhat")]
        public async Task<ActionResult<object>> GetDonHangGanNhat()
        {

            var listDonHang = await (from dh in _context.DonHangs
                                     join ac in _context.Accounts on dh.AccountId equals ac.Id
                                     orderby dh.NgayTao descending
                                     select new
                                     {
                                         dh.Id,
                                         dh.NgayTao,
                                         ac.TenHienThi,
                                         dh.ThanhTien
                                     }).Take(10).ToListAsync();

            return Ok(listDonHang);
        }
    }
}
