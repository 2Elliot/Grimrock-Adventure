using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saveObject : MonoBehaviour
{

	private void Start()
	{
		DontDestroyOnLoad(gameObject);
	}

}
