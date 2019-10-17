using UnityEngine;
using System.Collections;

public class shipControl : MonoBehaviour {

    public GameObject shot;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * 10, Input.GetAxis("Vertical") * 10);
        float posX= Mathf.Clamp(transform.position.x,-2.75f,2.75f);
        float posY = Mathf.Clamp(transform.position.y, -5f, 5f);
        transform.position = new Vector3(posX, posY, 0);

        if (Input.GetButtonDown("Fire1"))
        {            
            Instantiate(shot, transform.position, Quaternion.identity);
        }
	}
}
