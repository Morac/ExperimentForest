using UnityEngine;
using System.Collections;

public class WanderBotFactory : MonoBehaviour {

	public WanderBot prefab;

	public float MinSpawnTime = 2f;
	public float MaxSpawnTime = 4f;

	float nextSpawnTime;

	void Update()
	{
		if(Time.time > nextSpawnTime)
		{
			WanderBot wanderbot;
			wanderbot = Instantiate(prefab, transform.position, Quaternion.identity) as WanderBot;
			wanderbot.direction = Vector3.forward;
			wanderbot = Instantiate(prefab, transform.position, Quaternion.identity) as WanderBot;
			wanderbot.direction = Vector3.back;
			wanderbot = Instantiate(prefab, transform.position, Quaternion.identity) as WanderBot;
			wanderbot.direction = Vector3.left;
			wanderbot = Instantiate(prefab, transform.position, Quaternion.identity) as WanderBot;
			wanderbot.direction = Vector3.right;
			
			nextSpawnTime = Time.time + Random.Range(MinSpawnTime, MaxSpawnTime);
		}
	}
}
