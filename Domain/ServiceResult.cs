using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ServiceResult
    {
        public bool result { get; set; }
        public IDayDto baseDto { get; set; }
        public ICollection<IDayDto> dayDtoList {get;set;}
        public ServiceResult(bool result) 
        {
           this.result = result;
        }
        public ServiceResult(IDayDto baseDto, bool result)
        {
            this.baseDto = baseDto;
            this.result = result;
        }
        public ServiceResult(ICollection<IDayDto> dayDtoList,bool result)
        {
            this.result = result;
            this.dayDtoList = dayDtoList;
        }


    }
}
