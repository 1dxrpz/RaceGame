using Assets.ECS.Components;
using Assets.ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.ECS.Systems
{
	public class PlayerInitSystem : IEcsInitSystem
	{
		private EcsWorld _world;
		private StaticData _staticData;

		public PlayerInitSystem(StaticData staticData)
		{
			_staticData = staticData;
		}

		public void Init()
		{
			var playerEntity = _world.NewEntity();

			ref var player = ref playerEntity.Get<Player>();

			GameObject playerObject = Object.Instantiate(_staticData.PlayerPrefab, _staticData.SpawnPoint, Quaternion.identity);
			playerObject.transform.rotation = Quaternion.Euler(0, 90, 0);

			player.Transform = playerObject.GetComponent<Transform>();
			player.Speed = _staticData.PlayerStrafeSpeed;

			player.MoveInterp = player.Input;
		}
	}
}
