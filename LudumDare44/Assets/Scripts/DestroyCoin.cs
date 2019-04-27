using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCoin : DestroyMe
{
	public MoneyType myType;
	DestroyCoin()
	{
		SleepTime = 0;
	}
	public override void Run()
	{

		Destroy(gameObject);
	}
}
