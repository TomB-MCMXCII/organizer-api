using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ServiceResult<T> where T : BaseDto
    {
        public bool result { get; set; }
        public T baseDto { get; set; }
        public ServiceResult(bool result) 
        {
           this.result = result;
        }
        public ServiceResult(T baseDto, bool result)
        {
            this.baseDto = baseDto;
            this.result = result;
        }


    }
}
