using Assets.ECS.Components;
using Assets.ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.ECS.Systems
{
	public class ObstacleMoveSystem : IEcsRunSystem
	{
		EcsFilter<Obstacle> _filter;
		private StaticData _staticData;

		public ObstacleMoveSystem(StaticData staticData)
		{
			_staticData = staticData;
		}

		public void Run()
		{
			foreach (var _obstacle in _filter)
			{
				ref var obstacle = ref _filter.Get1(_obstacle);

				if (!_staticData.IsGameOver)
					obstacle.Transform.position += new Vector3(obstacle.Speed * Time.deltaTime, 0, 0);

				if (obstacle.Transform.position.x >= _staticData.DestroyX)
				{
					ref var obstacleEntity = ref _filter.GetEntity(_obstacle);
					GameObject.Destroy(obstacle.Transform.gameObject);
					obstacleEntity.Destroy();
				}
			}
		}
	}
}
