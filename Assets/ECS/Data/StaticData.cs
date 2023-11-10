using Leopotam.Ecs;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.ECS.Data
{
	[CreateAssetMenu]
	public class StaticData : ScriptableObject
	{
		public bool IsGameOver = false;
		public bool GodMode = false;
		public GameObject PlayerPrefab;
		public Vector3 SpawnPoint;
		public float PlayerStrafeSpeed = 5f;
		public float PlayerSpeed = 40f;
		public float ObstacleCarSpeed = 40f;
		public float CarSpawnDensity = 2.5f;
		public float PropSpawnDensity = 2.5f;
		public float DestroyX = 60f;
		public GameObject RoadPrefab;
		public List<Vector3> CarsSpawnPoints;
		public List<GameObject> CarObstacles;
		public List<Vector3> PropsSpawnPoints;
		public List<GameObject> PropsObstacles;
	}
}
