using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	public Slider slider;
	public Image fill;
	public float initialValue = 10;
	public float Progress => currValue / initialValue;
	public float currValue { get; private set; }
	public Color DebugingColor;

	private float maxColorValue => 1;
    // Start is called before the first frame update
    void Start()
    {
		currValue = initialValue;
    }

    // Update is called once per frame
    void Update()
    {
		if (Progress > maxColorValue / 2)
			DebugingColor = new Color(2 * (maxColorValue - Progress), maxColorValue, 0);
		else
		{
			DebugingColor = new Color(maxColorValue, 2 * Progress, 0);
			if(Progress <= 0)
				SceneManager.LoadScene("GameOver");
		}
		fill.GetComponent<Image>().color = DebugingColor;
        currValue -= Time.deltaTime;
		slider.value = Progress;
    }
}
