using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Char2DCont : MonoBehaviour
{

    

    public float MovementSpeed = 1f;
    private Rigidbody2D cuerporigido;
    public float JumpForce = 1; 
    public Animator anime;

    // Start is called before the first frame update
    private void Start()
    {
        cuerporigido = GetComponent<Rigidbody2D>();
       


    }

    // Update is called once per frame
    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        anime.SetFloat("Speed", Mathf.Abs(movement));

        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed;

        if (!Mathf.Approximately(0, movement))
        {
            transform.rotation = movement < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

        if (Input.GetButtonDown("Jump") && Mathf.Abs(cuerporigido.velocity.y * MovementSpeed) < 0.001f)
        {
            
            cuerporigido.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            anime.SetBool("IsJumping", true);
        }

        if (cuerporigido.velocity.y == 0)
        {

            anime.SetBool("IsJumping", false);
        }

        
    }

   
}
