using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace JunMoxiao
{
    public class LogSystem : ReactiveSystem<GameEntity>
    {
        public LogSystem(Contexts contexts) : base(contexts.game)
        {

        }

        /// <summary>
        ///执行 
        /// </summary>
        /// <param name="entities"></param>
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity gameEntity in entities)
            {
                Debug.Log(gameEntity.junMoxiaoLog.message);
            }
        }

        /// <summary>
        /// 筛选器
        /// </summary>
        protected override bool Filter(GameEntity entity)
        {
            return entity.hasJunMoxiaoLog;
        }

        /// <summary>
        /// 触发器
        /// </summary>
        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.JunMoxiaoLog);
        }
    }

}
