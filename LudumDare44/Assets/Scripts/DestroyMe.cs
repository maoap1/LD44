using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestroyMe : MonoBehaviour
{
    public AudioSource audioSource;

    bool used = false;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //audioSource.Play();

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
            Activate();
		}
	}
}





