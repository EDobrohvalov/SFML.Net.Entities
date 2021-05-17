using SFML.System;

namespace SFML.Net.Entities.Systems
{
    public abstract class EntityProcessingSystem : EntityUpdateSystem
    {
        protected EntityProcessingSystem(AspectBuilder aspectBuilder)
            : base(aspectBuilder)
        {
        }

        public override void Update(Time Time)
        {
            Begin();

            foreach (var entityId in ActiveEntities)
                Process(Time, entityId);

            End();
        }

        public virtual void Begin() { }
        public abstract void Process(Time Time, int entityId);
        public virtual void End() { }
    }
}