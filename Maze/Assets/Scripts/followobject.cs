using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followobject : MonoBehaviour {
    public Transform t;
	
	// Update is called once per frame
	void Update () {
        transform.position = t.transform.position;
        transform.rotation = t.transform.rotation;
	}
}
