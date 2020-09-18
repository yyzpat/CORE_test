using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CORE_test.Data;
using CORE_test.DTOs;

namespace CORE_test.Mappings
{
  public class Maps : Profile
  {
    public Maps()
    {
      CreateMap<Director, DirectorDTO>().ReverseMap();
    }
    
  }
}
