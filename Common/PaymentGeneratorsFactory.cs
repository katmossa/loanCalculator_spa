using LoanProject.Interfaces;
using LoanProject.Models;

namespace LoanProject.Common
{
  /// <summary>
  /// Creates proper generator for concrete payment strategy
  /// </summary>
  public class PaymentGeneratorsFactory
  {
    /// <summary>
    /// Create instance of generator dependent on payment strategy
    /// </summary>
    /// <param name="paymentStrategy"><see cref="PaymentStrategy"/></param>
    /// <param name="loan"><see cref="Loan"/></param>
    /// <returns></returns>
    public virtual IPaymentGenerator CreatePaymentGenerator(PaymentStrategy paymentStrategy, Loan loan)
    {
      IPaymentGenerator gateway = null;
      switch (paymentStrategy)
      {
        case PaymentStrategy.DecreasingInstallments:
          gateway = new DecreasingMonthlyGenerator();
          break;
        default:
          break;
      }
      return gateway;
    }
  }
}
