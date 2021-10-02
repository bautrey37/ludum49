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
    [SerializeField] HUD hud;
    [SerializeField] Animator anim;


    bool controlsOn = true;
    float horizontal;
    float vertical;
    Controls currentControls;

    Rigidbody2D rb;

    void Start()
    {
        hud = FindObjectOfType<HUD>();
        rb = GetComponent<Rigidbody2D>();
        currentControls = Controls.Normal;
        InvokeRepeating("ChangeControls", 5, 10); // Call the switch controls function every 5 seconds
    }

	void Update()
	{
        GetControlsInput();
        eulerRot = transform.eulerAngles.z;
    }

	public void FixedUpdate()
    {
        if (controlsOn)
		{
            // Apply force to player rigidbody
            Vector2 force = moveSpeed * new Vector2(horizontal, vertical);
            rb.AddForce(force, ForceMode2D.Force);
        }
        
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
        //controlsText.text = currentControls.ToString().ToUpper();

        if (currentControls == Controls.Normal)
		{
            hud.SetControlsNormal();
        }
        
        else if (currentControls == Controls.Reversed)
        {
            hud.SetControlsReversed();
        }

    }

    public void FellInHole()
    {
        // TODO: play dying sound
        Debug.Log("Player has fell in hole");
        Events.EndLevel(false);
    }

    public IEnumerator Slipped()
	{
        controlsOn = false;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Fall");

        yield return new WaitForSeconds(2);
        anim.SetTrigger("Get Up");
        rb.bodyType = RigidbodyType2D.Dynamic;
        controlsOn = true;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
      
        anim.SetTrigger("Stagger");
	}



}
