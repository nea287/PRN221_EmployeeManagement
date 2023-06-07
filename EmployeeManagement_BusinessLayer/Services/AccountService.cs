using AutoMapper;
using AutoMapper.QueryableExtensions;
using EmployeeManagement_BusinessLayer.Common;
using EmployeeManagement_BusinessLayer.IServices;
using EmployeeManagement_BusinessLayer.Request.Account;
using EmployeeManagement_BusinessLayer.Utilities;
using EmployeeManagement_BusinessLayer.ViewModels;
using EmployeeManagement_SWD392.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly SWD392_EmployeeManagementContext _context;

        public AccountService(IMapper mapper, SWD392_EmployeeManagementContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        //Creata a account
        public ResponseResult<AccountViewModel> CreateAccount(CreateAccountRequestModel acc)
        {
            Account account = null;
            try
            {
                account = _context.Accounts
                    .FirstOrDefault(x => x.Username.Equals(acc.Username));

                if(account != null)
                {
                    _context.Entry(account).State = EntityState.Detached;
                    throw new Exception(Constraints.EXISTED_ACCOUNT);
                }
                 account = _mapper.Map<Account>(acc);
                _context.Entry(account).State = EntityState.Added;
                
                _context.Accounts.Add(account);

            }catch(Exception ex)
            {
                throw new Exception(Constraints.FAILED_CREATE);
            }
            
            return new ResponseResult<AccountViewModel>()
            {
                Message = Constraints.SUC_CREATE,

                Value = _mapper.Map<AccountViewModel>(
                    _context.Accounts.FirstOrDefault(
                        x => x.Username.Equals(acc.Username)))
            };
        }

        public bool DeleteAccount(int accID)
        {
            try
            {
                Account account = _context.Accounts
                    .FirstOrDefault(x => x.AccountId == accID);
                
                if(account == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_ACCOUNT);
                }

                account.Salary = 0;

                _context.Entry(account).State = EntityState.Detached;
                _context.Entry(account).State = EntityState.Modified;

                _context.Accounts.Update(account);
                _context.SaveChanges();
                
            }catch(Exception ex)
            {
                throw new Exception(Constraints.FAILED_DELETE);
            }
            return true;
        }
        //Get account By AccountID
        public ResponseResult<AccountViewModel> GetAccountByID(int accID)
        {
            Account account = null;
            try
            {
                account = _context.Accounts.FirstOrDefault(
                        x => x.AccountId == accID);

            }catch(Exception ex)
            {
                throw new Exception(Constraints.NOT_FOUND_ACCOUNT);
            }

            _context.Entry(account).State = EntityState.Detached;
            return new ResponseResult<AccountViewModel>()
            {
                Message = "Xin chào! " + account.Username,
                Value = _mapper.Map<AccountViewModel>(account)
            };

        }
        //get list account
        public DynamicModelResponse.DynamicModelsResponse<AccountViewModel> GetAccounts(int page, int size)
        {
            (int, IQueryable<AccountViewModel>) pagingAccount;
            try
            {
                pagingAccount = _context.Accounts.Where(x => x.Status != 0)
                    .ProjectTo<AccountViewModel>(_mapper.ConfigurationProvider)
                    .PagingIQueryable(page, size, Constraints.LimitPaging, Constraints.DefaultPaging);
            }
            catch (Exception ex)
            {
                throw new Exception(Constraints.EMPTY_LIST);
            }

            return new DynamicModelResponse.DynamicModelsResponse<AccountViewModel>()
            {
                Metadata = new DynamicModelResponse.PagingMetadata()
                {
                    Page = page,
                    Size = size,
                    Total = pagingAccount.Item1
                },
                Results = pagingAccount.Item2.ToList()
            };
            //throw new Exception();
        }

        //Login
        public ResponseResult<AccountViewModel> Login(string username, string password)
        {
            Account account = null;

            try
            {

                account = _context.Accounts.FirstOrDefault(
                    x => x.Username.Equals(username) 
                    && x.Password.Equals(password));
                
            }catch(Exception ex)
            {
                throw new Exception(Constraints.FAILED_LOGIN);
            }

            _context.Entry(account).State = EntityState.Detached;

            return new ResponseResult<AccountViewModel>()
            {
                Message = Constraints.SUC_LOGIN,
                Value = _mapper.Map<AccountViewModel>(account)
            };
        }

        public ResponseResult<AccountViewModel> Logout()
        {
            throw new NotImplementedException();
        }
        //UpdateAccount
        public ResponseResult<AccountViewModel> UpdateAccount(UpdateAccountRequestModel acc)
        {
            try
            {
                var findAccount = _context.Accounts
                    .FirstOrDefault(x => x.AccountId == acc.AccountId);

                if(findAccount == null)
                {
                    throw new Exception(Constraints.NOT_FOUND_ACCOUNT);
                }

                Account account = _mapper.Map<Account>(acc);

                _context.Entry(findAccount).State = EntityState.Detached;               
                _context.Entry(account).State = EntityState.Modified;
                _context.Accounts.Update(account);
                _context.SaveChanges();

            }catch(Exception ex)
            {
                throw new Exception(Constraints.FAILED_UPDATE);
            }

            return new ResponseResult<AccountViewModel>()
            {
                Message = Constraints.SUC_UPDATE,
                Value = _mapper.Map<AccountViewModel>(acc)
            };
        }
    }
}
