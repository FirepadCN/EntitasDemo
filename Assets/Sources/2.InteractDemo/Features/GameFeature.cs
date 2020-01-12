using UnityEngine;
using System.Collections;

namespace InteractDemo
{
    public class GameFeature : Feature
    {
        public GameFeature(Contexts contexts)
        {
            Add(new AddViewSystem(contexts));
            Add(new RenderSpriteSystem(contexts));
            Add(new PosSystem(contexts));
            Add(new MoveSystem(contexts));
            Add(new DirSystem(contexts));
            Add(new ChangeRotationSystem(contexts));
        }
    }

}
