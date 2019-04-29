using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFadePicture : MonoBehaviour
{
	public GameObject picture;
    void Start() => new SceneManager(picture);
}
