using UnityEngine;
using System.Collections;
using UnityEditor;

public class TreeSpawn
{
	const int numtrees = 500;
	const string prefabname = "BigTree";
	const float maxrange = 200;

	const float maxSize = 3f;
	const float minSize = 0.5f;

	const float mindist = 6f;

	[MenuItem("Experiment/Growmatic")]
	static void Spawn()
	{
		foreach(Transform tree in MonoBehaviour.FindObjectOfType<Transform>())
		{
			if (tree.name == prefabname)
				MonoBehaviour.DestroyImmediate(tree.gameObject);
		}


		var prefab = Resources.Load(prefabname) as GameObject;
		var instances = new GameObject[numtrees];
		GameObject parent = new GameObject("Trees");
		for (int i = 0; i < numtrees; i++)
		{
			Vector3 pos;
			bool valid = false;
			do
			{
				pos = randpos();
				valid = true;
				for (int c = 0; c < i; c++)
				{
					if((instances[c].transform.position - pos).magnitude < mindist)
					{
						valid = false;
						break;
					}
				}
			} while (!valid);

			var rot = Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0));

			var inst = MonoBehaviour.Instantiate(prefab, pos, rot) as GameObject;
			inst.name = prefabname;
			inst.transform.parent = parent.transform;

			float s = (maxSize - minSize) * (1 - pos.magnitude / maxrange) + minSize;
			inst.transform.localScale = new Vector3(s, s, s);

			instances[i] = inst;
		}
	}

	static Vector3 randpos()
	{
		var rand1 = Random.Range(-1f, 1f);
		var rand2 = Random.Range(-1f, 1f);
		var dir = new Vector3(rand1, 0, rand2).normalized;

		var m = -maxrange;
		var b = maxrange;
		var r = Random.Range(0f, 1f);
		var dist = m * r + b;

		var pos = dir * dist;
		return pos;
	}
}
