using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;


namespace JunMoxiao
{
    /// <summary>
    /// 打印消息的组件
    /// </summary>
    [Game]
    public class LogComponent : IComponent
    {
        /// <summary>
        /// 打印信息
        /// </summary>
        public string message;
    }
}

