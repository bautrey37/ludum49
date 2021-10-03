using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] Transform carBody;
    [SerializeField] Transform wayPoint1;
    [SerializeField] Transform wayPoint2;
    [SerializeField] float speed = 5f;

    Transform targetPos;
    float rot = 0;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = wayPoint1;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Mathf.Abs(carBody.localPosition.x - wayPoint1.localPosition.x) < 0.5f)
		{
            targetPos = wayPoint2;
            spriteRenderer.flipX = true;

		}

        else if (Mathf.Abs(carBody.localPosition.x - wayPoint2.localPosition.x) < 0.5f)
		{
            targetPos = wayPoint1;
            spriteRenderer.flipX = false;
		}

        carBody.position = Vector2.MoveTowards(carBody.position, targetPos.position, speed * Time.deltaTime);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Player was hit by car");
            Events.EndLevel(false);
        }
    }
}
