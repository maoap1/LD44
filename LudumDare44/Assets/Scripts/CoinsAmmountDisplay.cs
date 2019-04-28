using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class CoinsAmmountDisplay : MonoBehaviour
{
	public MoneyType MoneyType;
	static CoinsAmmountDisplay()
	{
		for(int i = 0; i < Enum.GetValues(typeof(MoneyType)).Length; i++)
		{
			dictionary.Add((MoneyType)i, 0);
		}
	}
	public static Dictionary<MoneyType,int> dictionary = new Dictionary<MoneyType,int>();
	public void Update()
	{
		foreach(Transform child in transform)
		{
			if (child.tag == "Text")
			{
				child.GetComponent<TextMeshProUGUI>().text = dictionary[MoneyType].ToString();
			}
		}
	}
	public static bool isWinGame
	{
		get
		{
			foreach (int ammount in dictionary.Values)
				if (ammount < 1)
					return false;
			return true;
		}
	}
}
