using Blogifier.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Blogifier.Identity;

public class UserClaimsPrincipalFactory : UserClaimsPrincipalFactory<UserInfo>
{
  public UserClaimsPrincipalFactory(
    UserManager<UserInfo> userManager,
    IOptions<IdentityOptions> options)
    : base(userManager, options)
  {
  }

  public override async Task<ClaimsPrincipal> CreateAsync(UserInfo user)
  {
    var claimsPrincipal = await base.CreateAsync(user);
    var id = new ClaimsIdentity("Application");
    id.AddClaim(new Claim(BlogifierClaimTypes.NickName, user.NickName));
    var role = BlogifierClaims.GetRole(user.Type);
    if (role != null)
    {
      id.AddClaim(new Claim(BlogifierClaimTypes.Roles, role));
    }
    if (!string.IsNullOrEmpty(user.Avatar)) id.AddClaim(new Claim(BlogifierClaimTypes.Avatar, user.Avatar));
    claimsPrincipal.AddIdentity(id);
    return claimsPrincipal;
  }
}
