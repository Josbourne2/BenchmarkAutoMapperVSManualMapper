using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkAutoMapperVSManualMapper
{
    public static class GeneratedMapper
    {
        public static List<SampleObject> Map(this List<SampleObjectDto> input)
        {
            return input.Select(inputElement => new SampleObject
            {
                Id = inputElement.Id,
                Index = inputElement.Index,
                Guid = inputElement.Guid,
                IsActive = inputElement.IsActive,
                TextData = inputElement.TextData
            }).ToList();
        }       
    }
}
