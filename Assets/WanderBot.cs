using UnityEngine;
using System.Collections;

public class WanderBot : MonoBehaviour {

	Vector3 direction;

	public float MinThinkTime = 1f;
	public float MaxThinkTime = 4f;

	public float MinSpeed = 1f;
	public float MaxSpeed = 4f;

	float nextThinkTime;
	float speed;

	void Start()
	{
		direction = pickDirection();
		nextThinkTime = Random.Range(MinThinkTime, MaxThinkTime);
		speed = Random.Range(MinSpeed, MaxSpeed);
	}

	void Update()
	{
		if(Time.time > nextThinkTime)
		{
			nextThinkTime = Time.time + Random.Range(MinThinkTime, MaxThinkTime);
			direction = pickDirection();
		}
		transform.position += direction * speed * Time.deltaTime;
	}

	Vector3 pickDirection()
	{
		if (direction == Vector3.zero)
		{
			switch(Random.Range(0, 4))
			{
				case 0:
					return Vector3.right;
				case 1:
					return Vector3.left;
				case 2:
					return Vector3.back;
				case 3:
					return Vector3.forward;
				default:
					return Vector3.up;
			}
		}

		var d = new Vector3();
		d.x = direction.z;
		d.z = direction.x;
		if(Random.Range(0,2)== 0)
		{
			d.x = -d.x;
			d.z = -d.z;
		}
		return d;
	}
}
