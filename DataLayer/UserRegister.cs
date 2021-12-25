using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
   public class UserRegister
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public int roleId { get; set; }
        public int createdBy { get; set; }
        public bool isActive { get; set; }
    }
    public class UserDetailResponse
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int roleId { get; set; }
        public bool isActive { get; set; }
        public bool isDeleted { get; set; }
    }
}
