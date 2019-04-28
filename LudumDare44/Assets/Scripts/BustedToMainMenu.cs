using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BustedToMainMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Flee"))
			SceneManager.LoadScene("MainMenu");
    }
}
