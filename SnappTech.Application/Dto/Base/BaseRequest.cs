﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnappTech.Application.Dto.Base
{
    public class BaseRequest<T> : IRequest<T> where T : BaseResponse
    {

    }
}
