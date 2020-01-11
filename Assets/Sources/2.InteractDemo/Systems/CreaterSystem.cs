using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

namespace InteractDemo
{
    public class CreaterSystem : ReactiveSystem<InputEntity>
    {
        private GameContext _gameContext;

        public CreaterSystem(Contexts context) : base(context.input)
        {
            _gameContext = context.game;
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var inputEntity in entities)
            {
                var gameEntity = _gameContext.CreateEntity();
                gameEntity.AddInteractDemoSprite("fatesaber");
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                gameEntity.AddInteractDemoPos(worldPos);
            }
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInteractDemoMouse 
                && entity.interactDemoMouse.MouseButton == Enums.MouseButton.LEFT 
                &&entity.interactDemoMouse.MouseEvent == Enums.MouseButtonEvent.DOWN;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.InteractDemoMouse);
        }
        
    }

}
