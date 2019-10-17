using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour {
    public float timeBetweenShots;
    public float nextShot = -1;
    public GameObject bullet;
    bool canFire;

	// Use this for initialization
	void Start () {
        nextShot = Random.Range(1, 4.0f);
        timeBetweenShots = 4;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextShot)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextShot = Time.time + timeBetweenShots;
        }
	}
}
