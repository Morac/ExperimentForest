using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Light))]
public class LightDropoff : MonoBehaviour {

	public Transform character;
	public Transform ground;
	public float maxDist = 150f;

	Camera cam;

	void Start()
	{
		cam = character.GetComponentInChildren<Camera>();
	}

	void Update()
	{
		var mag = character.transform.position.magnitude;
		var i = 1 - mag / maxDist;
		light.intensity = i;
	
		var colour = new Color(i, i, i);
		cam.backgroundColor = colour;
		RenderSettings.fogColor = colour;
		ground.renderer.material.color = colour;
	}
}
