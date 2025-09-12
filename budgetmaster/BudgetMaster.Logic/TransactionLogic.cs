using BudgetMaster.Data;
using BudgetMaster.Entities.Models;


namespace BudgetMaster.Logic
{
    public class TransactionLogic
    {
        Repository<Transaction> _repo;

        public TransactionLogic(Repository<Transaction> repo)
        {
            this._repo = repo;
        }

        public void AddTransaction(Transaction transaction) 
        {
            _repo.Create(transaction);
        }
        public void DeleteTransaction(int id) 
        {
            _repo.DeleteById(id);
        }
        public void UpdateTransaction(int id,Transaction transaction) 
        {
            var old = _repo.FindById(id);
            foreach (var prop in typeof(Transaction).GetProperties())
            {
                if (prop.CanWrite && prop.Name != "Id")
                {
                    prop.SetValue(old, prop.GetValue(transaction));
                }
            }
            _repo.Update(old);
        }
        public Transaction GetTransactionById(int id) 
        {
            return _repo.FindById(id);
        }
        public IQueryable<Transaction> GetAllTransactions() 
        {
            return _repo.GetAll();
        }

    }
}
