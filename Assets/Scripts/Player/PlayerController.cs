using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Different controls settings. Now only has two but we may add more.
    enum Controls { Normal, Reversed }

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Text controlsText;
    
    float horizontal;
    float vertical;
    Controls currentControls;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentControls = Controls.Normal;
        InvokeRepeating("ChangeControls", 5, 5);
    }

	void Update()
	{
        GetControlsInput();
    }

	// Update is called once per frame
	public void FixedUpdate()
    {
        // Apply force to player rigidbody
        Vector2 force = moveSpeed * new Vector2(horizontal, vertical);
        rb.AddForce(force, ForceMode2D.Force);

        // Slowly pivot back to forward facing position if tilted off course
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, 0.05f);
    }

    // Apply controls
    void GetControlsInput()
	{
        if (currentControls == Controls.Normal)
		{
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        } 

        else if (currentControls == Controls.Reversed)
		{
            horizontal = -Input.GetAxis("Horizontal");
            vertical = -Input.GetAxis("Vertical");
        }
	}

    // Switch up the controls for extra fun :)
    void ChangeControls()
	{
        int choice = Random.Range(0, Controls.GetValues(typeof(Controls)).Length);
        currentControls = (Controls)choice;
        controlsText.text = currentControls.ToString().ToUpper();
    }
}
