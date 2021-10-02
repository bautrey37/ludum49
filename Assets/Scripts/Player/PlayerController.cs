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
    [SerializeField] float rotSpeed = 0.05f;
    [SerializeField] float eulerRot;

    float horizontal;
    float vertical;
    Controls currentControls;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentControls = Controls.Normal;
        InvokeRepeating("ChangeControls", 5, 5); // Call the switch controls function every 5 seconds
    }

	void Update()
	{
        GetControlsInput();
        eulerRot = transform.eulerAngles.z;
    }

	public void FixedUpdate()
    {
        // Apply force to player rigidbody
        Vector2 force = moveSpeed * new Vector2(horizontal, vertical);
        rb.AddForce(force, ForceMode2D.Force);

        // Slowly pivot back to forward facing position if tilted off course


        if (transform.eulerAngles.z >  180 && transform.eulerAngles.z <= 360)
	        rb.AddTorque(rotSpeed * Time.deltaTime, ForceMode2D.Force);
        else if (transform.eulerAngles.z > 0 && transform.eulerAngles.z <= 180) 
            rb.AddTorque(-rotSpeed * Time.deltaTime, ForceMode2D.Force);
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
