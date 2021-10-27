using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    private Vector3 velocity = Vector3.zero;
    public float VitesseBase;
    public float VitesseSprint;
    public bool sprint=false;

    

    // Update is called once per frame
    public void FixedUpdate()
      {
            //code pour le sprint
            if (Input.GetKey(KeyCode.LeftControl))
            {
                speed = VitesseSprint;
                sprint = true;
            }
            else
            {
                speed = VitesseBase;
                sprint = false;
            }

            //code pour le deplacement
            float horizontalInput = Input.GetAxisRaw("Horizontal") * speed * Time.fixedDeltaTime;
            Vector3 targetVelocity = new Vector2(horizontalInput, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            float verticalInput = Input.GetAxisRaw("Vertical") * speed * Time.fixedDeltaTime;
            Vector3 targetVelocity2 = new Vector2(rb.velocity.x, verticalInput);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity2, ref velocity, .05f);

       }
 }
