using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitlesScript : MonoBehaviour
{
    TextMeshProUGUI subtitles;
    AudioSource audioSource;

    void Start()
    {
        subtitles = GetComponent<TextMeshProUGUI>();
        audioSource = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource != null)
        {
            if (!audioSource.isPlaying)
            {
                subtitles.text = "";
            }
        }
    }

    public void Show(string text, AudioSource audio)
    {
        if (Subtitles.Enabled)
        {
            subtitles.text = text;
        }
        audioSource = audio;
    }
}
