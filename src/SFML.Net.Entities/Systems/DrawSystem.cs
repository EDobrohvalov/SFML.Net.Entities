using SFML.Graphics;
using SFML.System;

namespace SFML.Net.Entities.Systems
{
    public interface IDrawSystem : ISystem
    {
        void Draw(RenderTarget target, RenderStates states);
    }

    public abstract class DrawSystem : IDrawSystem
    {
        public virtual void Dispose() { }
        public virtual void Initialize(World world) { }
        public abstract void Draw(RenderTarget target, RenderStates states);
    }
}