using Assets.ECS.Components;
using Assets.ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.ECS.Systems
{
	public class RoadMoveSystem : IEcsRunSystem
	{
		EcsFilter<Road> _filter;
		private StaticData _staticData;

		public RoadMoveSystem(StaticData staticData)
		{
			_staticData = staticData;
		}

		public void Run()
		{
			foreach (var i in _filter)
			{
				ref var road = ref _filter.Get1(i);

				if (!_staticData.IsGameOver)
				{
					road.offset += Time.deltaTime * _staticData.PlayerSpeed;
					if (road.offset < 60)
					{
						road.Transform.position = road.SpawnLocation +
							new Vector3(road.offset, 0, 0);
					}
					else
					{
						road.Transform.position = road.SpawnLocation;
						road.offset = 0;
					}
				}
			}
		}
	}
}
