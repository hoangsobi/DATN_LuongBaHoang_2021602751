using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prj_Ban_Quan_Ao.Models;

namespace Prj_Ban_Quan_Ao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaiTrosController : ControllerBase
    {
        private readonly DbQuanAoContext _context;

        public VaiTrosController(DbQuanAoContext context)
        {
            _context = context;
        }

        // GET: api/VaiTros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaiTro>>> GetVaiTros()
        {
            return await _context.VaiTros.Where(x => x.Name != "User").OrderByDescending(x => x.NgayTao).ToListAsync();
        }

        [HttpGet("getListQuyen")]
        public async Task<ActionResult<IEnumerable<Quyen>>> getQuyens()
        {
            return await _context.Quyens.OrderByDescending(x => x.NgayTao).ToListAsync();
        }

        [HttpGet("getQuyenByVaiTroId/{vaiTroId}")]
        public async Task<ActionResult<IEnumerable<object>>> getQuyenByVaiTroId(Guid vaiTroId)
        {
            var vaiTroQuyen = await (from q in _context.Quyens
                                    join vtq in _context.VaiTroQuyens on q.Id equals vtq.QuyenId
                                    where vtq.VaiTroId == vaiTroId
                                    select new
                                    {
                                        q.Id,
                                        q.Ten,
                                        q.Rout
                                    }).ToListAsync();
                

            return vaiTroQuyen;
        }

        [HttpPut("updatePermissionRole/{vaiTroId}")]
        public async Task<ActionResult<IEnumerable<object>>> UpdatePermissionRole(Guid vaiTroId, List<Quyen> quyen)
        {
            var currentPermissions = await _context.VaiTroQuyens
                                          .Where(vq => vq.VaiTroId == vaiTroId)
                                          .ToListAsync();

            // Xoá các quyền cũ
            _context.VaiTroQuyens.RemoveRange(currentPermissions);

            var listVaiTroQuyen = quyen.Select(q => new VaiTroQuyen
            {
                VaiTroId = vaiTroId,
                QuyenId = q.Id
            }).ToList();
                
            await _context.VaiTroQuyens.AddRangeAsync(listVaiTroQuyen);
            await _context.SaveChangesAsync();

            return Ok(new { status = "success" });
        }
    }
}
