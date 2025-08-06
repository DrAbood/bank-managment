using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bank_Managment_Api_1._2.Entities;
using Bank_Managment_Api_1._2.Mapping;
using Microsoft.AspNetCore.Authorization;

namespace Bank_Managment_Api_1._2.Controller
{
    [Route("Transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private BankAccountContext _dbContext;
        private ILogger<TransactionController> _Logger;
        public TransactionController(BankAccountContext dbContext, ILogger<TransactionController> logger)
        {
            _dbContext = dbContext;
            _Logger = logger;
        }
        [Authorize]
        [HttpGet("{Id}")]
        public async Task<ActionResult<TransactionDto>> GetTransactionById(Guid Id)
        {
            Transactions? transaction = await _dbContext.transactions.FindAsync(Id);
            if (transaction == null)
            {
                return NotFound();
            }
            _Logger.LogInformation($"Fetching The Transaction with id {transaction.Id} ");
            return transaction.ToTransactionDto();
        }

    }
}
