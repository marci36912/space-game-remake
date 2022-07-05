using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField] private Transform Player;
	[SerializeField] private Vector2 minimum, maximum;

	private float delay = 0.4f;
	private float XSzel = 1;
	private float YSzel = 1;
	private float margin = 0.1f;

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void FixedUpdate()
	{
		float cameraPositionX = Player.position.x + XSzel;
		float cameraPositionY = Player.position.y + YSzel;

		if (Mathf.Abs(transform.position.x - cameraPositionX) > margin)
			cameraPositionX = Mathf.Lerp(transform.position.x, cameraPositionX, 1 / delay * Time.deltaTime);
		if (Mathf.Abs(transform.position.y - cameraPositionY) > margin)
			cameraPositionY = Mathf.Lerp(transform.position.y, cameraPositionY, 1 / delay * Time.deltaTime);

		transform.position = new Vector3(Mathf.Clamp(cameraPositionX, minimum.x, maximum.x), Mathf.Clamp(cameraPositionY, minimum.y, maximum.y), transform.position.z);
	}

	public void setMinMax(Vector2 min, Vector2 max)
    {
		minimum = min;
		maximum = max;
    }
}
