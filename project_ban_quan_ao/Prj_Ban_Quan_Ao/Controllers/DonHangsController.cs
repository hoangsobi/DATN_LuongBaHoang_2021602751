using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prj_Ban_Quan_Ao.Models;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Prj_Ban_Quan_Ao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangsController : ControllerBase
    {
        private readonly DbQuanAoContext _context;

        public DonHangsController(DbQuanAoContext context)
        {
            _context = context;
        }

        // GET: api/DonHangs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetDonHangs()
        {
            return await (from dh in _context.DonHangs
                          join ac in _context.Accounts on dh.AccountId equals ac.Id
                          orderby 
                                dh.TrangThai == TrangThaiDonHang.GiaoHangThanhCong || dh.TrangThai == TrangThaiDonHang.DaHuy ascending,
                                dh.NgayTao descending
                          select new
                          {
                              dh.Id,
                              dh.ThanhTien,
                              dh.TrangThai,
                              dh.NgayTao,
                              ac.TenHienThi
                          }).ToListAsync();
        }

        // GET: api/DonHangs/5
        [HttpGet("{id}")]
        public  IActionResult GetDonHang(Guid id)
        {
            var donHang = (from dh in _context.DonHangs
                           join mgg in _context.MaGiamGia on dh.MaGiamGiaId equals mgg.Id into mj
                           from mgg in mj.DefaultIfEmpty()
                           join ac in _context.Accounts on dh.AccountId equals ac.Id
                           where dh.Id == id
                           select new
                           {
                               id = dh.Id,
                               accountId = dh.AccountId,
                               diaChi = dh.DiaChi,
                               ghiChu = dh.GhiChu,
                               maGiamGiaId = dh.MaGiamGiaId,
                               ngayHuy = dh.NgayHuy,
                               ngayTao = dh.NgayTao,
                               phuongThucThanhToan = dh.PhuongThucThanhToan,
                               phuongThucVanChuyen = dh.PhuongThucVanChuyen,
                               thanhTien = dh.ThanhTien,
                               trangThai = dh.TrangThai,
                               MaGiamGia = mgg.Ma,
                               luongGiam = mgg.LuongGiam,
                               tenHienThi = dh.TenNguoiMua,
                               soDienThoai = dh.SoDienThoai,
                           }).FirstOrDefault();

            if (donHang == null)
            {
                return NotFound();
            }

            return Ok(donHang);
        }
        // PUT: api/DonHangs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonHang(Guid id, DonHang donHang)
        {
            if (id != donHang.Id)
            {
                return BadRequest();
            }

            _context.Entry(donHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonHangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("huydonhang/{id}")]
        public async Task<IActionResult> HuyDonHang(Guid id, DonHang donHang)
        {
            if (id != donHang.Id)
            {
                return BadRequest();
            }

            _context.Entry(donHang).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonHangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DonHangs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DonHang>> PostDonHang(DonHang donHang)
        {
            _context.DonHangs.Add(donHang);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonHang", new { id = donHang.Id }, donHang);
        }

        // DELETE: api/DonHangs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonHang(Guid id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }

            _context.DonHangs.Remove(donHang);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("getlistdonhangbyaccountid/{idAccount}")]
        public IActionResult GetListDonHangByAccountId(string idAccount)
        {
                var query =
                      (from dh in _context.DonHangs
                       join mgg in _context.MaGiamGia on dh.MaGiamGiaId equals mgg.Id into gj
                       from mgg in gj.DefaultIfEmpty()
                       where dh.AccountId.ToString() == idAccount
                       orderby dh.NgayTao descending
                       select new
                       {
                           accountId = dh.AccountId,
                           diaChi = dh.DiaChi,
                           ghiChu = dh.GhiChu,
                           id = dh.Id,
                           maGiamGiaId = dh.MaGiamGiaId,
                           ngayHuy = dh.NgayHuy,
                           ngayTao = dh.NgayTao,
                           phuongThucThanhToan = dh.PhuongThucThanhToan,
                           phuongThucVanChuyen = dh.PhuongThucVanChuyen,
                           thanhTien = dh.ThanhTien,
                           trangThai = dh.TrangThai,
                           tenMaGiam = mgg.Ma,
                       });
                return Ok(query.ToList());

        }

        private bool DonHangExists(Guid id)
        {
            return _context.DonHangs.Any(e => e.Id == id);
        }

        [HttpGet("GetThanhTienTrangThaiDonHang")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetThanhTienTrangThaiDonHang()
        {
            var result = await _context.DonHangs
                .GroupBy(dh => dh.TrangThai)
                .Select(g => new
                {
                    TrangThai = g.Key,
                    ThanhTien = g.Sum(dh => dh.ThanhTien)
                })
                .ToListAsync();

            return result;
        }

        [HttpGet("GetSoLuongTrangThaiDonHang")]
        public async Task<ActionResult<IEnumerable<dynamic>>> GetSoLuongTrangThaiDonHang()
        {
            var result = await _context.DonHangs
                .GroupBy(dh => dh.TrangThai)
                .Select(g => new
                {
                    TrangThai = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            return result;
        }


        [HttpGet("getdoanhthutheongay")]
        public IActionResult GetDoanhThuTheoNgay()
        {
            var last7Days = Enumerable.Range(0, 7)
                                  .Select(i => DateTime.Today.AddDays(-i))
                                  .ToList();

            var result = from date in last7Days
                         join donHang in _context.DonHangs
                         on date equals donHang.NgayTao.Value.Date into gj
                         from subDonHang in gj.DefaultIfEmpty()
                            group subDonHang by date into grouped
                         orderby grouped.Key
                         select new
                         {
                             Ngay = grouped.Key,
                             tongThanhTien = grouped.Sum(dh => dh == null ? 0 : dh.ThanhTien)
                         };
            return Ok(result.ToList());


        }

        [HttpGet("getdoanhthutheonam")]
        public IActionResult GetDoanhThuTheoNam()
        {
            var currentYear = DateTime.Today.Year;

            var last4Years = Enumerable.Range(0, 4)
                                       .Select(i => currentYear - i)
                                       .ToList();

            var result = from year in last4Years
                         join donHang in _context.DonHangs
                         on year equals donHang.NgayTao.Value.Year into gj
                         from subDonHang in gj.DefaultIfEmpty()
                         group subDonHang by year into grouped
                         orderby grouped.Key 
                         select new
                         {
                             Nam = grouped.Key,
                             tongThanhTien = grouped.Sum(dh => dh == null ? 0 : dh.ThanhTien)
                         };

            return Ok(result.ToList());


        }

        [HttpGet("getdoanhthutheothang")]
        public IActionResult GetDoanhThuTheoThang()
        {
            var currentYear = DateTime.Today.Year;

            // Generate the list of months (1 to 12)
            var months = Enumerable.Range(1, 12).ToList();

            var result = from month in months
                         join donHang in _context.DonHangs
                         on new { Year = currentYear, Month = month } equals new { Year = donHang.NgayTao.Value.Year, Month = donHang.NgayTao.Value.Month } into gj
                         from subDonHang in gj.DefaultIfEmpty()
                         group subDonHang by month into grouped
                         orderby grouped.Key
                         select new
                         {
                             Thang = grouped.Key,
                             tongThanhTien = grouped.Sum(dh => dh == null ? 0 : dh.ThanhTien)
                         };

            return Ok(result.ToList());


        }

        [HttpGet("getListSanPhamByIDDonHang/{orderId}")]
        public async Task<IActionResult> GetListSanPhamByIDDonHang(Guid orderId)
        {
            var sanPhams = await (from spdh in _context.SanPhamDonHangs
                      join sp in _context.SanPhams on spdh.SanPhamId equals sp.Id
                      where spdh.DonHangId == orderId
                      select new
                      {
                          sanPhamId = sp.Id,
                          maSanPham = sp.MaSanPham, 
                          tenSanPham = sp.Ten,
                          gia = sp.Gia,
                          giaSauGiam = sp.GiaSauGiam,
                          soLuong = spdh.SoLuong,
                          duongDan = sp.DuongDanAnh
                      })
                      .ToListAsync();

            return Ok(sanPhams);

            //if (query != null)
            //{
            //    foreach (var sp in query.sanPhams)
            //    {
            //        sp.duongDan = await _context.AnhSanPhams
            //            .Where(a => a.SanPhamId == sp.sanPhamId)
            //            .OrderByDescending(a => a.NgayTao)
            //            .Select(a => a.DuongDan)
            //            .FirstOrDefaultAsync();
            //    }
            //}

           // return Ok(query);


        }



        [HttpGet("changeStatusDown/{orderId}/{status}")]
        public async Task<ActionResult<object>> changeStatusDown(Guid orderId, string status)
        {
            var order = await _context.DonHangs.FirstOrDefaultAsync(x => x.Id.Equals(orderId));
            if(status == Enums.TrangThaiDonHang.GiaoHangThanhCong)
                order.TrangThai = Enums.TrangThaiDonHang.DangGiaoHang;
            else if(status == Enums.TrangThaiDonHang.DangGiaoHang)
                order.TrangThai = Enums.TrangThaiDonHang.DangChuanBiHang;
            else if(status == Enums.TrangThaiDonHang.DangChuanBiHang)
                order.TrangThai = Enums.TrangThaiDonHang.ChoXacNhan;
            else if(status == Enums.TrangThaiDonHang.ChoXacNhan)
                order.TrangThai = Enums.TrangThaiDonHang.DaHuy;

            await _context.SaveChangesAsync();

            return Ok(new {status = "success"});
        }

        [HttpGet("changeStatusUp/{orderId}/{status}")]
        public async Task<ActionResult<object>> changeStatusUp(Guid orderId, string status)
        {
            var order = await _context.DonHangs.FirstOrDefaultAsync(x => x.Id.Equals(orderId));
            if(status == Enums.TrangThaiDonHang.DaHuy)
                order.TrangThai = Enums.TrangThaiDonHang.ChoXacNhan;
            else if(status == Enums.TrangThaiDonHang.ChoXacNhan)
                order.TrangThai = Enums.TrangThaiDonHang.DangChuanBiHang;
            else if(status == Enums.TrangThaiDonHang.DangChuanBiHang)
                order.TrangThai = Enums.TrangThaiDonHang.DangGiaoHang;
            else if(status == Enums.TrangThaiDonHang.DangGiaoHang)
                order.TrangThai = Enums.TrangThaiDonHang.GiaoHangThanhCong;

            await _context.SaveChangesAsync();

            return Ok(new {status = "success"});
        }

        [HttpGet("huydon/{orderId}")]
         public async Task<ActionResult<object>> HuyDon(Guid orderId)
        {
            var order = await _context.DonHangs.FirstOrDefaultAsync(x => x.Id.Equals(orderId));
                order.TrangThai = Enums.TrangThaiDonHang.DaHuy;

            await _context.SaveChangesAsync();

            return Ok(new {status = "success"});
        }
    }
}
