using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using Mapster;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BenchmarkAutoMapperVSManualMapper
{
    [ShortRunJob]
    [NativeMemoryProfiler]
    [MemoryDiagnoser]
    public class BenchmarkMappers
    {
        private readonly List<SampleObjectDto> _input;
        private readonly SampleObjectDto _inputSingle;
        private readonly IMapper _mapper;

        public BenchmarkMappers()
        {
            _input = LoadJson();
            _inputSingle = _input.First();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<List<SampleObjectDto>, List<SampleObject>>();
                cfg.CreateMap<SampleObjectDto, SampleObject>();
            });
            IMapper mapper = config.CreateMapper();
            _mapper = mapper;
        }

        [Benchmark]
        public List<SampleObject> BenchmarkAutoMapperForList()
        {
            List<SampleObject> output = _mapper.Map<List<SampleObject>>(_input);
            return output;
        }

        [Benchmark]
        public SampleObject BenchmarkAutoMapperForSingle()
        {
            SampleObject output = _mapper.Map<SampleObject>(_inputSingle);
            return output;
        }

        [Benchmark]
        public List<SampleObject> BenchmarkManualMapperForList()
        {
            List<SampleObject> output = _input.Map();
            return output;
        }

        [Benchmark]
        public SampleObject BenchmarkManualMapperForSingle()
        {
            SampleObject output = _inputSingle.Map();
            return output;
        }

        [Benchmark]
        public List<SampleObject> BenchmarkMapsterForList()
        {
            var output = _input.Adapt<List<SampleObject>>();
            return output;
        }

        [Benchmark]
        public SampleObject BenchmarkMapsterForSingle()
        {
            var output = _inputSingle.Adapt<SampleObject>();
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