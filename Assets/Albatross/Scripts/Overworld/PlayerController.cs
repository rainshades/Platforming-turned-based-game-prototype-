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

        Player pete = null;
        PlayerActions action = null;
        Vector2 move = Vector2.zero;

        [SerializeField]
        GameObject optionsmenu = null;

        public float maxSpeed = 7;
        public float jumpTakeOffSpeed = 0.00001f;

        SpriteRenderer spriteRenderer = null;

        [SerializeField]
        Animator animator = null;

        bool action_augment_flag = false;


        Vector3 RespawnPoint = Vector3.zero;

        void Awake()
        {

            Camera cam = FindObjectOfType<Camera>();
            cam.transform.position =  new Vector3 (this.transform.position.x, this.transform.position.y, cam.transform.position.z);

            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

            action = new PlayerActions();

            action.InputsMap.Action.performed += ctx => AugmentAction(true);
            action.InputsMap.Action.canceled += ctx => AugmentAction(false);

            action.InputsMap.OptionsMenu.performed += ctx => optionsmenu.GetComponent<StarMenuUI>().SwitchMode();

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
            action.InputsMap.Jump.performed += ctx => animator.SetBool("Grounded", false);
            action.InputsMap.Jump.performed += ctx => velocity.y = jumpTakeOffSpeed;
            action.InputsMap.Jump.performed += ctx => animator.SetBool("Jump_flag", true);
            action.InputsMap.Jump.canceled += ctx => animator.SetBool("Jump_flag", false);
            //JumpBlock

        }
        
        protected override void ComputeVelocity()
        {
         
            action.InputsMap.Walk.performed += ctx => move.x = ctx.ReadValue<Vector2>().x;
            action.InputsMap.Walk.performed += ctx => animator.SetBool("Running", true);

            action.InputsMap.Walk.canceled += ctx => move = Vector2.zero;
            action.InputsMap.Walk.canceled += ctx => animator.SetBool("Running",false);

            animator.SetBool("Grounded", grounded);

            if (grounded)
            {
                Jump();
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
                action.InputsMap.Walk.performed += ctx => animator.speed *= 2.5f;
                action.InputsMap.Walk.canceled += ctx => move = Vector2.zero;

            }


            if (move.x < 0)
            {
                spriteRenderer.flipX = true;
            }else if(move.x > 0) { 
                spriteRenderer.flipX = false; 
            }

            targetVelocity = move * maxSpeed;
        }

        void OnTriggerEnter2D(UnityEngine.Collider2D col)
        {
            /*    if (col.gameObject.tag.Equals("NPC"))
                {
                    Flowchart fc = FindObjectOfType<Flowchart>();
                    if(fc == null)
                    {
                        GameObject go = new GameObject();
                        go.AddComponent<Flowchart>();
                        fc = go.GetComponent<Flowchart>();
                    }

                    Block nb = fc.CreateBlock(Vector2.zero);
                    Say dialog = col.GetComponent<Say>();
                    dialog.SetStandardText(col.GetComponent<NPC>().overworld_dialog);
                    nb.CommandList.Add(dialog);


                } NPC Flowchart innit and dialog spawner (likely not neccessary) TODO: DELETE
               */

            if (col.GetComponent<AreaTransition>())
            {
                col.GetComponent<AreaTransition>().text.SetText(col.GetComponent<AreaTransition>().AreaName);
            }
            if (col.gameObject.tag.Equals("DeathZone"))
            {
                pete.HumanHealth = 0;
            }
            if (col.gameObject.tag.Equals("RespawnPoint"))
            {
                RespawnPoint = col.gameObject.transform.position;
            }
            if (col.gameObject.tag.Equals("TransitionSpace"))
            {
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

        public Vector3 getRespawnPoint()
        {
            return RespawnPoint;
        }
    }
}