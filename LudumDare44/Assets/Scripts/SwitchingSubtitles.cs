using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SwitchingSubtitles : MonoBehaviour
{
    public TextMeshProUGUI SubOn;
    public TextMeshProUGUI SubOff;

    private void Start()
    {
        SubOn = GameObject.Find("EnglishSubtitlesON").GetComponent<TextMeshProUGUI>();
        SubOff = GameObject.Find("EnglishSubtitlesOFF").GetComponent<TextMeshProUGUI>();
        SubOn.enabled = Subtitles.Enabled;
        SubOff.enabled = !Subtitles.Enabled;
    }
    private void OnMouseDown()
    {
        if (SubOn.enabled == true)
        {
            SubOn.enabled = false;
            SubOff.enabled = true;
            Subtitles.Enabled = false;
        }
        else
        {
            SubOff.enabled = false;
            SubOn.enabled = true;
            Subtitles.Enabled = true;
        }
    }
}
