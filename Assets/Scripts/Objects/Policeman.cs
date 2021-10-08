using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Policeman : MonoBehaviour
{
    [SerializeField] Collider2D fov;
	[SerializeField] float speed_var = 3f;
	[SerializeField] SpriteRenderer alertSprite;
    [SerializeField] bool alerted = false;
	[SerializeField] float alertTime = 1.5f;

	float tempTime = 0.1f;
	float alertRot = 0f;
    float rotationTarget = 0;
	float[] rotations = { 0f, -60f, 0f, 60f };
	int rotIndex = 0;


	private void Start()
    {
        InvokeRepeating("SetRotationTarget", 0, speed_var);
		alertRot = alertSprite.transform.rotation.z;
    }

    private void Update()
	{
		float targetAngle = Mathf.LerpAngle(fov.transform.localEulerAngles.z, rotationTarget, 0.05f);
		fov.transform.localEulerAngles = new Vector3(0, 0, targetAngle);

		if (alerted)
        {
			tempTime -= Time.deltaTime;
			alertSprite.transform.eulerAngles = new Vector3(0, 0, alertSprite.transform.rotation.z + Random.Range(-10, 10));
			alertSprite.transform.position = new Vector3(alertSprite.transform.position.x, alertSprite.transform.parent.position.y + 1f, alertSprite.transform.position.z);


			if (tempTime <= 0)
            {
				Debug.Log("Player was caught by policeman!");
				Events.EndLevel(false);
			}
		}
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
			alerted = true;
			tempTime = alertTime;
			alertSprite.enabled = true;
		}
	}

    public void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.tag == "Player")
        {
			alerted = false;
			alertSprite.enabled = false;
		}
    }
}
