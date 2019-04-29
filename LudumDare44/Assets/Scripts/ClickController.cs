using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickController : MonoBehaviour
{
    public float hoverScale = 1.1f;
    public float clickScale = 1.2f;
	public string sceneToShow = null;

    private Vector3 normalScaleVector;
    private Vector3 hoverScaleVector;
    private Vector3 clickScaleVector;

    public AudioClip mouseEnterSound;
    public int id;

    private GameObject audioPlayer;

    void Start()
    {
        if (mouseEnterSound != null)
        {
            audioPlayer = GameObject.Find("AudioPlayer");
            id = audioPlayer.GetComponent<MalostranskeController>().RegisterNPCClip(mouseEnterSound);
        }

        normalScaleVector = transform.localScale;
        hoverScaleVector = new Vector3(normalScaleVector.x * hoverScale, normalScaleVector.y * hoverScale, normalScaleVector.z);
        clickScaleVector = new Vector3(normalScaleVector.x * clickScale, normalScaleVector.y * clickScale, normalScaleVector.z);
    }

    void OnMouseEnter()
    {

        if (mouseEnterSound != null)
        {
            PlaySound(mouseEnterSound);
        }

        transform.localScale = hoverScaleVector;
    }

    void OnMouseExit()
    {
        transform.localScale = normalScaleVector;
    }

    void OnMouseDown()
    {
        transform.localScale = clickScaleVector;
		if (sceneToShow != "")
			SceneManager.LoadScene(sceneToShow);
    }

    void OnMouseUpAsButton()
    {
        transform.localScale = hoverScaleVector;
    }

    /// <summary>
    /// This is the best point for changes with audio
    /// </summary>
    /// <param name="clip"></param>
    void PlaySound(AudioClip clip)
    {
        audioPlayer.GetComponent<MalostranskeController>().PlayNPC(id);
    }
}
