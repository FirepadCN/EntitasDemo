using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JunMoxiao
{
    /// <summary>
    /// 将创建的系统添加到框架内
    /// </summary>
    public class AddGameSystem : Feature
    {
        public AddGameSystem(Contexts contexts) : base("AddGameSystem")
        {
            Add(new LogSystem(contexts));
            Add(new InitSystem(contexts));

        }
    }
}

