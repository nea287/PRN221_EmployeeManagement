using EmployeeManagement_BusinessLayer.Request.Achievement;
using EmployeeManagement_BusinessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement_BusinessLayer.IServices
{
    public interface IAchievementService
    {
        ResponseResult<AchievementViewModel> GetAchievement(string achieCode);
        DynamicModelResponse.DynamicModelsResponse<AchievementViewModel> GetAchievements(int page, int size);
        ResponseResult<AchievementViewModel> CreateAchievement(AchievementRequestModel achie);
        ResponseResult<AchievementViewModel> UpdateAchievement(AchievementRequestModel achie, string achieCode);
        //bool DeleteAchievement(string achieCode); 
    }
}
