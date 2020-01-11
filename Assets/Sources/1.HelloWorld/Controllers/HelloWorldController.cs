using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace JunMoxiao
{
    public class HelloWorldController : MonoBehaviour
    {
        private Systems _systems;

        void Start()
        {
            var context = Contexts.sharedInstance;
            _systems=new Feature("Systems").Add(new AddGameSystem(context));
            _systems.Initialize();
        }

        void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}

