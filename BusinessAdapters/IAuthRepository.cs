using CommanLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdapters
{
   public interface IAuthRepository
    {
        Task<bool> Register(UserData Reg);
        Task<UserDetailResponse> Login(string username, string password);
        
    }
}
