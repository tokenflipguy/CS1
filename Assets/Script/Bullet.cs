using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

[Range(0,10)]
[SerializeField]public float speed = 10f; //Bullet speed
[Range(0,10)]
[SerializeField]public float lifeTime = 3f; //Bullet lifetime
private Rigidbody2D rb;


    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject,lifeTime); 
    }

    // Update is called once per frame
    private void  FixedUpdate()
    {
     rb.velocity = transform.up * speed;
    }
}
