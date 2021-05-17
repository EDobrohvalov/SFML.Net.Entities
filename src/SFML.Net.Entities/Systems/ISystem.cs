using System;

namespace SFML.Net.Entities.Systems
{
    public interface ISystem : IDisposable
    {
        void Initialize(World world);
    }
}