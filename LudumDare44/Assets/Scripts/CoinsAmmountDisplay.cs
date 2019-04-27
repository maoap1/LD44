using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

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
		dictionary[MoneyType].ToString();
	}
}
