using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace si2.bll.Helpers.AutoMapper
{
   public interface IAutoMapperService
    {

        IMapper Mapper { get; }
    }
}
