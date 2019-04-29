using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class SceneManager : MonoBehaviour
{
	public SceneManager(GameObject fadingPicture) => FadingPicture = fadingPicture;
	private SceneManager(string sceneName)
	{
		this.sceneName = sceneName;
		value = startValue;
	}
	protected SceneManager() : this("") { }
	static GameObject FadingPicture;

	string sceneName;
	protected virtual bool HasSceneName => true;
	protected virtual float startValue => 0;
	protected float value;
	protected virtual float endvalue => 1;
	protected virtual bool Check() => value < endvalue;
	protected static float fadingTime = 1;
	private static float lastFadeTime = 0;

	private bool used = false;

	public static void LoadScene(string SceneName) => Fade<SceneManager>(SceneName);

	static void Fade<T>(string SceneName) where T : SceneManager
	{ 
		if (lastFadeTime < Time.timeSinceLevelLoad - fadingTime)
		{
			lastFadeTime = Time.timeSinceLevelLoad;
			GameObject picture = Instantiate(FadingPicture, GameObject.Find("Canvas").transform);
			picture.AddComponent<T>();
			picture.GetComponent<T>().SetScene(SceneName);
		}
	}

	public void SetScene(string sceneName) => this.sceneName = sceneName;

	float startTime;

	public static void FadeIn() => Fade<SceneManageFadeIn>("");

	private void Awake()
	{
		if (used)
			Destroy(gameObject);
		else
			used = true;
	}

	private void Update()
	{
		value += (Time.deltaTime / fadingTime) * (endvalue - startValue);
		GetComponent<Image>().color = new Color(
			GetComponent<Image>().color.r,
			GetComponent<Image>().color.g,
			GetComponent<Image>().color.b,
			value);
		if (!Check())
		{
			if (HasSceneName)
				UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
		}
	}
}

class SceneManageFadeIn : SceneManager
{
	protected override bool HasSceneName => false;
	protected override float startValue => 1;
	protected override bool Check() => value > endvalue;
	protected override float endvalue => 0;
}