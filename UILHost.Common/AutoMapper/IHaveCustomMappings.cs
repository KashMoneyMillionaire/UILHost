using AutoMapper;

namespace UILHost.Common.AutoMapper
{
    /// <summary>
    /// Provide custom mapppings of types for AutoMapper configuration.
    /// ViewModels and other DTOs can implement this in order to specify how they should be mapped from the source.
    /// </summary>
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
