using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region MOVE_SPEEDS
[System.Serializable]
public class MoveSpeeds
{
    [Header("Horizontal Ground Speed")]
    public float horizontalSpeed = 100.0f;

    [Header("Vertical Ground Speed")]
    public float verticalSpeed = 10.0f;

    public MoveSpeeds(float x = 10.0f, float y = 10.0f)
    {
        horizontalSpeed = x;
        verticalSpeed = y;
    }
}

[System.Serializable]
public class AirSpeeds
{
    [Header("Horizontal Air Speed")]
    public float horizontalSpeed = 100.0f;

    [Header("Vertical Air Speed")]
    public float verticalSpeed = 10.0f;

    [Header("Glide Power")]
    public float glideMagnitude = 350.0f;

    [Header("Resistance against natural gravity to simulate glide")]
    public float gravityDampener = 6.5f;

    [HideInInspector]
    public float glideDelay = 0.5f;

    [HideInInspector]
    public float timeSinceJump = 0.0f;

    public AirSpeeds(float a = 100.0f, float b = 10.0f, float c = 350.0f, float d = 6.5f, float e = 0.5f, float f = 0.0f)
    {
        horizontalSpeed = a;
        verticalSpeed = b;
        glideMagnitude = c;
        gravityDampener = d;
        glideDelay = e;
        timeSinceJump = f;
    }
}

[System.Serializable]
public class ClimbSpeeds
{
    [Header("Horizontal Climb Speed")]
    public float horizontalSpeed = 250.0f;

    [Header("Vertical Climb Speed")]
    public float verticalSpeed = 10.0f;

    public ClimbSpeeds(float x = 250.0f, float y = 10.0f)
    {
        horizontalSpeed = x;
        verticalSpeed = y;
    }
}
#endregion

[RequireComponent(typeof(Rigidbody))]
[AddComponentMenu("Scripts/Player/PlayerMovement")]
public class PlayerMovement : MonoBehaviour
{

    // Physics based movement
    private Rigidbody _rigidbody;

    [SerializeField]
    private Vector3 jumpForce = new Vector3(0.0f, 300.0f, 0.0f);

    [SerializeField]
    private MoveSpeeds movespeeds = new MoveSpeeds();

    [SerializeField]
    private AirSpeeds airSpeeds = new AirSpeeds();

    [SerializeField]
    private ClimbSpeeds climbSpeeds = new ClimbSpeeds();

    [SerializeField]
    private Transform rotationTransform;

    // Jump event - to notify state machine to update state
    public delegate void JumpDelegate();
    private JumpDelegate OnFlyBegin;


    private bool bIsGliding = false;
    private StoredVelocities previousVelocities;

    private PlayerAnimations animScript;

    //[SerializeField][Header("Turn this off for sanity")]
    //private bool bDebugRotation = false;

    // Utility for performance
    // Only bind event once - as opposed to every frame
    // If return type wasn't void, could use llambda function instead - a => a.b
    public void AssignJumpEvent(JumpDelegate JumpDel)
    {
        // Assigned from Player script
        OnFlyBegin = JumpDel;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;

        animScript = GetComponent<PlayerAnimations>();

        rotationTransform = GameObject.FindGameObjectWithTag("RotationTransform").transform;
    }

    void OnEnable()
    {
        OnFlyBegin += SetTime;
    }

    void OnDisable()
    {
        OnFlyBegin -= SetTime;
    }

    void SetTime()
    {
        airSpeeds.timeSinceJump = Time.time;
    }

    float GetElapsedTime()
    {
        return Time.time - airSpeeds.timeSinceJump;
    }

    void Update()
    {
        //Debug.Log(transform.eulerAngles + "My Euler Angles");
        //Debug.Log(Camera.main.transform.eulerAngles + "Camera Euler Angles");
    }

    // Enable Player movement on the ground
    public void PlayerGroundControls()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * movespeeds.horizontalSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * movespeeds.verticalSpeed;
        
        if(Mathf.Abs(z) > 0.0f)
        {
            animScript.SetAnimRunning(true);
        }
        else
        {
            animScript.SetAnimRunning(false);
        }
        // Scripted movement - can dabble with physics movement later if we feel this isn't good enough
        Vector3 movementVector = new Vector3(0.0f, 0.0f, z);
        transform.Translate(movementVector, rotationTransform);
        transform.Rotate(0.0f, x, 0.0f);

