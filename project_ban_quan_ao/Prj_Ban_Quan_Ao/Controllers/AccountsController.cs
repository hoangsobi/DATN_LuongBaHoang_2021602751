using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Prj_Ban_Quan_Ao.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Prj_Ban_Quan_Ao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DbQuanAoContext _context;
        private readonly IConfiguration _configuration;

        public AccountsController(DbQuanAoContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // GET: api/Accounts
        [HttpGet("page/{page}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts(int page)
        {
            var totalRecords = await (from ac in _context.Accounts
                                      join vt in _context.VaiTros on ac.VaiTroId equals vt.Id
                                      where vt.Name == "User"
                                      select ac).CountAsync();
            var accPage = await (from ac in _context.Accounts
                          join vt in _context.VaiTros on ac.VaiTroId equals vt.Id
                          where vt.Name == "User"
                          select ac)
                          .OrderByDescending(x => x.NgayTao)
                          .Skip((page) * 10)
                          .Take(10)
                          .ToListAsync();
            return Ok(new
            {
                listAcc = accPage,
                totalRecords = totalRecords
            });
        }

        [HttpGet("getAllRole")]
        public async Task<ActionResult<IEnumerable<VaiTro>>> GetRoles()
        {
            return await _context.VaiTros.Where(x => x.Name != "User").ToListAsync();
        }

        [HttpGet("getalluseradmin")]
        public async Task<ActionResult<IEnumerable<object>>> GetAllAccounts()
        {
            return await (from ac in _context.Accounts
                          join vt in _context.VaiTros on ac.VaiTroId equals vt.Id
                          where vt.Name != "User"
                          orderby ac.NgayTao descending
                          select new
                          {
                              ac.Id,
                              ac.TenHienThi,
                              ac.NgayTao,
                              ac.SoDienThoai,
                              ac.Email,
                              ac.DuongDanAnh,
                              vt.Name,
                              ac.IsLocked
                          }).ToListAsync();
        }


        [HttpGet("getlistuserforadminsupport")]
        public IActionResult GetListUserForAdminSupport()
        {
            var query =
                        (from ac in _context.Accounts
                         select new
                         {
                             accountId = ac.Id,
                             tenDangNhap = ac.TenDangNhap,
                             tenHienThi = ac.TenHienThi,
                             duongDanAnh = ac.DuongDanAnh,
                             tinNhanGanNhat = (
                             from cb in _context.ChatBoxes
                             where cb.AccountId == ac.Id
                             orderby cb.NgayTao descending
                             select cb.NoiDung
                             ).FirstOrDefault()
                         }).OrderByDescending(x => x.tinNhanGanNhat).ToList();
            
            return Ok(query);
        }


        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetAccount(Guid id)
        {


            var account = await (from ac in _context.Accounts
                                 join ad in _context.DiaChis on ac.Id equals ad.AccountId into AaGroup
                                 from aa in AaGroup.DefaultIfEmpty()
                                 where ac.Id == id
                                 group aa by new
                                 {
                                     ac.Id,
                                     ac.MatKhau,
                                     ac.TenHienThi,
                                     ac.TenDangNhap,
                                     ac.Email,
                                     ac.NgaySinh,
                                     ac.GioiTinh,
                                     ac.SoDienThoai,
                                     ac.DuongDanAnh,
                                     ac.VaiTroId,
                                     ac.IsLocked
                                 } into grouped
                                 select new
                                 {
                                     grouped.Key.Id,
                                     grouped.Key.MatKhau,
                                     grouped.Key.TenHienThi,
                                     grouped.Key.TenDangNhap,
                                     grouped.Key.Email,
                                     grouped.Key.NgaySinh,
                                     grouped.Key.GioiTinh,
                                     grouped.Key.SoDienThoai,
                                     grouped.Key.DuongDanAnh,
                                     grouped.Key.VaiTroId,
                                     grouped.Key.IsLocked,
                                     diaChis = grouped.Where(x => x != null)
                                                      .Select(x => new 
                                                         {
                                                             x.Tinh,
                                                             x.Huyen,
                                                             x.Xa,
                                                             x.GhiChu
                                                         }).ToList()
                                 }).FirstOrDefaultAsync();
                                 
            return account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(Guid id, Account account)
        {
            if (id != account.Id)
            {
                return BadRequest();
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Account>> PostAccount(Account account)
        {
            if(!account.VaiTroId.HasValue || account.VaiTroId == Guid.Empty)
            {
                var user = await _context.VaiTros.FirstOrDefaultAsync(x => x.Name == "User");
                account.VaiTroId = user.Id;
            }
            _context.Accounts.Add(account);
            //var newCart = new GioHang
            //{
            //    Id = account.Id,
            //    TongSoLuong = 0,
            //    NgayTao = DateTime.Now
            //};
            //_context.GioHangs.Add(newCart);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(Guid id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("checkdangnhap")]
        public IActionResult checkDangNhap(string tendangnhap, string matkhau)
        {
            var query =
                        (from ac in _context.Accounts
                         where ac.TenDangNhap == tendangnhap &&
                                ac.MatKhau == matkhau
                         select ac);
            if (query.Any())
            {
                return Ok(new { status = "success", message = "Đăng nhập thành công.", accounts = query.FirstOrDefault() });
            }
            return Ok(new { status = "error", message = "Tên đăng nhập hoặc mật khẩu không đúng.", tendang = tendangnhap, matkhau = matkhau});
        }

        [HttpGet("checkusername/{tenDangNhap}")]
        public bool AccountExistsUserName(string tenDangNhap)
        {
            return _context.Accounts.Any(e => e.TenDangNhap == tenDangNhap);
        }

        [HttpGet("guiemail/{emailNguoiDung}/{code}")]
        public Task GuiEmail(string emailNguoiDung,string code)
        {
            string subject = "Xác nhận đăng ký tài khoản Fashion Store";
            string message = $"Xin chào, {emailNguoiDung} \n \n Cảm ơn bạn đã lựa chọn và tin tưởng cửa hàng của chúng tôi \n Vui lòng nhập đoạn code sau đây để hoàn tất đăng ký. Lưu ý không cung cấp đoạn code cho bất kì ai! \n Code: {code}";
            var mail = "binhghitao@gmail.com";
            var pw = "";
            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(mail, pw)
            };
            return client.SendMailAsync(
                new MailMessage(
                   from: mail,
                   to: emailNguoiDung,
                   subject,
                   message
                ));
        }


        [HttpGet("lockUser/{userId}")]
        public async Task<bool> LockUser(Guid userId)
        {
            var curUser = await _context.Accounts.FirstOrDefaultAsync(x => x.Id.Equals(userId));
            curUser.IsLocked = true;
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpGet("unlockUser/{userId}")]
        public async Task<bool> UnlockUser(Guid userId)
        {
            var curUser = await _context.Accounts.FirstOrDefaultAsync(x => x.Id.Equals(userId));
            curUser.IsLocked = false;
            await _context.SaveChangesAsync();
            return true;
        }


        private bool AccountExists(Guid id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestCustom loginRequest)
        {
            // Kiểm tra thông tin đăng nhập
            var user = await Authenticate(loginRequest.TenDangNhap, loginRequest.MatKhau);

            if (user == null)
            {
                return Ok(new {status="wrong"});
            }

            // Tạo token JWT
            var token = GenerateJwtToken(user);

            return Ok(new { token = token, status = "success" });
        }

        // Kiểm tra thông tin đăng nhập
        private async Task<AccountCustom> Authenticate(string tenDangNhap, string matKhau)
        {
            var idUserRole = await _context.VaiTros
                             .Where(x => x.Name == "User")
                             .Select(x => x.Id)
                             .FirstOrDefaultAsync();
            // Tìm người dùng trong cơ sở dữ liệu (có thể sử dụng mã hash mật khẩu trong thực tế)
      
           var user = await  (from a in _context.Accounts
                join v in _context.VaiTros on a.VaiTroId equals v.Id
                where a.TenDangNhap == tenDangNhap && a.MatKhau == matKhau && a.VaiTroId != idUserRole
                select new
                {
                    a.Id,
                    a.TenDangNhap,
                    a.TenHienThi,
                    a.MatKhau,
                    a.GioiTinh,
                    a.NgaySinh,
                    a.SoDienThoai,
                    a.Email,
                    a.DuongDanAnh,
                    a.NgayTao,
                    a.IsLocked,
                    a.VaiTroId,
                    VaiTroName = v.Name // Lấy tên vai trò từ bảng VaiTro
                }).FirstOrDefaultAsync();

                if (user != null)
                {

                    var quyenList = await (from vq in _context.VaiTroQuyens
                               join q in _context.Quyens on vq.QuyenId equals q.Id
                               where vq.VaiTroId == user.VaiTroId
                               orderby q.Order
                               select new QuyenDto { Rout = q.Rout, Ten = q.Ten, IconClass = q.IconClass, Order = q.Order}).ToListAsync();

                    // Nếu tìm thấy người dùng, tạo đối tượng Account và gán thông tin vai trò
                    return new AccountCustom
                    {
                        Id = user.Id,
                        TenDangNhap = user.TenDangNhap,
                        TenHienThi = user.TenHienThi,
                        MatKhau = user.MatKhau,
                        SoDienThoai = user.SoDienThoai,
                        Email = user.Email,
                        DuongDanAnh = user.DuongDanAnh,
                        IsLocked = user.IsLocked,
                        VaiTroName = user.VaiTroName,
                        listRout = quyenList// Lưu tên vai trò vào tài khoản
                    };
                }

                return null;
        }

        // Tạo token JWT
        private string GenerateJwtToken(AccountCustom user)
        {
            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.TenDangNhap),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.TenHienThi),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.DuongDanAnh),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.Id.ToString()),
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, user.VaiTroName) // Giả sử VaiTroId là Role
            };

            foreach (var quyen in user.listRout)
            {
                claims.Add(new System.Security.Claims.Claim("Permissions", $"{quyen.Ten}:{quyen.Rout}:{quyen.IconClass}:{quyen.Order}"));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
