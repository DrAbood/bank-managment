using Bank_Managment_Api_1._2.Data;
using Bank_Managment_Api_1._2.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bank_Managment_Api_1._2.Entities;
using Bank_Managment_Api_1._2.Mapping;

namespace Bank_Managment_Api_1._2.Controller
{
    [Route("Transaction")]
    [ApiController]
    public class Transaction : ControllerBase
    {
        private BankAccountContext _dbContext;
        public Transaction(BankAccountContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<TransactionDto>> GetTransactionById(Guid Id)
        {
            Transactions? transaction = await _dbContext.transactions.FindAsync(Id);
            if (transaction == null)
            {
                return NotFound();
            }
            return transaction.ToTransactionDto();
        }

    }
}
