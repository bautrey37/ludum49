using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] Text[] HUDDirections = new Text[4];
    [SerializeField] Animator anim;

    float targetAngle = 0f;

	private void Update()
	{
        float ang = Mathf.LerpAngle(transform.localEulerAngles.z, targetAngle, 0.05f);

        transform.localEulerAngles = new Vector3(0, 0, ang);

        foreach(Text text in HUDDirections)
		{
            text.transform.eulerAngles = new Vector3(0, 0, 0);
		}
	}

	public void SetControlsNormal()
	{
        targetAngle = 0f;
    }

    public void SetControlsReversed()
	{
        targetAngle = 180f;
    }

    public void SetControlsAxSwapped()
	{
        targetAngle = -90f;
    }
}
