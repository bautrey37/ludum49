using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : MonoBehaviour
{
    [SerializeField] Collider2D fov;

	float rotationTarget = 0;
	float[] rotations = { 0f, -60f, 0f, 60f };
	int rotIndex = 0;

	private void Start()
	{
		//fov = GetComponentInChildren<Collider2D>();
		InvokeRepeating("SetRotationTarget", 0, 1.5f);
	}

	private void Update()
	{
		float targetAngle = Mathf.LerpAngle(fov.transform.localEulerAngles.z, rotationTarget, 0.05f);
		fov.transform.localEulerAngles = new Vector3(0, 0, targetAngle);
	}

	void SetRotationTarget()
	{
		rotIndex = rotIndex % 4;
		rotationTarget = rotations[rotIndex];
		rotIndex++;
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.tag == "Player")
		{
			Debug.Log("Player was caught by policeman!");
			Events.EndLevel(false);
		}
	}
}
