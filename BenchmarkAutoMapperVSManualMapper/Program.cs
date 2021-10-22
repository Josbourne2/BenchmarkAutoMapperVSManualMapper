using BenchmarkDotNet.Running;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using System.Web;

namespace BenchmarkAutoMapperVSManualMapper
{
    public class Program
    {
        public static void Main(string[] args)
        {




            Console.WriteLine("Hello World!");
           
            //var summary = BenchmarkRunner.Run<Md5VsSha256>();
            var summary = BenchmarkRunner.Run<BenchmarkMappers>();
           


            
        }

       
    }
}
