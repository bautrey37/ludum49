using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] Text[] HUDDirections = new Text[4];
    [SerializeField] Animator anim;

    public void SetControlsNormal()
	{
        HUDDirections[0].text = "W";
        HUDDirections[1].text = "A";
        HUDDirections[2].text = "S";
        HUDDirections[3].text = "D";
        PlayAnimation();
    }

    public void SetControlsReversed()
	{
        HUDDirections[0].text = "S";
        HUDDirections[1].text = "D";
        HUDDirections[2].text = "W";
        HUDDirections[3].text = "A";
        PlayAnimation();
    }

    void PlayAnimation()
	{
        anim.SetTrigger("PlayIndicator");
        
	}
}
