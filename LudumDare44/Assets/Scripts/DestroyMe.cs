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
	protected abstract void Activate();
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





