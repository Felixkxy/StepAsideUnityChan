using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDestroyer : MonoBehaviour {

    private GameObject camera;

    // Use this for initialization
    void Start () {
        this.camera = GameObject.Find("Main Camera");		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.camera.transform.position.z > this.transform.position.z)
        {
            Destroy(this.gameObject);
        }            
	}
}
