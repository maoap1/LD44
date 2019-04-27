using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public Slider slider;
	public Image fill;
	public float initialValue = 10;
	public float Progress => currValue / initialValue;
	public float currValue { get; private set; }
	public Color DebugingColor;

	private byte maxColorValue => 255;
    // Start is called before the first frame update
    void Start()
    {
		currValue = initialValue;
    }

	
    // Update is called once per frame
    void Update()
    {
		DebugingColor = new Color(maxColorValue - Progress * maxColorValue, Progress * maxColorValue, 0);
		fill.color = DebugingColor;
		currValue -= Time.deltaTime;
		slider.value = Progress;
    }
}
