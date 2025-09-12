using BudgetMaster.Endpoint.Controllers.Common;
using BudgetMaster.Logic;
using Microsoft.AspNetCore.Mvc;

namespace BudgetMaster.Endpoint.Controllers
{
    [Route("transaction")]
    public class TransactionController : ApiControllerBase
    {
        TransactionLogic _logic;
        public TransactionController(TransactionLogic logic)
        {
            this._logic = logic;
        }

        [HttpPost]
        public void AddTransaction(Entities.Models.Transaction transaction) 
        {
            _logic.AddTransaction(transaction);
        }
        [HttpGet]
        public IQueryable<Entities.Models.Transaction> GetAllTransactions() 
        {
            return _logic.GetAllTransactions();
        }
        [HttpGet("{id}")]
        public Entities.Models.Transaction GetTransactionById(int id) 
        {
            return _logic.GetTransactionById(id);
        }
        [HttpDelete("{id}")]
        public void DeleteTransaction(int id) 
        {
            _logic.DeleteTransaction(id);
        }
        [HttpPut("{id}")]
        public void UpdateTransaction(int id, Entities.Models.Transaction transaction) 
        {
            _logic.UpdateTransaction(id, transaction);
        }

    }
}
