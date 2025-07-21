using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PantherPetManagement_Repository.Models;

public partial class PantherProfile
{
    public int PantherProfileId { get; set; }

    [Required(ErrorMessage = "Please select a Panther Type.")]
    [Range(1, int.MaxValue, ErrorMessage = "Please select a Panther Type.")]
    public int PantherTypeId { get; set; }

    [Required(ErrorMessage = "PantherName is required.")]
    [MinLength(4, ErrorMessage = "PantherName must be at least 4 characters.")]
    [RegularExpression(@"^[A-Z][a-zA-Z0-9]*(\s[A-Z][a-zA-Z0-9]*)*$", ErrorMessage = "Each word must start with capital letter, No special characters allowed (#, @, &, (, )).")]
    public string PantherName { get; set; }

    [Required(ErrorMessage = "Weight is required.")]
    [Range(31, int.MaxValue, ErrorMessage = "Weight must be greater than 30.")]
    public double Weight { get; set; }

    [Required(ErrorMessage = "Characteristics is required.")]
    public string Characteristics { get; set; }

    [Required(ErrorMessage = "Warning is required.")]
    public string Warning { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual PantherType PantherType { get; set; }
}