using System.Collections.Generic;
using LoanProject.Models;

namespace LoanProject.Interfaces
{
  public interface IPaymentGenerator
  {
    /// <summary>
    /// Generates list of installments that needs to be paid
    /// basing on information in loan
    /// </summary>
    /// <param name="loan">Information about <see cref="Loan"/></param>
    /// <returns></returns>
    List<Installment> GenerateInstallments(Loan loan);
  }
}