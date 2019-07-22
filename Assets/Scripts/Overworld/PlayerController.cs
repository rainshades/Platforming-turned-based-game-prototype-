using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Eddie Fulton
/// Project Tinder 2018
/// As of (9/27/2018)
/// Main player controller
/// Lines 72-100:
/// Unity Scripting Collision
/// https://unity3d.com/learn/tutorials/topics/2d-game-creation/scripting-collision?playlist=17093
/// </summary>

public class PlayerController : PhysicsEnabler
{
    /*The Main Player Object
     Can Run, Jump by manipulating physics
     Uses a weapon to strike enemies
     Gets hurt when interacting with enemies or harmful Objects
     */

    public float runSpeed, jumpHeight; //Controllable that control phsyics
    private float height; //stores the height of the player
    private bool alive, runFlag, jumpFlag, dodgeFlag, crouchFlag;//Physic/Physical Checks, may not be used
    //The maximum amount of jumps a character has left
    public GameObject[] inv = new GameObject[1]; //The Inventory of Game objects
    [SerializeField]
    private Rigidbody2D cc;//The Character Controller object(Rigid Body)
    private int health = 10;//Amount of health for a character (as well as other int values)
    private int runKeyPress, jumpKeyPress,crouchKeyPress; //Keeps track of keyPresses
    private Collider2D collider2d;//The 2D collider
    private Animator ani;//Gets the animator
    private Vector2 gravity; //the effect of gravity
    private SpriteRenderer sr;//Objects Sprite Renderer

    /// <summary>
    /// Input Shortcuts
    /// h for Horizontal
    /// v for Verticle
    /// r for Run
    /// j for Jump
    /// A for Fire1
    /// </summary>
    
    private string a = "Fire1";//For attcking with the equiped weapon
    private string h = "Horizontal";//for running
    private string j = "Jump";//for jumping
    private string v = "Vertical";//use for climable objecs
    private string r = "Run";//use for dashing
    private string c = "Crouch";//use for crouching
    private string s = "Switch";//use for cycing through items

    // Use this for initialization
    void Awake()
    {
        //Get Skin
        //Get Sounds
        cc = transform.GetComponentInChildren<Rigidbody2D>();//Get Character Controller
        //Assigns the Rigidbody

        ani = transform.GetComponentInChildren<Animator>();//Gets the Animator
        //Assigns the Animator and animations

        collider2d = GetComponentInChildren<Collider2D>();
        sr = GetComponentInChildren<SpriteRenderer>();//Grabs Sprite Renderer

        //Get animation 
        if (health > 0)
        {
            alive = true;
        }//You're only Alive if you have enough health

        
    }

    protected override void Update()
    {
        base.Update();

        Swing();
        DodgeRoll();
        Crouch();
        Dash();

    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis(h);

        if (Input.GetButtonDown(j) && grounded)
        {
            velocity.y = jumpHeight;
        }
        
        else if (Input.GetButtonUp(j))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        //TODO: Fix. Flips in the wrong direction. 
        bool flipSprite = (sr.flipX ? (move.x > 0) : (move.x < 0));
        
        if (flipSprite)
        {
            sr.flipX = !sr.flipX;
        }

        ani.SetBool("grounded", grounded);
        ani.SetFloat("velocityX", Mathf.Abs(velocity.x) / runSpeed);

        if (!runFlag)
        {

            targetVelocity = move * runSpeed;
        }
        else
        {
            targetVelocity = move * (runSpeed + runSpeed);
        }
    }//Used for movement calculations and animation movement

    private void Swing()
    {
        //Attack animation
        if (Input.GetButtonDown(a))
        {
            Debug.Log("Hit it");
        }
    }/*Swings weapon doing damage based on weapon if contacted
    Does different things depending on what flag is active*/

    private void DodgeRoll()
    {
        //roll animation
        if (Input.GetButtonDown(c) && Input.GetButtonDown(r))
        {
            Debug.Log("Dodge to the [Insert Direction]");
        }
    }//Rolls on the ground in a given direction dependent on speed

    private void Crouch()
    {
        //Crouch animation
        if (Input.GetButton(c))
        {
            Debug.Log("GET DOWN!");
        }
    }//Crouches down and adds the Crouched Flag

    private bool Dash()
    {
        if (Input.GetButton(r))
        {
            return runFlag = true;
        }
        return runFlag = false;
    }//Doubles speed and adds the Dashing Flag
    
    public bool isAlive()
    {
        if (health > 0)
        {
            return alive = true;
        }
        else return alive = false;
    }//Returns whether or not the player is alive

    public bool isGrounded()
    {
        return Physics2D.IsTouchingLayers(collider2d, 9);
        //Checks to see if character is touching the ground
    }
    
    public void EquipmentSwap()
    {
        if (Input.GetButtonDown(s))
        {
            //bag.Cycle();
        }

    }//Swaps the equipped Weapon

    public int GetHealth()
    {
        return health;
    }//gets the character's health

}
