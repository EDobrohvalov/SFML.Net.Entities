using System;
using SFML.Graphics;
using SFML.Net.Entities.Collections;
using SFML.Net.Entities.Systems;
using SFML.System;

namespace SFML.Net.Entities
{
    public class World : Drawable, IDisposable
    {
        private readonly Bag<IUpdateSystem> _updateSystems;
        private readonly Bag<IDrawSystem> _drawSystems;

        internal World()
        {
            _updateSystems = new Bag<IUpdateSystem>();
            _drawSystems = new Bag<IDrawSystem>();

            RegisterSystem(ComponentManager = new ComponentManager());
            RegisterSystem(EntityManager = new EntityManager(ComponentManager));
        }

        public void Dispose()
        {
            foreach (var updateSystem in _updateSystems)
                updateSystem.Dispose();

            foreach (var drawSystem in _drawSystems)
                drawSystem.Dispose();

            _updateSystems.Clear();
            _drawSystems.Clear();
            
        }

        internal EntityManager EntityManager { get; }
        internal ComponentManager ComponentManager { get; }

        public int EntityCount => EntityManager.ActiveCount;

        internal void RegisterSystem(ISystem system)
        {
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (system is IUpdateSystem updateSystem)
                _updateSystems.Add(updateSystem);

            if (system is IDrawSystem drawSystem)
                _drawSystems.Add(drawSystem);

            system.Initialize(this);
        }

        public Entity GetEntity(int entityId) 
        {
            return EntityManager.Get(entityId);
        }

        public Entity CreateEntity()
        {
            return EntityManager.Create();
        }

        public void DestroyEntity(int entityId)
        {
            EntityManager.Destroy(entityId);
        }

        public void DestroyEntity(Entity entity)
        {
            EntityManager.Destroy(entity);
        }
        
        public void Update(Time Time)
        {
            foreach (var system in _updateSystems)
                system.Update(Time);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {  
            foreach (var system in _drawSystems)
                system.Draw(target, states);
        }
    }
}