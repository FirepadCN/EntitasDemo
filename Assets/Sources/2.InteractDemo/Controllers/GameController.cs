using UnityEngine;
using System.Collections;
using Entitas;
using InteractDemo;

public class GameController : MonoBehaviour
{

    private Systems _systems;

    private Contexts _contexts;
    // Use this for initialization
    void Start()
    {
        _contexts=Contexts.sharedInstance;
        _systems = CreateSystem(_contexts);
    }

    // Update is called once per frame
    void Update()
    {
        _systems.Execute();
        _systems.Cleanup();
    }

    private Systems  CreateSystem(Contexts contexts)
    {
        return new Feature("System")
            .Add(new GameFeature(contexts))
            .Add(new InputFeature(contexts));
    }
}
