using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Different controls settings. Now only has two but we may add more.
    enum Controls { Normal, Reversed, AxSwapped }

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotSpeed = 0.05f;
    [SerializeField] float eulerRot;
    [SerializeField] HUD hud;
    [SerializeField] Animator anim;

    public AudioClipGroup AudioNotification;
    public AudioClipGroup AudioBottle;
    public AudioClipGroup AudioSlip;
    public AudioClipGroup AudioBump;

    bool controlsOn = true;
    float horizontal;
    float vertical;
    int controlsIndex = 0;
    Controls currentControls;
    bool isDead = false;
    bool playerCanMove = false;

    Rigidbody2D rb;

    void Start()
    {
        hud = FindObjectOfType<HUD>();
        rb = GetComponent<Rigidbody2D>();
        currentControls = Controls.Normal;
        InvokeRepeating("ChangeControls", 3, 5); // Call the switch controls function every 5 seconds
    }

	void Update()
	{
        if (playerCanMove)
        {
            GetControlsInput();
            eulerRot = transform.eulerAngles.z;
            float animSpeed = Mathf.Clamp(rb.velocity.magnitude, 0.3f, 1.5f);
            anim.SetFloat("WalkSpeed", animSpeed);
            anim.SetFloat("SideSpeed", rb.velocity.x);
            anim.speed = animSpeed;
        }
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

        else if (currentControls == Controls.AxSwapped)
		{
            horizontal = Input.GetAxis("Vertical");
            vertical = -Input.GetAxis("Horizontal");
        }
	}

    // Switch up the controls for extra fun :)
    void ChangeControls()
	{
        int choice = 0;
        do
        {
            choice = Random.Range(0, Controls.GetValues(typeof(Controls)).Length);

        } while (choice == controlsIndex);

        controlsIndex = choice;
        currentControls = (Controls)choice;

        if (currentControls == Controls.Normal)
		{
            hud.SetControlsNormal();
        }

        else if (currentControls == Controls.Reversed)
        {
            hud.SetControlsReversed();
        }

        else if (currentControls == Controls.AxSwapped)
		{
            hud.SetControlsAxSwapped();
		}
        AudioNotification.Play();
    }

    public void PlayerCanMove()
    {
        playerCanMove = true;
    }

    public void FellInHole()
    {
        Debug.Log("Fell in hole");
        if (isDead == false)
        {
            Events.IsPlayerPlaying(false); // stops backgrouns audio
            StartCoroutine("Died");
        }
        isDead = true;
    }

    public IEnumerator Slipped()
	{
        controlsOn = false;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Fall");
        AudioSlip.Play();
        yield return new WaitForSeconds(0.5f);
        AudioBottle.Play();
        yield return new WaitForSeconds(1.5f);

        anim.SetTrigger("Get Up");
        rb.bodyType = RigidbodyType2D.Dynamic;
        controlsOn = true;
	}

    public IEnumerator Died()
    {
        controlsOn = false;
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Fall");
        AudioSlip.Play();
        yield return new WaitForSeconds(0.5f);
        AudioBottle.Play();
        yield return new WaitForSeconds(1.5f);

        Debug.Log("Player Died");
        Events.EndLevel(false);
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        anim.SetTrigger("Stagger");
        AudioBump.Play();
	}

    public void GoHome()
    {
        Events.EndLevel(true);
    }

}
