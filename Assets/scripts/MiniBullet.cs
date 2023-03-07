using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBullet : bullet
{
    public static float speed;
    public Vector3 dir;
    public Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        speed = 6.5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += ((speed * Time.deltaTime * dir));
        //var tmp = transform.position;
        //tmp.z = rotation.z;
        transform.eulerAngles = rotation;
        this.SelfDestruc();
    }
}
