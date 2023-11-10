using UnityEngine;

namespace Assets.ECS.Components
{
	public struct Player
	{
		public Transform Transform;
		public float Speed;
		public float MoveInterp;
		public float Input;
	}
}
