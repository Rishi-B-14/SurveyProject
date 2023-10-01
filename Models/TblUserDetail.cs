using System;
using System.Collections.Generic;

namespace SurveyNew.Models;

public partial class TblUserDetail
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public string? City { get; set; }

    public string? PhoneNum { get; set; }

    public int? FamilyMembers { get; set; }

    public string? SelectedProduct { get; set; }

    public DateTime? SubmissionTime { get; set; }
}
