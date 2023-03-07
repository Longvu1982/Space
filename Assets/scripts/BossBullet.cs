using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossBullet : bullet
{
    public float speed;
    private Vector3 initPos;
    public GameObject miniBulletPrefabs;
    private bool isSpread;
    // Start is called before the first frame update
    void Start()
    {
        isSpread = true;
        speed = 5f;
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement(this.gameObject, new Vector3(0, -1, 0), speed);
        SpreadBullet();
    }

    void SpreadBullet()
    {
        var n = 10;
        if (initPos.y - transform.position.y >= 2.5f)
        {
            if (isSpread)
            {
                for (int i = 0; i < n; i++)
                {
                    var minibullet = Instantiate(miniBulletPrefabs, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), transform.rotation);
                    //Debug.Log(CalculateVectorRotation(i));
                    //test.SetMiniBulletDir(CalculateVectorRotation(i),minibullet);
                    MiniBullet component = minibullet.GetComponent<MiniBullet>();
                    component.dir = CalculateVectorRotation(i * 360 / n);
                    var test = CalculateVectorRotation(i * 360 / n);
                    component.rotation = new Vector3(0, 0, -i * (360 / n));
                    Debug.Log(component.rotation);
                }
                Destroy(this.gameObject);
                isSpread = false;
            }

        }
    }

    Vector3 CalculateVectorRotation(float angle)
    {
        float x = Mathf.Sin(angle * Mathf.Deg2Rad);
        float y = Mathf.Cos(angle * Mathf.Deg2Rad);

        return new Vector3(x, y);
    }
}
