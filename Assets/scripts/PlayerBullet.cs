using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : bullet
{
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        this.Movement(this.gameObject, new Vector3(0, 1, 0), speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("boss"))
        {
            Debug.Log("hit");
            Destroy(this.gameObject);
        }
    }
}
