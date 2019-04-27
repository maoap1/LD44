using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestroyMe : MonoBehaviour
{
	public virtual int SleepTime { get; protected set; }
	public abstract void Run();
}
