using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    private static EnemyManager _instance;
    public static EnemyManager Instance
    {
        get
        {
            if (!_instance)
            {
                GameObject container = new GameObject("EnemyManager");
                _instance = container.AddComponent(typeof(EnemyManager)) as EnemyManager;
                
            }

            return _instance;
        }
    }
    

	// Use this for initialization
	void Awake() {
		_instance = this;
        DontDestroyOnLoad(_instance);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
