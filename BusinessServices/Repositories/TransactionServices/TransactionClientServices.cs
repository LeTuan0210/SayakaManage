using AutoMapper;
using DataServices.Interfaces;
using DataServices.Repository;

namespace BusinessServices.Repositories
{
    public class TransactionClientServices : TransactionBaseServices, ITransactionClientServices
    {
        private readonly ITransactionDataServices _transactionDataServices;
        private readonly IMapper _mapper;
        public TransactionClientServices(ITransactionDataServices transactionServices, IMapper mapper) : base(transactionServices, mapper)
        {
            _transactionDataServices = transactionServices;
            _mapper = mapper;
        }
    }
}
