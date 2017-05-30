using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {
    bool isDestroyed = false;

    [SerializeField]
    public GameObject Ball;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isDestroyed == true)
        {
            Instantiate(Ball, new Vector3(-0.019f, -0.187f, 2.521f), Quaternion.identity);
            isDestroyed = false;
        }
	}
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        Destroy(other.gameObject);
        isDestroyed = true;
    }
}