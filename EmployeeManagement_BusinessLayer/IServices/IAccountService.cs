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
        Task<ResponseResult<AccountViewModel>> Login(string username, string password);   
        Task<ResponseResult<AccountViewModel>> Logout(); 
        Task<ResponseResult<AccountViewModel>> CreateAccount(CreateAccountRequestModel acc);
        Task<ResponseResult<AccountViewModel>> UpdateAccount(UpdateAccountRequestModel acc);
        Task<ResponseResult<AccountViewModel>> UpdateAccountByManager(UpdateAccountByManagerRequestModel acc);

        Task<bool> DeleteAccount(int accID);
        
    }
}
