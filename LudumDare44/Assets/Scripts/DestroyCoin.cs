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
	protected override void Activate()
	{

		Destroy(gameObject);
	}
}
