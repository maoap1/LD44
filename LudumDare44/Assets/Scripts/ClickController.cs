using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickController : MonoBehaviour
{
    public float hoverScale = 1.1f;
    public float clickScale = 1.2f;

    private Vector3 normalScaleVector;
    private Vector3 hoverScaleVector;
    private Vector3 clickScaleVector;

    //private AudioSource audioSource;

    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
        normalScaleVector = transform.localScale;
        hoverScaleVector = new Vector3(normalScaleVector.x * hoverScale, normalScaleVector.y * hoverScale, normalScaleVector.z);
        clickScaleVector = new Vector3(normalScaleVector.x * clickScale, normalScaleVector.y * clickScale, normalScaleVector.z);
    }

    void OnMouseEnter()
    {
        transform.localScale = hoverScaleVector;
    }

    void OnMouseExit()
    {
        transform.localScale = normalScaleVector;
    }

    void OnMouseDown()
    {
        transform.localScale = clickScaleVector;
        //audioSource.Play();
    }

    void OnMouseUpAsButton()
    {
        transform.localScale = hoverScaleVector;
    }
}
