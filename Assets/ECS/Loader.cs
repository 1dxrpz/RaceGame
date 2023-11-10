using Assets.ECS.Data;
using Assets.ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;

public class Loader : MonoBehaviour
{
	public StaticData staticData;
	private EcsWorld _world;
    private EcsSystems _systems;

    void Start()
    {
        _world = new EcsWorld();
		_systems = new EcsSystems(_world);

		staticData.IsGameOver = false;

        _systems
            .Add(new PlayerInitSystem(staticData))
            .Add(new RoadInitSystem(staticData))
            .Add(new ObstacleInitSystem(staticData))
            .Add(new RoadMoveSystem(staticData))
            .Add(new PlayerMoveSystem(staticData))
            .Add(new PlayerCollisionSystem(staticData))
            .Add(new ObstacleMoveSystem(staticData))
            .Init();
	}

    void Update()
    {
        _systems.Run();
    }
	private void OnDestroy()
	{
		_systems.Destroy();
        _systems = null;
        _world.Destroy();
        _world = null;
	}
}
