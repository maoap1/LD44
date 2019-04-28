using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsClick : MonoBehaviour
{
	public void Quit() => Application.Quit();

	public void Start() => SceneManager.LoadScene("Malostranske");
}
