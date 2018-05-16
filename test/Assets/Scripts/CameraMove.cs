using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public GameObject playerCharacter;
    private Transform cameraTran;
    float height = 4f;
    float width = 7f;
	// Use this for initialization
	void Awake () {
        cameraTran = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        cameraTran.position = playerCharacter.transform.position + Vector3.up * height + Vector3.back * width;
	}
}
