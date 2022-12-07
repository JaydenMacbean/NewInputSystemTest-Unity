using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class TestPlayer2 : MonoBehaviour
{

    public CharacterAttributes characterStats;
    FGController fgcontroller;


    [SerializeField] private Vector2 moveInput;
    private Rigidbody RB;

    [SerializeField] private InputActionReference actionReference;
    [SerializeField] private bool firstTap;
    [SerializeField] private float firstTapTime;
    [SerializeField][Range(0f, 1f)] private float lastTapTime;
    [SerializeField] private const float dClick = 20f;
    [SerializeField] private float speed;
    [SerializeField] private float time;

    public AnimationCurve runCurve;

    private enum playerStates
    {
        STANDING,
        CROUCHING,
        WALKING,
        RUNNING,
        JUMPING,
        BLOCKING,
        FAULTLESS_DEFENSE,
        BURST
    }

    [SerializeField] private playerStates pState;


    private void Awake()
    {

        #region Controls


        fgcontroller = new FGController();
        fgcontroller.FGControls.Enable();
        fgcontroller.FGControls.I8.performed += ctx => Jump();
        fgcontroller.FGControls.I2.performed += ctx => Crouch();
        fgcontroller.FGControls.I44.performed += ctx => Backdash();

        var sixSix = new InputAction();
        //sixSix.AddBinding("<Gamepad>/D-Pad").WithInteraction(""); 






        #endregion

        RB = GetComponent<Rigidbody>();

        switch (characterStats.characterWeight)
        {

            case "L":
                characterStats.characterWeight = "Lightweight";
                Debug.Log("This character's a lightweight!");
                break;

            case "M":
                characterStats.characterWeight = "Mediumweight";
                Debug.Log("This character's a mediumweight!");
                break;

            case "H":
                characterStats.characterWeight = "Heavyweight";
                Debug.Log("This character's a heavyweight!");
                break;


        }

        switch (pState)
        {
            case playerStates.STANDING:
                characterStats.isBlockingAllowed = true;
                characterStats.isWalkingAllowed = true;
                characterStats.isRunningAllowed = true;
                break;

            case playerStates.CROUCHING:
                characterStats.isBlockingAllowed = true;
                characterStats.isWalkingAllowed = false;
                characterStats.isRunningAllowed = false;
                break;

            case playerStates.RUNNING:
                characterStats.isBlockingAllowed = false;
                characterStats.isWalkingAllowed = false;
                break;

            case playerStates.BLOCKING:
                characterStats.isBlockingAllowed = true;
                characterStats.isWalkingAllowed = false;
                characterStats.isRunningAllowed = false;
                break;

            case playerStates.JUMPING:
                characterStats.isBlockingAllowed = false;
                break;

            case playerStates.FAULTLESS_DEFENSE:
                characterStats.isBlockingAllowed = true;
                break;
        }

    }

    private void Start()
    {
        pState = playerStates.STANDING;
        firstTap = false;
    }

    private void FixedUpdate()
    {
        TestWalk();
        //TestCurve();

        

    }

    void OnEnable()
    {
        fgcontroller.FGControls.Enable();
        actionReference.action.Enable();
    }

    void OnDisable()
    {
        fgcontroller.FGControls.Disable();
    }

    void Jump()
    {
        pState = playerStates.JUMPING;
        Debug.Log("Jumping up");
    }

    void Crouch()
    {
        pState = playerStates.CROUCHING;
        Debug.Log("Crouching down");
    }

    void TestWalk()
    {

        
        moveInput = fgcontroller.FGControls.Walk.ReadValue<Vector2>();
        RB.velocity = moveInput * characterStats.walkSpeed;
        if(moveInput != Vector2.zero)
        {
            Debug.Log("Justice invuln walk lololo");
            pState = playerStates.WALKING;
            fgcontroller.FGControls.Walk.canceled += ctx => pState = playerStates.STANDING;
        }
        Debug.Log("Walking allowed = " + characterStats.isWalkingAllowed);


    }

    /*void TestCurve()
    {
        speed = runCurve.Evaluate(time);
        time = Time.deltaTime;
        var button = Input.GetKeyDown(KeyCode.W);

        //Movement curve test
        if (Input.GetKeyDown(KeyCode.W))
        {
            pState = playerStates.WALKING;
            RB.velocity =  speed;

        }
    }*/

    /*void Walk(Vector2 walkCtx)
    {
        Debug.Log("Walking forward");

        walkCtx = fgcontroller.FGControls.Walk.ReadValue<Vector2>();
        float targetedSpeed = moveInput.x * characterStats.walkSpeed;
        float speedDif = targetedSpeed - RB.velocity.x;

        RB.AddForce(speedDif * Vector2.right, ForceMode.Force);
    }*/

    private void Run()
    {
    }

    public void Run2()
    {
        if(characterStats.isRunningAllowed == true)
        {
            Debug.Log("Running forward, can't block rn");
            pState = playerStates.RUNNING;
            moveInput = fgcontroller.FGControls.I66.ReadValue<Vector2>();
            RB.velocity = moveInput * characterStats.initialRunSpeed;
        }
    }

    void Backdash()
    {
        Debug.Log("Backdash Pot Buster");
    }

    void Flip()
    {

    }

    void ProximityGuard()
    {

    }



}
