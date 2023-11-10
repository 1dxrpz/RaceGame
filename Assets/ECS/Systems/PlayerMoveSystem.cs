using Assets.ECS.Components;
using Assets.ECS.Data;
using Leopotam.Ecs;
using UnityEngine;

namespace Assets.ECS.Systems
{
	public class PlayerMoveSystem : IEcsRunSystem
	{
		readonly EcsFilter<Player> _filter;
		readonly int ClampMin = -30;
		readonly int ClampMax = 30;

		private StaticData _staticData;

		public PlayerMoveSystem(StaticData staticData)
		{
			_staticData = staticData;
		}

		public void Run()
		{
			foreach (var _player in _filter)
			{
				ref var player = ref _filter.Get1(_player);

				if (_staticData.IsGameOver)
					return;

				player.Input = Input.GetAxisRaw("Horizontal");

				player.MoveInterp = Mathf.Lerp(player.MoveInterp, player.Input, 2f * Time.deltaTime);

				if (player.Transform.position.z > ClampMin && player.Input < 0 ||
						player.Transform.position.z < ClampMax && player.Input > 0)
				{
					player.Transform.rotation = Quaternion.Lerp(player.Transform.rotation,
						Quaternion.Euler(0, player.Input < 0 ? 70 : player.Input > 0 ? 120 : 90, 0),
						Time.deltaTime * 3f);
				}

				if (Mathf.Abs(player.MoveInterp) > 0.1f)
				{
					player.Transform.position += new Vector3(0, 0, player.MoveInterp * player.Speed * Time.deltaTime);
					var pos = Mathf.Clamp(player.Transform.position.z, ClampMin, ClampMax);
					player.Transform.position = new Vector3(player.Transform.position.x, player.Transform.position.y, pos);
					Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 75, Time.deltaTime * 2f);
				}
				Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, 60, Time.deltaTime * 1.25f);
				player.Transform.rotation = Quaternion.Lerp(player.Transform.rotation,
						Quaternion.Euler(0, 90, 0),
						Time.deltaTime * 1f);

				Camera.main.transform.position = Vector3.Lerp(
					Camera.main.transform.position,
					player.Transform.position + new Vector3(10, 10, 0),
					Time.deltaTime * 2.5f);
				Camera.main.transform.LookAt(player.Transform.position + new Vector3(0, 5, 0));
			}
		}
	}
}
