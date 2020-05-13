using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace si2.bll.Helpers.AutoMapper
{
   public class AutoMapperService : IAutoMapperService
    {
        public IMapper Mapper
        {
            get { return ObjectMapper.Mapper; }
        }
    }
}
