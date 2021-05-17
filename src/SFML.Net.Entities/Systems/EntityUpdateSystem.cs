using SFML.System;

namespace SFML.Net.Entities.Systems
{
    public abstract class EntityUpdateSystem : EntitySystem, IUpdateSystem
    {
        protected EntityUpdateSystem(AspectBuilder aspectBuilder) 
            : base(aspectBuilder)
        {
        }

        public abstract void Update(Time Time);
    }
}