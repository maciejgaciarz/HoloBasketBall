using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {
    int Points;
    public GameObject Text;
	// Use this for initialization
	void Start () {
        Points = 0;
        Text.GetComponent<TextMesh>().text = "Punkty : " + Points;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        Points++;
        Text.GetComponent<TextMesh>().text = "Punkty : " + Points;
    }
}
