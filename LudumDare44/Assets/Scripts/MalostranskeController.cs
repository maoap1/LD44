using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalostranskeController : MonoBehaviour
{

    public AudioClip[] clips;
    public AudioSource source;
    public float newClip;
    public float timer;
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= newClip + 1)
        {
            MakeNewClip();
            timer = 0;
        }
    }

    void MakeNewClip()
    {
        int clipNum = Random.Range(0, clips.Length);
        if (!source.isPlaying)
        {
            source.loop = true;
            source.PlayOneShot(clips[clipNum]);
        }
        newClip = clips[clipNum].length;
    }
}
