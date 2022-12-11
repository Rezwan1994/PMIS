using System;
using System.Collections.Generic;
using System.Text;

namespace PMIS.Domain.ViewModels.Security
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }

        public bool RememberMe { get; set; }
    }
}
