using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// From Unity Scripting Collision
/// https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-collision?playlist=17093
/// A script for "2D graphics"
/// As of (9/27/2018)
/// </summary>


public class PhysicsEnabler : MonoBehaviour
{

    public float minGroundNormalY = .65f;
    public float gravityModifier = 1f; //Scales the gravity

    protected Vector2 targetVelocity;
    protected bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity; 
    protected ContactFilter2D contactFilter; 
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D>(16);


    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    //Called when GameObject is enabled
    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();//gets access to the rigidbody2D
    }

    //Called on the start frame
    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    //Called every update frame
    protected virtual void Update()
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity();
    }
    
    protected virtual void ComputeVelocity()
    {
        //changes in volicty is handled by the child class. 
    }

    //Called for every phyics frame
    void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime; //sets the velocity
        velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime; //The change in position of the object

        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;//Allows for movement on the x axis

        Movement(move, false);

        move = Vector2.up * deltaPosition.y;//Allows for movement on the y axis

        Movement(move, true);
    }

    void Movement(Vector2 move, bool yMovement)
    {
        float distance = move.magnitude;//stores the magnitude of the move

        if (distance > minMoveDistance)
        {
            int count = rb2d.Cast(move, contactFilter, hitBuffer, distance + shellRadius); 
            hitBufferList.Clear(); //Clears the hitBuffer after each movement

            for (int i = 0; i < count; i++)
            {
                hitBufferList.Add(hitBuffer[i]);
            }//adds to array to recieve hits for next movement

            for (int i = 0; i < hitBufferList.Count; i++)
            {
                Vector2 currentNormal = hitBufferList[i].normal;
                if (currentNormal.y > minGroundNormalY)
                {
                    grounded = true;
                    if (yMovement)
                    {
                        groundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                float projection = Vector2.Dot(velocity, currentNormal); //The dotproduct of 2 vectors
                if (projection < 0)
                {
                    velocity = velocity - projection * currentNormal;
                }//

                float modifiedDistance = hitBufferList[i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }


        }//Checks for collision

        rb2d.position = rb2d.position + move.normalized * distance; 
    }//Moves the object using a rigidbody2D

}