﻿using System.ComponentModel.DataAnnotations;

namespace IdentityProj.Models.Request.User;

public class UserCreateRequest
{
    [Required] 
    public string FullName { get; set; } = null!;

    [Required] 
    public string Username { get; set; } = null!;

    [Required] 
    public string Email { get; set; } = null!;

    [Required] 
    public string PhoneNumber { get; set; } = null!;

    [Required] 
    public string TimeZone { get; set; } = null!;

    [Required] 
    public string Password { get; set; } = null!;
}