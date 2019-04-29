using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsClick : MonoBehaviour
{
	public void QuitButton() => Application.Quit();

    public void StartButton()
    {
        Destroy(MenuMusic.Instance.gameObject);
        SceneManager.LoadScene("Malostranske1");
    }
	public void LegendButton() => SceneManager.LoadScene("LegendScene");
}
