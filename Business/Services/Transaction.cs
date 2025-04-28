using Business.FormModel;
using Database.Context;
using Database.Model;
using System.Linq;

namespace Business.Services
{
    public class TransactionService
    {
        LabInventoryContext labInventoryContext = new LabInventoryContext();

        // Add new transaction
        public Result Add(TransactionForm transaction)
        {
            try
            {
                Transaction newTransaction = new Transaction();
                newTransaction.TransactionDate = transaction.TransactionDate;
                newTransaction.TransactionType = transaction.TransactionType;
                newTransaction.TransactionQuality = transaction.TransactionQuality;
                newTransaction.UserId = transaction.UserId;
                newTransaction.SupplierId = transaction.SupplierId;
                newTransaction.ItemId = transaction.ItemId;
                newTransaction.CreatedBy = transaction.CreatedBy;

                labInventoryContext.Transaction.Add(newTransaction);
                return new Result().DBCommit(labInventoryContext, "Transaction added successfully!", null, transaction);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Update transaction
        public Result Update(TransactionForm transaction)
        {
            try
            {
                var existingTransaction = labInventoryContext.Transaction.FirstOrDefault(x => x.TransactionId == transaction.TransactionId);
                if (existingTransaction == null) return new Result(false, "Transaction not found!");

                existingTransaction.TransactionDate = transaction.TransactionDate;
                existingTransaction.TransactionType = transaction.TransactionType;
                existingTransaction.TransactionQuality = transaction.TransactionQuality;
                existingTransaction.UserId = transaction.UserId;
                existingTransaction.SupplierId = transaction.SupplierId;
                existingTransaction.ItemId = transaction.ItemId;
                existingTransaction.UpdatedBy = transaction.UpdatedBy;
                existingTransaction.UpdatedDate = DateTime.Now;

                return new Result().DBCommit(labInventoryContext, "Transaction updated successfully!", null, transaction);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Delete transaction
        public Result Delete(string transactionId)
        {
            try
            {
                var transaction = labInventoryContext.Transaction.FirstOrDefault(x => x.TransactionId == transactionId);
                if (transaction == null) return new Result(false, "Transaction not found!");

                labInventoryContext.Transaction.Remove(transaction);
                return new Result().DBCommit(labInventoryContext, "Transaction deleted successfully!", null, transaction);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // List all transactions
        public Result List()
        {
            try
            {
                var transactions = labInventoryContext.Transaction.ToList();
                return new Result(true, "Transactions fetched successfully!", transactions);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        // Get single transaction
        public Result Single(string transactionId)
        {
            try
            {
                var transaction = labInventoryContext.Transaction.FirstOrDefault(x => x.TransactionId == transactionId);
                if (transaction == null) return new Result(false, "Transaction not found!");

                return new Result(true, "Transaction fetched successfully!", transaction);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
