using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

namespace InteractDemo
{
    public class StartMoveSystem : ReactiveSystem<InputEntity>
    {
        private GameContext _gameContext;
        private IGroup<GameEntity> _moveGroup;

        public StartMoveSystem(Contexts context) : base(context.input)
        {
            _gameContext = context.game;
            _moveGroup = context.game.GetGroup(GameMatcher.InteractDemoView);
        }

        protected override void Execute(List<InputEntity> entities)
        {
            foreach (var entity in entities)
            {
                Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                foreach (var gameEntity in _moveGroup)
                {
                    gameEntity.ReplaceInteractDemoMove(worldPos);
                }
            }
        }

        protected override bool Filter(InputEntity entity)
        {
            return entity.hasInteractDemoMouse
                   && entity.interactDemoMouse.MouseButton == Enums.MouseButton.RIGHT
                   && entity.interactDemoMouse.MouseEvent == Enums.MouseButtonEvent.DOWN;
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
        {
            return context.CreateCollector(InputMatcher.InteractDemoMouse);
        }
    }

}
