﻿using UnityEngine;
using System.Collections;

public class ItemTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerTrigger"))
        {
            if (this.name == "Diamond") Score.addDia();
            else if (this.name == "Heart") Score.addHeart();
            Destroy(gameObject);
        }
    }
}
