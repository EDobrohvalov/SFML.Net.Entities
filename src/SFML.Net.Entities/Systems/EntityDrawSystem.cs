using SFML.Graphics;
using SFML.System;

namespace SFML.Net.Entities.Systems
{
    public abstract class EntityDrawSystem : EntitySystem, IDrawSystem
    {
        protected EntityDrawSystem(AspectBuilder aspect)
            : base(aspect)
        {
        }

        public abstract void Draw(RenderTarget target, RenderStates states);
    }
}