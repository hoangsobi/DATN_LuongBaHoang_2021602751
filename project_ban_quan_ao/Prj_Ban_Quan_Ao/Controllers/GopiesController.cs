using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prj_Ban_Quan_Ao.Models;
using SendGrid.Helpers.Mail;
using SendGrid;
using MimeKit;
using MimeKit;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Reactive.Subjects;

namespace Prj_Ban_Quan_Ao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GopiesController : ControllerBase
    {
        private readonly DbQuanAoContext _context;
        private readonly string _sendGridApiKey = "";

        public GopiesController(DbQuanAoContext context)
        {
            _context = context;
        }

        // GET: api/Gopies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GopY>>> GetGopies()
        {
            return await _context.Gopies.OrderByDescending(x => x.NgayTao).ToListAsync();
        }

        // GET: api/Gopies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GopY>> GetGopY(Guid id)
        {
            var gopY = await _context.Gopies.FindAsync(id);

            if (gopY == null)
            {
                return NotFound();
            }

            return gopY;
        }

        // PUT: api/Gopies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGopY(Guid id, GopY gopY)
        {
            if (id != gopY.Id)
            {
                return BadRequest();
            }

            _context.Entry(gopY).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GopYExists(id))
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
        [HttpPut("phanHoi/{id}/{email}")]
        public async Task<IActionResult> PhanHoi(Guid id, string email, [FromBody] PhanHoiRequest phanHoi)
        {

            string fromEmail = "hoangluongba6603@gmail.com";
            if (email == null)
                return Ok(new { Status = "success" });


                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    EnableSsl = true,
                    Credentials = new NetworkCredential("hoangluongba6603@gmail.com", "kywghvziirtolimc"),
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
            var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail, "Fashion Store"),
                    Subject = "Fashion Store phản hồi",
                    Body = phanHoi.PhanHoi,
                    IsBodyHtml = false
                };

                mailMessage.To.Add(email);

                await smtpClient.SendMailAsync(mailMessage);



             var gy = await _context.Gopies.FindAsync(id);
            gy.PhanHoi = phanHoi.PhanHoi; 

            _context.Entry(gy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GopYExists(id))
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

        // POST: api/Gopies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GopY>> PostGopY(GopY gopY)
        {
            _context.Gopies.Add(gopY);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGopY", new { id = gopY.Id }, gopY);
        }

        // DELETE: api/Gopies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGopY(Guid id)
        {
            var gopY = await _context.Gopies.FindAsync(id);
            if (gopY == null)
            {
                return NotFound();
            }

            _context.Gopies.Remove(gopY);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GopYExists(Guid id)
        {
            return _context.Gopies.Any(e => e.Id == id);
        }
    }
}
