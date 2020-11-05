using System.Collections.Generic;
using LoanProject.Interfaces;
using LoanProject.Models;

namespace LoanProject.Common
{
  /// <summary>
  /// Generator for decreasing monthly installments
  /// with fixed year interest
  /// </summary>
  public class DecreasingMonthlyGenerator : IPaymentGenerator
  {
    /// <summary>
    /// Fixed interest 
    /// </summary>
    private float _yearInterest = 3.5f;

    public List<Installment> GenerateInstallments(Loan loan)
    {
      var result = new List<Installment>();
      var termOfLoan = loan.PaymentYears * 12;  //in months
      double interestRate = _yearInterest / 100 / 12;
      double currentLoanToPay = loan.Amount;
      double principalValue = currentLoanToPay / termOfLoan;

      for (int i = 0; i < termOfLoan; i++)
      {
        /*double payment = currentLoanToPay * (Math.Pow((1 + interestRate / 12), termOfLoan) * interestRate) /
                         (12 * (Math.Pow((1 + interestRate / 12), termOfLoan) - 1));*/

        double currentInterest = currentLoanToPay * interestRate;

        result.Add(new Installment() { Interest = currentInterest, Principal = principalValue, Month = i });
        currentLoanToPay -= principalValue;
      }

      return result;
    }
  }
}