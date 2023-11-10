using Assets.ECS.Components;
using Assets.ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.ECS.Systems
{
	public class RoadInitSystem : IEcsInitSystem
	{
		private EcsWorld _world;
		private StaticData _staticData;

		public RoadInitSystem(StaticData staticData)
		{
			_staticData = staticData;
		}
		public void Init()
		{
			CreateRoad(new Vector3(0, 0, 0));
			CreateRoad(new Vector3(-60, 0, 0));
			CreateRoad(new Vector3(-120, 0, 0));
		}
		void CreateRoad(Vector3 spawn)
		{
			var roadEntity = _world.NewEntity();
			ref var road = ref roadEntity.Get<Road>();

			road.SpawnLocation = spawn;

			GameObject roadObject = Object.Instantiate(_staticData.RoadPrefab, spawn, Quaternion.identity);

			road.Transform = roadObject.GetComponent<Transform>();
		}
	}
}
