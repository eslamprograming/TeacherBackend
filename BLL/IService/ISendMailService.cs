﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface ISendMailService
    {
        Task sendEmailAsync(string mailTo, string subject, string body);
    }
}