using PMIS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Utility
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailConfiguration mailRequest);
        string BodyReader(EmailConfiguration emailConfiguration,string Path);
    }
}
