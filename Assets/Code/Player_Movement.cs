using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewBehaviourScript : MonoBehaviour
{
    //prefab projectile
    public GameObject bulletPrefab;

    //bullet Spawn here
    public Transform bulletSpawnPoint;

    //speed of bullet
    public float bulletSpeed;


    //Speed
    public float moveSpeed;

    //RigidBody
    public Rigidbody2D rigidBody;
    private Vector2 movementInput;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.velocity = transform.up * bulletSpeed;
        }
    }
 
    private void FixedUpdate()
    {
        //makes out player move
        rigidBody.velocity = movementInput * moveSpeed;
    }

    private void OnMove(InputValue inputValue)
    {
        //WASD = vector 2 nvalues
        movementInput = inputValue.Get<Vector2>();
    }
}
