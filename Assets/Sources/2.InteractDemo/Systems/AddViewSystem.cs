using System;
using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;

namespace InteractDemo
{
    public class AddViewSystem : ReactiveSystem<GameEntity>
    {
        private Transform _parenTransform;
        private Contexts _contexts;

        public AddViewSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _parenTransform=new GameObject("ViewParent").transform;    
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach ( var entity in entities)
            {
                GameObject go = new GameObject("View");
                go.transform.SetParent(_parenTransform);
                go.Link(entity);
                entity.AddInteractDemoView(go.transform);
               entity.isInteractDemoMoveComplete = true;
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoSprite&&!entity.hasInteractDemoView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractDemoSprite);
        }
    }

}
