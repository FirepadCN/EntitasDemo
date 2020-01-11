using UnityEngine;
using System.Collections;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace InteractDemo
{
    [Input,Unique]
    public class MouseComponent : IComponent
    {
        public Enums.MouseButton MouseButton;
        public Enums.MouseButtonEvent MouseEvent;

    }

}
