using System;
using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

namespace InteractDemo
{

    public class ChangeRotationSystem : ReactiveSystem<GameEntity>
    {
        public ChangeRotationSystem(Contexts  context) : base(context.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Transform viewTransform = gameEntity.interactDemoView.ViewTransform;
                var angle = gameEntity.interactDemoDir.Rotation * Mathf.Rad2Deg;
                viewTransform.rotation=Quaternion.AngleAxis(angle-90.0f,Vector3.forward);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoView
                   && entity.hasInteractDemoDir;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractDemoDir);
        }
    }

}