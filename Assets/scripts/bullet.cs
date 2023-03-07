using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SelfDestruc();
    }

    public void SelfDestruc()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
            Destroy(this.gameObject);
        //Debug.Log("bibibibibibi" + this.gameObject.tag);
    }
    public void Movement(GameObject obj,Vector3 dir, float speed)
    {
        obj.transform.Translate((speed * Time.deltaTime * dir));

    }
}
