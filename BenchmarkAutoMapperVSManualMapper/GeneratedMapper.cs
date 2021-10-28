using System.Collections.Generic;
using System.Linq;

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

        public static SampleObject Map(this SampleObjectDto input)
        {
            return new SampleObject
            {
                Id = input.Id,
                Index = input.Index,
                Guid = input.Guid,
                IsActive = input.IsActive,
                TextData = input.TextData
            };
        }
    }
}