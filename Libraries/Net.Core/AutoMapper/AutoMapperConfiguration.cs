using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net.Core.AutoMapper
{
    public class AutoMapperConfiguration
    {
        private readonly MapperConfiguration _config;

        public IMapper Mapper { get; private set; }

        public AutoMapperConfiguration(MapperConfiguration mapperConfiguration)
        {
            _config = mapperConfiguration;

            Mapper = mapperConfiguration.CreateMapper();
        }
    }
}
