using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

namespace Albatross
{
    public class PlayerController : PhysicsObject
    {

        [SerializeField]
        Flowchart flow = null;

        PlayerControllerActionMap action = null;
        Vector2 move = Vector2.zero;

        [SerializeField]
        GameObject optionsmenu = null;

        public float MAXSPEEDVALUE = 7;
        public float maxSpeed;
        public float jumpTakeOffSpeed = 0.00001f;

        SpriteRenderer spriteRenderer = null;

        [SerializeField]
        Animator animator = null;

        bool action_augment_flag = false;
        Player player;

        Vector3 RespawnPoint = Vector3.zero;
        bool speaking = false;

        int Health;

        public bool canInteract = false;
        
        public IInteractables lastInteractable = null;
        void Awake()
        {
            maxSpeed = MAXSPEEDVALUE; 
            flow = FindObjectOfType<Flowchart>();

            player = FindObjectOfType<Player>();
            Health = player.HumanHealth;

            Camera cam = FindObjectOfType<Camera>();
            cam.transform.position =  new Vector3 (this.transform.position.x, this.transform.position.y, cam.transform.position.z);

            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            action = new PlayerControllerActionMap();

            action.WorldInteraction.Augment.performed += ctx => AugmentAction(true);
            action.WorldInteraction.Augment.canceled += ctx => AugmentAction(false);

            action.WorldInteraction.OptionsMenu.performed += ctx => optionsmenu.GetComponent<StarMenuUI>().SwitchMode();

            if (animator == null)
            {
                animator = GetComponentInChildren<Animator>();
            }
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

        protected void Jump()
        {
            action.WorldInteraction.Jump.performed += ctx => animator.SetBool("Grounded", false);
            action.WorldInteraction.Jump.performed += ctx => velocity.y = jumpTakeOffSpeed;
            action.WorldInteraction.Jump.performed += ctx => animator.SetBool("Jump_flag", true);
            action.WorldInteraction.Jump.canceled += ctx => animator.SetBool("Jump_flag", false);
            //JumpBlock

        }

        protected void Melee()
        {

        }

        protected void Ranged()
        {

        }
        
        protected override void ComputeVelocity()
        {
            speaking = flow.GetBooleanVariable("InConversation");

            if (speaking)
            {
                maxSpeed = 0;
            }
            else
            {
                maxSpeed = MAXSPEEDVALUE;
            }
            action.WorldInteraction.Movement.performed += ctx => move.x = ctx.ReadValue<Vector2>().x;
            action.WorldInteraction.Movement.performed += ctx => animator.SetBool("Running", true);

            action.WorldInteraction.Movement.canceled += ctx => move = Vector2.zero;
            action.WorldInteraction.Movement.canceled += ctx => animator.SetBool("Running",false);

            animator.SetBool("Grounded", grounded);

            if (grounded)
            {
                Jump();
            }

            else
            {
                action.WorldInteraction.Jump.performed += ctx => animator.SetBool("Grounded", false);
                action.WorldInteraction.Jump.performed += ctx => velocity.y = 0;
            }//Accedental flutter jump. KEEP IT
            
            if(action_augment_flag)
            {
                if (grounded)
                {
                    action.WorldInteraction.Jump.performed += ctx => velocity.y = jumpTakeOffSpeed * 1.5f;
                }//High Jump
                else
                {
                    action.WorldInteraction.Jump.performed += ctx => velocity.y = jumpTakeOffSpeed * -1;
                }//Quick Fall

                action.WorldInteraction.Movement.performed += ctx => move.x = ctx.ReadValue<Vector2>().x * 2.5f;//Sprint
                action.WorldInteraction.Movement.canceled += ctx => move = Vector2.zero;

            }


            if (move.x < 0)
            {
                spriteRenderer.flipX = true;
            }else if(move.x > 0) { 
                spriteRenderer.flipX = false; 
            }

            targetVelocity = move * maxSpeed;

            if (Health < 1)
            {
                Respawn();
            }

            if (canInteract)
            {
                action.WorldInteraction.Interact.performed += ctx => lastInteractable.Interact();
                canInteract = false;
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            string tag = col.gameObject.transform.tag;
            switch (tag)
            {
                case "DeathZone":
                    transform.position = RespawnPoint;
                    break;
                case "RespawnPoint":
                    RespawnPoint = col.gameObject.transform.position;
                    break;
                case "EnemyAnimal":
                    player.HumanHealth -= col.GetComponent<EnemyAnimal>().Health;
                    Health = player.HumanHealth;
                    break;
                case "Obsticle":
                    break;
                case "Bullet":
                    break;
                default:
                    break;
            }

            if (col.gameObject.CompareTag("Door"))
            {
                canInteract = true;
                lastInteractable =  col.GetComponent<IInteractables>();
            }

            if (col.gameObject.CompareTag("NPC"))
            {
                Debug.Log("NPC Tag");
                col.GetComponentInParent<NPC>().NPCInteraction(this);
            }

        }

        void OnEnable()
        {
            action.WorldInteraction.Enable();
            rb2d = GetComponent<Rigidbody2D>();
        }

        void OnDisable()
        {
            action.WorldInteraction.Disable();
        }

        void Respawn()
        {
            this.transform.position = RespawnPoint;
        }

        public Vector3 getRespawnPoint()
        {
            return RespawnPoint;
        }
    }
}