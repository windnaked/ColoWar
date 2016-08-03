using UnityEngine;
using System.Collections;

public class PlayerDamageHandler : MonoBehaviour {

    private float health;
    private float damage;

	// Use this for initialization
	void Start ()
    {
        health = gameObject.GetComponent<PlayerMove>().health;
        
	}

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");

        health = health - damage;
    }


    // Update is called once per frame
    void Update()
    {
        health = gameObject.GetComponent<PlayerMove>().health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
