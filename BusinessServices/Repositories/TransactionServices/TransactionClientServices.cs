using AutoMapper;
using DataServices;
using DataServices.Interfaces;
using DataServices.Repository;
using Microsoft.AspNetCore.Identity;

namespace BusinessServices.Repositories
{
    public class TransactionClientServices : TransactionBaseServices, ITransactionClientServices
    {
        private readonly ITransactionDataServices _transactionDataServices;
        private readonly IMapper _mapper;
        public TransactionClientServices(ITransactionDataServices transactionServices, IMapper mapper, UserManager<ApplicationUser> userManager) : base(transactionServices, mapper, userManager)
        {
            _transactionDataServices = transactionServices;
            _mapper = mapper;
        }
    }
}
