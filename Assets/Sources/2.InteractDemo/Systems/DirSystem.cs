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

                //四元数方式直接操作
                //Quaternion angleOffset=Quaternion.FromToRotation(view.up,dir);
                //view.rotation *= angleOffset;

                //普通方法利用RotationSystem控制
                float angle = Mathf.Atan2(dir.y, dir.x);
                gameEntity.ReplaceInteractDemoDir(angle);
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