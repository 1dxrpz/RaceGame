using Assets.ECS.Components;
using Assets.ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.ECS.Systems
{
	public class ObstacleInitSystem : IEcsInitSystem, IEcsRunSystem
	{
		private EcsWorld _world;
		private StaticData _staticData;

		public ObstacleInitSystem(StaticData staticData)
		{
			_staticData = staticData;
		}

		public void Init()
		{
		}

		float _carSpawnTimer = 0;
		float _propSpawnTimer = 0;

		public void Run()
		{
			_carSpawnTimer += Time.deltaTime * 10f;
			_propSpawnTimer += Time.deltaTime * 10f;

			if (_carSpawnTimer > _staticData.CarSpawnDensity)
			{
				var spawnIndex = Random.Range(0, _staticData.CarsSpawnPoints.Count);
				var carIndex = Random.Range(0, _staticData.CarObstacles.Count);
				CreateObstacle(_staticData.CarsSpawnPoints[spawnIndex], 
					_staticData.CarObstacles[carIndex], 
					_staticData.ObstacleCarSpeed);
				_carSpawnTimer = 0;
			}
			if (_propSpawnTimer > _staticData.PropSpawnDensity)
			{
				var spawnIndex = Random.Range(0, _staticData.PropsSpawnPoints.Count);
				var carIndex = Random.Range(0, _staticData.PropsObstacles.Count);
				CreateObstacle(
					_staticData.PropsSpawnPoints[spawnIndex], 
					_staticData.PropsObstacles[carIndex]);
				_propSpawnTimer = 0;
			}
		}

		void CreateObstacle(Vector3 spawn, GameObject obstacle, float speed = 0)
		{
			var obstacleEntity = _world.NewEntity();
			ref var _obstacle = ref obstacleEntity.Get<Obstacle>();

			_obstacle.SpawnLocation = spawn;
			_obstacle.Speed = _staticData.PlayerSpeed + speed;
			GameObject obstacleObject = Object.Instantiate(obstacle, spawn, Quaternion.Euler(0, 0, 0));
			_obstacle.Transform = obstacleObject.GetComponent<Transform>();
		}
	}
}
