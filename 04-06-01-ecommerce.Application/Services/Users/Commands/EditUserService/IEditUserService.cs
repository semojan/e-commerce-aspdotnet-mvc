﻿using _04_06_01_ecommerce.Common.Dto;
using _04_06_01_ecommerce.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_06_01_ecommerce.Application.Services.Users.Commands.EditUserService
{
    public interface IEditUserService
    {
        public ResultDto<User> Execute(RequestEditUserDto request);
    }

}