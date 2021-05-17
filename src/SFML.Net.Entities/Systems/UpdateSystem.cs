using SFML.System;

namespace SFML.Net.Entities.Systems
{
    public interface IUpdateSystem : ISystem
    {
        void Update(Time Time);
    }

    public abstract class UpdateSystem : IUpdateSystem
    {
        public virtual void Dispose() { }
        public virtual void Initialize(World world) { }
        public abstract void Update(Time Time);
    }
}