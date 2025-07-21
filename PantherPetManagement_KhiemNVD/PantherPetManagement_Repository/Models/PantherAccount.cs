using System;
using System.Collections.Generic;

namespace PantherPetManagement_Repository.Models;

public partial class PantherAccount
{
    public int AccountId { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string FullName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public int RoleId { get; set; }
}