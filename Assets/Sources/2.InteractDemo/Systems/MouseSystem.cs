using UnityEngine;
using System.Collections;
using Entitas;

namespace InteractDemo
{
    public class MouseSystem : IExecuteSystem,IInitializeSystem
    {

        private InputEntity _inputEntity;
        private InputContext _contexts;

        public MouseSystem(Contexts contexts)
        {
            _contexts = contexts.input;
        }

        /// <summary>
        /// init
        /// </summary>
        public void Initialize()
        {
            _inputEntity = _contexts.interactDemoMouseEntity;
        }

        /// <summary>
        /// update
        /// </summary>
        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _contexts.ReplaceInteractDemoMouse(Enums.MouseButton.LEFT, Enums.MouseButtonEvent.DOWN);
                //_inputEntity.ReplaceInteractDemoMouse(Enums.MouseButton.LEFT, Enums.MouseButtonEvent.DOWN);//单例对象需用上下文contexts来调用
                //_inputEntity.interactDemoMouse.MouseButton= Enums.MouseButton.LEFT;  //不能通过直接赋值，否则框架无法正确响应
                
            }
            if (Input.GetMouseButtonDown(1))
            {
                _contexts.ReplaceInteractDemoMouse(Enums.MouseButton.RIGHT, Enums.MouseButtonEvent.DOWN);
            }
        }

        
    }

}
