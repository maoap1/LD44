using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MalostranskeController : MonoBehaviour
{
    public List<AudioClip> NPCList = new List<AudioClip>();
    public AudioClip[] bystander;
    public AudioClip silence;
    public AudioSource source;
    public float newClip = 0.0f;
    public float timer = 0.0f;

    private AudioClip playing;
    private int NPCsIndex = 0;
    private bool NPCIsSpeaking;
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.PlayOneShot(silence);
        NPCIsSpeaking = false;
    }
    void Update()
    {
        if (NPCIsSpeaking)
        {
            if (!source.isPlaying)
            {
                NPCIsSpeaking = false;
                playing = silence;
                source.PlayOneShot(playing);
            }
        }
        else
        {
            MakeNewClip();
        }
    }

    void MakeNewClip()
    {
        if (!source.isPlaying)
        {
            if (playing == silence)
            {
                playing = bystander[Random.Range(0, bystander.Length)];
            }
            else
            {
                playing = silence;
            }
            source.PlayOneShot(playing);
        }
    }

    public void PlayNPC(int id)
    {
        if (!NPCIsSpeaking)
        {
            NPCIsSpeaking = true;
            source.Stop();
            source.PlayOneShot(NPCList[id]);
        }
    }

    public int RegisterNPCClip(AudioClip clip)
    {
        NPCList.Add(clip);
        return NPCsIndex++;
    }
}
