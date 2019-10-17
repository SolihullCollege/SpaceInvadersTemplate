using UnityEngine;
using System.Collections;

public class shotScript : MonoBehaviour {

    public int speed=5;
    public int damage;
    public string target;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

	}

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == target)
        {
            if (other.tag == "Player")
            {
                gameManager.playerDead();
            }
            else
            {
                Score.updateScore();
            }
            
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
