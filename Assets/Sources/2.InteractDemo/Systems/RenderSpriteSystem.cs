using System;
using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

namespace InteractDemo
{
    public class RenderSpriteSystem : ReactiveSystem<GameEntity>
    {
        public RenderSpriteSystem(Contexts contexts) : base(contexts.game)
        {
            
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Transform trans = gameEntity.interactDemoView.ViewTransform;
                SpriteRenderer sr = trans.GetComponent<SpriteRenderer>();
                if (sr == null)
                    sr= trans.gameObject.AddComponent<SpriteRenderer>();
                sr.sprite = Resources.Load<Sprite>(gameEntity.interactDemoSprite.SpriteName);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoSprite&&entity.hasInteractDemoView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractDemoSprite);
        }
    }

}
