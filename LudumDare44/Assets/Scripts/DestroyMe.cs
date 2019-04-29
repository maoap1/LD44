using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class DestroyMe : MonoBehaviour
{
    public AudioSource audioSource; 
    public string translation;
    bool used = false;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public virtual int SleepTime { get; protected set; }
	protected virtual void Activate()
	{
		GetComponent<Collider2D>().enabled = false;
		GetComponent<ShadowMode>().enabled = false;
		foreach (Transform child in transform)
		{
			child.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	public void RunAndPlaySound()
    {
		if (!used)
		{
			used = true;
            audioSource.Play();
            GameObject.Find("Subtitles").GetComponent<SubtitlesScript>().Show(translation, audioSource);
            Activate();
		}
	}
}





