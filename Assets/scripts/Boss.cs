using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    public List<GameObject> posList = new List<GameObject>();
    public float speed;
    private int frameCount;
    private int randomIndex;
    public GameObject bullet;

    // Start is called before the first frame update
    [System.Obsolete]
    void Start()
    {
        speed = 4f;
        frameCount = 0;
        randomIndex = Random.RandomRange(0, posList.Count);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        frameCount++;

        if (frameCount % 80 == 0)
        {
            randomIndex = Random.RandomRange(0, posList.Count);

        }
        var target = posList.ElementAt(randomIndex).transform.position;
        RandomMove(target);
        if (frameCount % 200 == 0 && Time.timeScale != 0)
        {

            HandleShoot();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Debug.Log("hit");
        }
    }
    void RandomMove(Vector3 target)
    {
        float step = speed * Time.deltaTime;



        transform.position = Vector2.MoveTowards(transform.position, target, step);
    }

    void HandleShoot()
    {

        CreateBullet();

    }
    void CreateBullet()
    {
        GameObject instance = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);
        instance.AddComponent(typeof(bullet));
    }
}
