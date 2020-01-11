using UnityEngine;
using System.Collections;

namespace InteractDemo
{
    public class InputFeature : Feature
    {
        public InputFeature(Contexts contexts)
        {
            Add(new MouseSystem(contexts));
            Add(new CreaterSystem(contexts));
            Add(new StartMoveSystem(contexts));
        }
    }

}
