using APIMayBay.Models;
using Lib.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIMayBay.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        UserManager<ApplicationUser> userManager { get; set; }
        RoleManager<IdentityRole> roleManager { get; set; }
        IConfiguration configuration { get; set; }
        public AuthenticateController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.configuration = configuration;
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(TokenModel tokenModel)
        {
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }
            if (!await roleManager.RoleExistsAsync("Guest"))
            {
                await roleManager.CreateAsync(new IdentityRole("Guest"));
            }
            ApplicationUser user = new ApplicationUser();
            user.UserName = tokenModel.UserName;
            user.Email = tokenModel.Email;
            user.Id = Guid.NewGuid().ToString();
            var result = await userManager.CreateAsync(user, tokenModel.PassWord);
            await userManager.AddToRoleAsync(user, "Guest");
            //await userManager.AddToRoleAsync(user, "Admin");
            return Ok(new { status = true, message = "" });
        }
        [HttpPost("token")]
        public async Task<ActionResult> GetToken(TokenModel tokenModel)
        {
            try
            {
                var user = await userManager.FindByNameAsync(tokenModel.UserName);
                if (user == null)
                {
                    return Ok(new { status = false, message = "Can not find user" });
                }
                var result = await userManager.CheckPasswordAsync(user, tokenModel.PassWord);
                if (result)
                {
                    string securityKey = configuration["JWT:Secret"];
                    var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                    var userRoles = await userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, tokenModel.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
                    var token = new JwtSecurityToken(
                        claims: authClaims,
                        issuer: configuration["JWT:ValidIssuer"],
                        audience: configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredentials
                    );
                    string strToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new { status = true, message = "", token = strToken });
                }
                return Ok(new { status = false, message = "Can not authenticate" });
            }
            catch (Exception ex)
            {
                return Ok(new { status = false, message = ex.Message });
            }
        }

    }
}
