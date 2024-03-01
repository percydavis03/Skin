using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInputActions playerControls;
    private InputAction move;
    private InputAction look;
    private InputAction fire;
    private InputAction lit;
    private InputAction block;
    private InputAction attack;
    private InputAction noise;

    private Vector3 moveDirection;
    private Vector2 movement;
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float gravity = -9.8f;
    public float speed = 5;
    private bool isGrounded;
    public float jumpHeight = 3f;
    

    private PlayerLook looking;

    private bool isLit;
    public GameObject flash_light;
    public GameObject light_light;
    public GameObject light_collider;
    public AudioSource lightswitch;
    public bool lightAllowed;
    public GameObject light_Off;
    private bool hasFlashlight;
    [SerializeField] float secondsBetweenFlickers = 0.01f;
    public GameObject clickingsound;

    public AudioSource footstep;
    public GameObject walkAudio;
    private bool isWalking;

    public GameObject theBat;
    public GameObject attackBat;
    private bool gotBat;

    public GameObject thecaveSound;
    private bool caveAllowed;

    public GameObject cage;

    private void Awake() //Gets called as the game is loading
    {
        playerControls = new PlayerInputActions();
        looking = GetComponent<PlayerLook>();
        isLit = false;
        isWalking = false;
        gotBat = false;
        lightAllowed = true;
        light_collider.SetActive(false);
        clickingsound.SetActive(false);
    }

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        transform.position = Vector3.zero;
    }

    private void OnEnable() //Must be used for the new input system to work properly
    {
        move = playerControls.Player.Move;
        move.Enable();

        look = playerControls.Player.Look;
        look.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();

        lit = playerControls.Player.Lit;
        lit.Enable();

        block = playerControls.Player.Block;
        block.Enable();

        attack = playerControls.Player.Attack;
        attack.Enable();  
        
        noise = playerControls.Player.Noise;
        noise.Enable();
    }

    private void OnDisable() //Must be used for the new input system to work properly
    {
        move.Disable();
        look.Disable();
        fire.Disable();
        lit.Disable();
        block.Disable();
        attack.Disable();
        noise.Disable();
    }

    private void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        if(hasFlashlight == true)
        {
            transform.gameObject.tag = "PlayerwithFlashlight";
        }
    }

    private void LateUpdate()
     {
         looking.ProcessLook(look.ReadValue<Vector2>());

        if (lit.WasPressedThisFrame())
        {
           isLit = true;
            clickingsound.SetActive(true);
           flashlight();
        }
        if (!lit.IsPressed())
        {
            isLit = false;
            clickingsound.SetActive(false);
            flashlight();
        }
        if (block.IsPressed() && gotBat == true)
        {
            theBat.SetActive(true);
        }
        if (!block.IsPressed())
        {
            theBat.SetActive(false);
        }
        if (move.WasPressedThisFrame())
        {
            isWalking = true;
            Footsteps();
        }
        if (!move.IsPressed())
        {
            walkAudio.SetActive(false);
        }
        if(noise.IsPressed())
        {
            caveAllowed = true;
            caveSound();
        }
        if (attack.WasPressedThisFrame())
        {
           Attacking();
        }
    }

   

    void FixedUpdate()
    {
        movement = move.ReadValue<Vector2>();
        moveDirection = Vector3.zero;
        moveDirection.x = movement.x;
        moveDirection.z = movement.y;

        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    //ENTER

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("flashlight"))
        {
            flash_light.SetActive(true); 
            hasFlashlight = true;
        }

        if (other.gameObject.CompareTag("bat"))
        {
            theBat.SetActive(true);
            gotBat = true;
        }

        if (other.gameObject.CompareTag("freak"))
        {
            
            print("hotsauce");
        }
        if (other.gameObject.CompareTag("exit"))
        {
           cage.SetActive(true);
        }
    }

    private void Attacking()
    {

    }
    //AUDIOS
    private void caveSound()
    {
        if (caveAllowed == true)
        {
            thecaveSound.SetActive(true);
            Invoke("noCave", 3);
        }
    }

    private void noCave()
    {
        thecaveSound.SetActive(false);
    }
    public void Footsteps()
    {
        if (isGrounded && isWalking == true)
        {
            walkAudio.SetActive(true);
            isWalking = false;
        }
    }
    //flashlight shenanigans: 
    public void flashlight()
    {
        if (!isLit)
        {
            light_light.SetActive(false);
            light_collider.SetActive(false);
            light_Off.SetActive(true);
            StopFlashlight();
        }

        if(isLit == true)
        {
            Invoke("LightAllowed", 9);
        }

        if (isLit == true && lightAllowed == true)
        {
            lightAllowed = false;
            light_light.SetActive(true);
            light_collider.SetActive(true);
            light_Off.SetActive(false);
            Invoke("StopFlashlight", 6);
            Invoke("StarttheFlicker", 4);
            Invoke("StarttheFlicker", 2);
        }
    }
   
    private void StopFlashlight()
    {
        light_light.SetActive(false);
        light_collider.SetActive(false);
    }
    IEnumerator LightFlicker()
    {
        light_light.SetActive(false);
        yield return new WaitForSeconds(secondsBetweenFlickers);
        light_light.SetActive(true);
        yield return new WaitForSeconds(secondsBetweenFlickers);
        light_light.SetActive(false);
        yield return new WaitForSeconds(secondsBetweenFlickers);
        light_light.SetActive(true);
        yield return new WaitForSeconds(secondsBetweenFlickers);
        light_light.SetActive(false);
        yield return new WaitForSeconds(secondsBetweenFlickers);
        light_light.SetActive(true);
        yield return new WaitForSeconds(secondsBetweenFlickers);
        
    }
    private void StarttheFlicker()
    {
        StartCoroutine(LightFlicker());
    }

    private void LightAllowed()
    {
        lightAllowed = true;
    }
    
}
