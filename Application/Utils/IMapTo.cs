using AutoMapper;

namespace Application.Utils
{
    public interface IMapTo<T>
    {
        void Mapping(Profile profile)
        {
            profile.CreateMap(GetType(), typeof(T));
        }
    }
}
