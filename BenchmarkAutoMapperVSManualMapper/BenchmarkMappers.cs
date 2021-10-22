using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using System.IO;
using Newtonsoft.Json;
using AutoMapper;

namespace BenchmarkAutoMapperVSManualMapper
{
    [ShortRunJob]
    [NativeMemoryProfiler]
    [MemoryDiagnoser]
    public class BenchmarkMappers
    {
        private readonly List<SampleObjectDto> _input;
        private readonly IMapper _mapper;
        public BenchmarkMappers()
        {
            _input = LoadJson();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<List<SampleObjectDto>, List<SampleObject>>();
            });
            IMapper mapper = config.CreateMapper();
            _mapper = mapper;
        }

        [Benchmark]
        public List<SampleObject> BenchmarkManualMapper()
        {
            List<SampleObject> output = _input.Map();
            return output;
        }

        [Benchmark]
        public List<SampleObject> BenchmarkAutoMapper()
        {
            List<SampleObject> output = _mapper.Map<List<SampleObject>>(_input);
            return output;
        }
        public List<SampleObjectDto> LoadJson()
        {
            using (StreamReader r = new StreamReader(@".\JsonInput\SampleObject.json"))
            {
                string json = r.ReadToEnd();
                List<SampleObjectDto> items = JsonConvert.DeserializeObject<List<SampleObjectDto>>(json);
                return items;
            }
        }
    }
}
