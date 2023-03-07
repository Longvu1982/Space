using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 6f;
    public GameObject bullet;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        HandleShoot();
    }
    void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        transform.position += (speed * Time.deltaTime * new Vector3(h, v, 0));
    }

    void HandleShoot()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            CreateBullet();
        }

    }

    void CreateBullet()
    {
       GameObject instance = Instantiate(bullet, transform.position, Quaternion.identity);
        instance.AddComponent(typeof(bullet));
    }
}