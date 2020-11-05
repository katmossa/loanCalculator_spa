using System;
using System.ComponentModel.DataAnnotations;
using LoanProject.Common;

namespace LoanProject.Models
{
  /// <summary>
  /// Information about Loan
  /// </summary>
  [Serializable]
  public class Loan
  {
    /// <summary>
    /// Total amount of loan
    /// </summary>
    [Required]
    public int Amount { get; set; }

    /// <summary>
    /// Number of years that loan will be paid
    /// </summary>
    [Required]
    public int PaymentYears { get; set; }

    /// <summary>
    /// Strategy of paying off installments
    /// <see cref="PaymentStrategy"/>
    /// </summary>
    [Required]
    public PaymentStrategy PaymentStrategy { get; set; }
  }
}