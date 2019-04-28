using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMode : MonoBehaviour
{
	public static float radius = 2.5f;

    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
		float distance = Mathf.Sqrt(Mathf.Pow(transform.position.x - player.transform.position.x, 2)
			+ Mathf.Pow(transform.position.y - player.transform.position.y, 2));
		foreach (Transform child in transform)
			if (distance < radius)
				SetEnabled(child, false);
			else
				SetEnabled(child, true);
    }
	void SetEnabled(Transform child, bool shadowDisplayed)
	{
		if (child.tag == "Shadow")
		{
			child.GetComponent<SpriteRenderer>().enabled = shadowDisplayed;
		}
		else
		{
			child.GetComponent<SpriteRenderer>().enabled = !shadowDisplayed;
		}
	}
}
