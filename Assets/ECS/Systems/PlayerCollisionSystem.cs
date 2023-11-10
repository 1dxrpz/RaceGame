using Assets.ECS.Components;
using Assets.ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.ECS.Systems
{
	public class PlayerCollisionSystem : IEcsRunSystem
	{
		readonly EcsFilter<Player> _filter;
		readonly EcsFilter<Obstacle> _obstacleFilter;

		private StaticData _staticData;

		public PlayerCollisionSystem(StaticData staticData)
		{
			_staticData = staticData;
		}

		public void Run()
		{
			foreach (var _player in _filter)
			{
				ref var player = ref _filter.Get1(_player);
				foreach (var _obstacle in _obstacleFilter)
				{
					ref var obstacle = ref _obstacleFilter.Get1(_obstacle);
					var collide = player.Transform.GetComponent<BoxCollider>().bounds.Intersects(
						obstacle.Transform.gameObject.GetComponent<BoxCollider>().bounds);

					if (collide && !_staticData.GodMode)
					{
						UI.GameOver?.Invoke();
						_staticData.IsGameOver = true;
					}
				}
			}

		}
	}
}
