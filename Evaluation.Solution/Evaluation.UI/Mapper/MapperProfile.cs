using AutoMapper;
using Evaluation.UI.Models;
using Evaluation.UI.Response;

namespace Evaluation.Mapper
{
    public class MappingProfile : Profile
    {
        public class Source<T>
        {
            public T Value { get; set; }
        }

        public class Destination<T>
        {
            public T Value { get; set; }
        }

        
        public MappingProfile()
        {
            //Map from Developer Object to DeveloperDTO Object
            CreateMap(typeof(Source<>), typeof(Destination<>));
            CreateMap<ContactResp, ContactVM>().ReverseMap();
        
        }
    }
}
