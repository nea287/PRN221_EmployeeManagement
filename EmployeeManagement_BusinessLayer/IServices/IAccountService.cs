using EmployeeManagement_BusinessLayer.Request.Account;
using EmployeeManagement_BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.IServices
{
    public interface IAccountService
    {
        ResponseResult<AccountViewModel> GetAccountByID(int accID);
        DynamicModelResponse.DynamicModelsResponse<AccountViewModel> GetAccounts(int page, int size);
        ResponseResult<AccountViewModel> Login(string username, string password);   
        ResponseResult<AccountViewModel> Logout();
        ResponseResult<AccountViewModel> CreateAccount(CreateAccountRequestModel acc);
        ResponseResult<AccountViewModel> UpdateAccount(UpdateAccountRequestModel acc);
        bool DeleteAccount(int accID);
        
    }
}
