using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour
{
    [SerializeField]
    float speed = 4;

    [SerializeField]
    GameObject boss;

    [SerializeField]
    bool carrying = false;

    [SerializeField]
    public Vector2 v = Vector2.down;

    private void Start()
    {
        v = v.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerScript>().Jump(carrying ? 15 : 7);
            if (carrying) SpawnBoss();
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("XWall"))
        {
            v = new Vector2(-v.x, v.y);
        }
        if (collision.gameObject.CompareTag("YWall"))
        {
            v = new Vector2(v.x, -v.y);
        }
    }

    public void RandomizeDirection()
    {
        v = rotate(v, Random.Range(0, 2 * Mathf.PI));
    }

    private void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(v.x, 0, v.y) * speed;
    }

    public static Vector2 rotate(Vector2 v, float delta)
    {
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }

    void SpawnBoss()
    {
        transform.parent.parent.GetComponent<Holder>().ClearHats();
        boss = Instantiate(boss, transform.parent.parent);
        boss.transform.position = new Vector3(transform.position.x, 1.5f, transform.position.z);
        boss.GetComponent<BossScript>().weak = true;
    }
}
