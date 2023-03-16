using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 5f;

    //Gun varibles
[SerializeField] private GameObject bulletPrefab;
[SerializeField] private Transform FiringPoint;
[Range(0.1f,2f)]
[SerializeField] public float fireRate = 0.5f;

    private Rigidbody2D rb;
    private float mx; //this is movement x
    private float my; //this is movement y

    private float fireTimer;
    
    private Vector2 mousePos; //Track Mouse movemnt

    void Start()
    {
     rb = GetComponent<Rigidbody2D>();
     
    }

    // Update is called once per frame to track mouse movement
    void Update()
    {
     mx = Input.GetAxisRaw("Horizontal");
     my = Input.GetAxisRaw("Vertical");
     mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

     float angle = Mathf.Atan2(mousePos.y -transform.position.y, mousePos.x - transform.position.x) * Mathf.Rad2Deg - 90f; //top of player is 'front' of player
     transform.localRotation = Quaternion.Euler (0,0,angle);

     if (Input.GetMouseButtonDown(0) && fireTimer <= 0f){

     Shoot();
     fireTimer = fireRate;

     } else { 
         
     fireTimer -= Time.deltaTime; 
     }

    }

    private void FixedUpdate()
    {

rb.velocity = new Vector2 (mx,my).normalized * speed; //when moving diagonally to not be too fast

    }

    private void Shoot() {

    Instantiate(bulletPrefab, FiringPoint.position,FiringPoint.rotation );

    }
}
