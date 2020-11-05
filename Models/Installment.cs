using System;

namespace LoanProject.Models
{
  /// <summary>
  /// Information about concrete installment that was generated
  /// </summary>
  [Serializable]
  public class Installment
  {
    /// <summary>
    /// Month that installment amount was generated for
    /// </summary>
    public int Month { get; set; }

    public double Principal { get; set; }

    public double Interest { get; set; }

    /// <summary>
    /// Concrete amount of installment that need to be paid
    /// </summary>
    public double InstallmentAmount => Principal + Interest;
  }
}