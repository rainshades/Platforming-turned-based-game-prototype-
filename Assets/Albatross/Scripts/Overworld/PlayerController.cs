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

        [SerializeField]
        Animator animator;

        bool action_augment_flag = false;

        void Awake()
        {

            action = new PlayerActions();

            action.InputsMap.Action.performed += ctx => AugmentAction(true);
            action.InputsMap.Action.canceled += ctx => AugmentAction(false);

            action.InputsMap.OptionsMenu.performed += ctx => optionsmenu.GetComponent<StarMenuUI>().SwitchMode();

            animator = GetComponentInChildren<Animator>();
        }

        private void AugmentAction(bool b)
        {
            if (b)
            {
                action_augment_flag = true;
                animator.SetBool("action_augment_flag", true);
                Debug.Log("Action Augment Flag is on");
            }
            else
            {
                action_augment_flag = false;
                animator.SetBool("action_augment_flag", false);
                Debug.Log("Action Augement Flag is off");
            }
        }

        protected override void ComputeVelocity()
        {
         
            action.InputsMap.Walk.performed += ctx => move.x = ctx.ReadValue<Vector2>().x;

            action.InputsMap.Walk.canceled += ctx => move = Vector2.zero;

            if (grounded)
            {
                action.InputsMap.Jump.performed += ctx => animator.SetBool("Grounded", true);
                action.InputsMap.Jump.performed += ctx => velocity.y = jumpTakeOffSpeed;
                action.InputsMap.Jump.performed += ctx => animator.SetTrigger("Jump_flag");
            }
            else
            {
                action.InputsMap.Jump.performed += ctx => animator.SetBool("Grounded", false);
                action.InputsMap.Jump.performed += ctx => velocity.y = 0;
            }//Accedental flutter jump. KEEP IT
            
            if(action_augment_flag)
            {
                if (grounded)
                {
                    action.InputsMap.Jump.performed += ctx => velocity.y = jumpTakeOffSpeed * 1.5f;
                }//High Jump
                else
                {
                    action.InputsMap.Jump.performed += ctx => velocity.y = jumpTakeOffSpeed * -1;
                }//Quick Fall

                action.InputsMap.Walk.performed += ctx => move.x = ctx.ReadValue<Vector2>().x * 2.5f;//Sprint
                action.InputsMap.Walk.canceled += ctx => move = Vector2.zero;

            }

            targetVelocity = move * maxSpeed;
        }

        void OnCollisionEnter2D(UnityEngine.Collision2D col)
        {
            if (col.gameObject.tag == "EnemyNPC")
            {
                flow.ExecuteBlock("BattleStarter");
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