        bIsGliding = false;
        //if(bDebugRotation)
        //{
        //    //transform.Rotate(0.0f, x * 25.0f, 0.0f);
        //    float minRot = Camera.main.transform.eulerAngles.y - 90.0f;
        //    float maxRot = Camera.main.transform.eulerAngles.y + 90.0f;
        //    if (Camera.main.transform.eulerAngles.y >= 270.0f && Camera.main.transform.eulerAngles.y < 360.0f)
        //    {
        //        minRot = Camera.main.transform.eulerAngles.y - 90.0f;
        //        float temp = 360.0f - Camera.main.transform.eulerAngles.y;
        //        maxRot = temp + 90.0f;
        //    }
        //    if (Camera.main.transform.eulerAngles.y <= 90.0f && Camera.main.transform.eulerAngles.y > 0.0f)
        //    {
        //        float temp = 90.0f - Camera.main.transform.eulerAngles.y;
        //        minRot = -temp;
        //        maxRot = Camera.main.transform.eulerAngles.y + 90.0f;
        //    }

        //    //Debug.Log(minRot);
        //    //Debug.Log(maxRot);
        //    //Debug.Log(Camera.main.transform.localEulerAngles.y);
        //   // Mathf.Clamp(transform.eulerAngles.y, minRot, maxRot)
        //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Lerp(transform.eulerAngles.y, Camera.main.transform.eulerAngles.y, Time.deltaTime * 7.5f), transform.eulerAngles.z);
        //}
        //else
        //{
        //    //Mathf.Lerp(transform.eulerAngles.y,Camera.main.transform.eulerAngles.y,Time.deltaTime * 7.5f)
        //    transform.eulerAngles = new Vector3(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y , transform.eulerAngles.z);
        //    // transform.rotation = new Quaternion(transform.rotation.x, GameObject.FindGameObjectWithTag("MainCamera").transform.rotation.y, transform.rotation.z , 1.0f);
        //    //Debug.Log(transform.rotation + ".Rotation - Player");
        //    //Debug.Log(transform.eulerAngles + ".EulerAngles - Player");

        //    //Debug.Log(Camera.main.transform.rotation + ".Rotation - Cam");
        //    //Debug.Log(Camera.main.transform.eulerAngles + ".EulerAngles - Cam");
        //}



        //transform.rotation = new Quaternion(transform.rotation.x, Mathf.LerpUnclamped(transform.rotation.y, Camera.main.transform.rotation.y, Time.deltaTime * 5.0f), transform.rotation.z, 1.0f);
        //transform.rotation = Quaternion.LerpUnclamped(transform.rotation, Camera.main.transform.rotation, Time.deltaTime * 5.0f);

    }

    public void ResetRigidbodyVelocities()
    {
        //previousVelocities = new StoredVelocities(-Vector3.up * 50.0f, -Vector3.up * 50.0f);//_rigidbody.ResetVelocity();
        SetTime();
        Debug.Log("RESET VEL");
    }

    IEnumerator ForceStopHack()
    {
        _rigidbody.isKinematic = true;
        yield return new WaitForSeconds(0.1f);
        _rigidbody.isKinematic = false;
    }

    public void PlayerAirControls()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * airSpeeds.horizontalSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * airSpeeds.verticalSpeed;

        transform.Rotate(0, x, 0);
        if (bIsGliding) return;
        Vector3 movementVector = new Vector3(0.0f, 0.0f, z);
        transform.Translate(movementVector, rotationTransform);

        // Can tilt the players body when flying
        //Vector3 movement = new Vector3(x, 0.0f, z);
        //_rigidbody.velocity = movement * airSpeeds.verticalSpeed;
        //rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -tilt);
    }

    public void PlayerClimbControls()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * climbSpeeds.horizontalSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * climbSpeeds.verticalSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    // Event for jumping vertically
    public void PlayerJump()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("PlayerJump"))
        {
            _rigidbody.AddForce(jumpForce);
            // Change MSM to Air Mode, and Reset Elapsed Time
            if (OnFlyBegin != null)
                OnFlyBegin();
        }
    }

    public void InitiateGlide()
    {
        PlayerAirControls();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("PlayerJump"))
        {
            if(GetElapsedTime() >= airSpeeds.glideDelay && !bIsGliding)
            {
                bIsGliding = true;
            }
        }
    }
    public void PlayerGlide()
    {
        InitiateGlide();
        // While space is held down apply force
        //if (Input.GetKey(KeyCode.Space) || Input.GetButton("PlayerJump"))
        //{
        //    if(GetElapsedTime() >= airSpeeds.glideDelay)
        //    {
        //        bIsGliding = true;
        if (!bIsGliding) return;
        _rigidbody.AddForce(transform.forward * Time.deltaTime * airSpeeds.glideMagnitude + (Vector3.up * airSpeeds.gravityDampener), ForceMode.Force);
        Debug.Log("Gliding");
        if (Input.GetButtonDown("PlayerFall"))//Input.GetKeyUp(KeyCode.Space))
        {
            ResetRigidbodyVelocities();
            Player.instance.ToFallingState();
        }
    }

    public void PlayerFall()
    {
        //_rigidbody.ResumeVelocity(previousVelocities);
        StartCoroutine(ForceStopHack());
    }

    public void BuildObject()
    {
        Instantiate(new GameObject());
    }
}
