using AutoMapper;
using DataServices.Interfaces;

namespace BusinessServices.Repositories
{
    public class TransactionAdminServices : TransactionBaseServices, ITransactionAdminServices
    {
        private readonly ITransactionDataServices _transactionDataServices;
        private readonly IMapper _mapper;
        public TransactionAdminServices(ITransactionDataServices transactionServices, IMapper mapper) : base(transactionServices, mapper)
        {
            _transactionDataServices = transactionServices;
            _mapper = mapper;
        }
    }
}
