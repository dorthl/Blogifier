using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Blogifier.Identity;

public class UserInfo : IdentityUser<int>, IIdentityUser
{
  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public DateTime CreatedAt { get; set; }
  [StringLength(256)]
  public string Nickname { get; set; } = default!;
  [StringLength(1024)]
  public string? Avatar { get; set; }
  [StringLength(2048)]
  public string? Bio { get; set; }
  [StringLength(32)]
  public string? Gender { get; set; }
}