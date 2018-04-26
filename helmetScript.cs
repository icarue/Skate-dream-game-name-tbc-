using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmetScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collision collisionInfo)
    {

        Debug.Log("dead2");
        Time.timeScale = 0;
    }
    
}
