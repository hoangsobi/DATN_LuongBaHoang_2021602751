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
    public class ChiPhisController : ControllerBase
    {
        private readonly DbQuanAoContext _context;

        public ChiPhisController(DbQuanAoContext context)
        {
            _context = context;
        }

        // GET: api/ChiPhis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetChiPhis()
        {
            return await (from cp in _context.ChiPhis
                          join ac in _context.Accounts on cp.AccountId equals ac.Id into acGroup
                          from ac in acGroup.DefaultIfEmpty()
                          orderby cp.NgayChi, cp.NgayTao descending
                          select new
                          {
                              cp.Id,
                              cp.NgayChi,
                              cp.TenChiPhi,
                              cp.MucDich,
                              cp.AccountId,
                              cp.SoTien,
                              nguoiTao = ac.TenHienThi,
                              cp.NgayTao
                          }).ToListAsync();
        }

 

        // GET: api/ChiPhis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiPhi>> GetChiPhi(Guid id)
        {
            var ChiPhi = await _context.ChiPhis.FindAsync(id);

            if (ChiPhi == null)
            {
                return NotFound();
            }

            return ChiPhi;
        }

        // PUT: api/ChiPhis/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChiPhi(Guid id, ChiPhi ChiPhi)
        {
            if (id != ChiPhi.Id)
            {
                return BadRequest();
            }

            _context.Entry(ChiPhi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiPhiExists(id))
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

        [HttpGet("thanhToan/{id}")]
        public async Task<IActionResult> ThanhToanChiPhi(Guid id)
        {
           var query = await _context.ChiPhis.FirstOrDefaultAsync(x => x.Id == id);

            query.NgayChi = DateTime.Now;
            _context.Entry(query).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiPhiExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(new {status = "success"});
        }

        // POST: api/ChiPhis
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChiPhi>> PostChiPhi(ChiPhi ChiPhi)
        {
            _context.ChiPhis.Add(ChiPhi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChiPhi", new { id = ChiPhi.Id }, ChiPhi);
        }

        // DELETE: api/ChiPhis/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChiPhi(Guid id)
        {
            var ChiPhi = await _context.ChiPhis.FindAsync(id);
            if (ChiPhi == null)
            {
                return NotFound();
            }
            _context.ChiPhis.Remove(ChiPhi);
            await _context.SaveChangesAsync();

             return Ok(new { status = "success" });
        }

        private bool ChiPhiExists(Guid id)
        {
            return _context.ChiPhis.Any(e => e.Id == id);
        }

    }
}
