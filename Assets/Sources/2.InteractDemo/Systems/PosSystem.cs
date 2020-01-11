using System.Collections.Generic;
using Entitas;

namespace InteractDemo
{
    internal class PosSystem : ReactiveSystem<GameEntity>
    {
        public PosSystem(Contexts context) : base(context.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                gameEntity.interactDemoView.ViewTransform.position = gameEntity.interactDemoPos.Pos;
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoPos;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractDemoPos);
        }
    }
}