﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.SendMail.Services
{
    public interface IEmailService
    {
        public Task SendEmail(Email email);
    }
}
