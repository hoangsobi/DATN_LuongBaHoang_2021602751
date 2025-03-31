using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Prj_Ban_Quan_Ao.Models;

namespace Prj_Ban_Quan_Ao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaGiamGiumsController : ControllerBase
    {
        private readonly DbQuanAoContext _context;

        public MaGiamGiumsController(DbQuanAoContext context)
        {
            _context = context;
        }

        // GET: api/MaGiamGiums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaGiamGium>>> GetMaGiamGia()
        {
            return await _context.MaGiamGia.OrderByDescending(x => x.NgayTao).ToListAsync();
        }

        // GET: api/MaGiamGiums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaGiamGium>> GetMaGiamGium(Guid id)
        {
            var maGiamGium = await _context.MaGiamGia.FindAsync(id);

            if (maGiamGium == null)
            {
                return NotFound();
            }

            return maGiamGium;
        }

        // PUT: api/MaGiamGiums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaGiamGium(Guid id, MaGiamGium maGiamGium)
        {
            if (id != maGiamGium.Id)
            {
                return BadRequest();
            }

            _context.Entry(maGiamGium).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaGiamGiumExists(id))
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

        // POST: api/MaGiamGiums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MaGiamGium>> PostMaGiamGium(MaGiamGium maGiamGium)
        {
            _context.MaGiamGia.Add(maGiamGium);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMaGiamGium", new { id = maGiamGium.Id }, maGiamGium);
        }

        [HttpGet("getmagiamgiaconlai/{idAccount}")]
        public IActionResult GetMaGiamGiaConLai(Guid idAccount)
        {
            var query =
                from mgg in _context.MaGiamGia
                where !(from am in _context.AccountMaGiamGia
                        where am.AccountId == idAccount
                        select am.MagiamgiaId)
                       .Contains(mgg.Id)
                orderby mgg.NgayTao
                select mgg;

            return Ok(query);
        }

        [HttpGet("getmagiamgiadaluu/{idAccount}")]
        public IActionResult GetMaGiamGiaDaLuu(Guid idAccount)
        {
            var query =
                from mgg in _context.MaGiamGia
                where (from am in _context.AccountMaGiamGia
                       where am.AccountId == idAccount
                       select am.MagiamgiaId)
                       .Contains(mgg.Id)
                orderby mgg.NgayTao
                select mgg;

            return Ok(query);
        }

        // DELETE: api/MaGiamGiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaGiamGium(Guid id)
        {
            var maGiamGium = await _context.MaGiamGia.FindAsync(id);
            if (maGiamGium == null)
            {
                return NotFound();
            }

            var ck1 = await _context.AccountMaGiamGia.AnyAsync(x => x.MagiamgiaId == id);
            var ck2 = await _context.DonHangs.AnyAsync(x => x.MaGiamGiaId == id);
            if (ck1 || ck2)
                return Ok(new { status = "used" });
            _context.MaGiamGia.Remove(maGiamGium);
            await _context.SaveChangesAsync();

            return Ok(new {status = "success"});
        }

        private bool MaGiamGiumExists(Guid id)
        {
            return _context.MaGiamGia.Any(e => e.Id == id);
        }
    }
}
