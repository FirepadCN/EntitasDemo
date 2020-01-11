using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;
using DG.Tweening;

namespace InteractDemo
{
    public class MoveSystem : ReactiveSystem<GameEntity>
    {
        public MoveSystem(Contexts context) : base(context.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.interactDemoView.ViewTransform.DOMove(entity.interactDemoMove.TargetPos, 2.0f);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoMove 
                && entity.isInteractDemoMoveComplete
                && entity.hasInteractDemoView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractDemoMove);
        }
    }

}
