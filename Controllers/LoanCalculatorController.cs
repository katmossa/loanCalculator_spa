using System.Linq;
using System.Threading.Tasks;
using LoanProject.Common;
using LoanProject.Interfaces;
using LoanProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoanProject.Controllers
{
  [Route("api/[controller]")]
  public class LoanCalculatorController : Controller
  {
    private IPaymentGenerator _paymentGenerator;

    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> GenerateInstallments([FromBody] Loan loanModel)
    {
      PaymentGeneratorsFactory factory = new PaymentGeneratorsFactory();
      _paymentGenerator = factory.CreatePaymentGenerator(PaymentStrategy.DecreasingInstallments, loanModel);

      var installments = await Task.FromResult(_paymentGenerator.GenerateInstallments(loanModel));
      if (installments.Any())
      {
        return Ok(installments);
      }

      return NoContent();
    }
  }
}
