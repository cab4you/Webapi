using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer
{
  public  class UserData
    {
        public int userId { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int roleId { get; set; }


    }
    public class Response
    {
        public dynamic data { get; set; }
        public bool success { get; set; }
        public DateTime dateTime { get; set; }
        public string message { get; set; }
    }
}
