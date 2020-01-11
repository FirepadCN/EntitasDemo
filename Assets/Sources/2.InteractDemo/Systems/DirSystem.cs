using System;
using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

namespace InteractDemo
{

    public class DirSystem : ReactiveSystem<GameEntity>
    {
        public DirSystem(Contexts contexts) : base(contexts.game)
        {

        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Transform view = gameEntity.interactDemoView.ViewTransform;
                Vector3 tarPos = gameEntity.interactDemoMove.TargetPos;
                Vector3 dir = (tarPos - view.position).normalized;

                Quaternion angleOffset=Quaternion.FromToRotation(view.up,dir);
                view.rotation *= angleOffset;
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoMove
                   && entity.hasInteractDemoView
                   && entity.isInteractDemoMoveComplete;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractDemoMove);
        }

       
    }

}