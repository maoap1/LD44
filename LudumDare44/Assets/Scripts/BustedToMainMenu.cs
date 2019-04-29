using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class BustedToMainMenu : MonoBehaviour
{
	public bool resetValues = true;
    // Update is called once per frame
    void Update()
    {
		if (Input.anyKeyDown)
		{
			if (resetValues)
			{
				for (int i = 0; i < Enum.GetValues(typeof(MoneyType)).Length; i++)
				{
					CoinsAmmountDisplay.dictionary[(MoneyType)i] = 0;
				}
			}
			SceneManager.LoadScene("MainMenu");
		}
    }
}
