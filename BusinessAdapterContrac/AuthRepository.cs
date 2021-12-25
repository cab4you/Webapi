using BusinessAdapters;
using CommanLayer;
using Dapper;
using DataLayer;
using Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Linq;

namespace BusinessAdapterContrac
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IOptions<AppSettings> _appSettings;
        public AuthRepository(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<UserDetailResponse> Login(string userId, string password)
        {
            
            using (IDbConnection dbConnection = new SqlConnection(_appSettings.Value.DefaultConnection))
            {
                var reader = await dbConnection.QueryMultipleAsync("userLogin",
                            param: new
                            {
                                userId = userId,
                                password = password
                            },
                            commandType: CommandType.StoredProcedure);

                var listValue = reader.Read<UserDetailResponse>().FirstOrDefault(); 
                return listValue;
            }
        }

        public async Task<bool> Register(UserData Reg)
        {
            using (IDbConnection dbConnection = new SqlConnection(_appSettings.Value.DefaultConnection))
            {
                return await dbConnection.QueryFirstOrDefaultAsync<bool>("userRegistration",
                               param: new
                               {
                                   Reg.name,
                                   Reg.password,
                                   Reg.roleId,
                                   Reg.userId,
                                   Reg.email
                                   
                               },
                               commandType: CommandType.StoredProcedure);

            }
        }
    }
}
