using AutoMapper;
using Core.Domain.Entities.Account;
using Shared.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Common.Mapper.Accounts
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountDto, Account>();
            CreateMap<Account, AccountDto>();
        }
    }
}