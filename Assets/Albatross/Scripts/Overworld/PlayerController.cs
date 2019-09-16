using UnityEngine;
using Fungus;
using UnityEngine.InputSystem;

namespace Albatross
{
    public class PlayerController : PhysicsObject
    {

        [SerializeField]
        Flowchart flow;

        Player pete;
        PlayerActions action;
        Vector2 move;

        [SerializeField]
        GameObject optionsmenu;

        public float maxSpeed = 7;
        public float jumpTakeOffSpeed = 0.00001f;

        SpriteRenderer spriteRenderer;
        Animator animator;

        void Awake()
        {

            action = new PlayerActions();

            action.InputsMap.Walk.performed += ctx => move.x = ctx.ReadValue<Vector2>().x;
            action.InputsMap.Walk.canceled += ctx => move = Vector2.zero;

            action.InputsMap.OptionsMenu.performed += ctx => optionsmenu.GetComponent<StarMenuUI>().SwitchMode();
        }

        protected override void ComputeVelocity()
        {
            if (grounded)
            {
                action.InputsMap.Jump.performed += ctx => velocity.y = jumpTakeOffSpeed;
            }
            else
            {
                action.InputsMap.Jump.performed += ctx => velocity.y = 0;
            }//Accedental flutter jump. KEEP IT


            targetVelocity = move * maxSpeed;
        }
        void OnCollisionEnter2D(UnityEngine.Collision2D col)
        {
            if (col.gameObject.tag == "NPC")
            {
                flow.ExecuteBlock("SayBlock2");
            }

            if (col.gameObject.tag == "EnemyNPC")
            {
                flow.ExecuteBlock("BattleStarter");
            }
        }

        void OnTriggerEnter2D(Collider2D trigger)
        {
            if (trigger.gameObject.tag == "SayStarter")
            {
                flow.ExecuteBlock("SayBlock");
            }
        }
        void OnEnable()
        {
            action.InputsMap.Enable();
            rb2d = GetComponent<Rigidbody2D>();
        }

        void OnDisable()
        {
            action.InputsMap.Disable();
        }
    }
}