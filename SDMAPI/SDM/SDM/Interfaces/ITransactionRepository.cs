using SDM.Common.Request;
using SDM.Common.Response;
using SDM.TModels;
using System.Threading.Tasks;

namespace SDM.Interfaces
{
    public interface ITransactionRepository
    {
        public Task<Response> Add(TransactionRequest transactionEntry);
        public Task<Response> Update(TransactionRequest transactionEntry);
        public Task<Response> Delete(TransactionEntry transactionEntry);
        public Response Get(TransactionEntry transactionEntry);
        public Response GetAccountForTransaction(TransactionEntry transactionEntry);
    }
}
