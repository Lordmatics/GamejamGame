using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region MOVE_SPEEDS
[System.Serializable]
public class MoveSpeeds
{
    [Header("Horizontal Ground Speed")]
    public float horizontalSpeed = 10.0f;

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

    // Jump event - to notify state machine to update state
    public delegate void JumpDelegate();
    private JumpDelegate OnFlyBegin;

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

    // Enable Player movement on the ground
    public void PlayerGroundControls()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * movespeeds.horizontalSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * movespeeds.verticalSpeed;

        x *= Camera.main.transform.right.x;

        z *= Camera.main.transform.forward.z;

        //transform.Rotate(0, x, 0);
        //transform.position = new Vector3(Camera.main.transform.position.x + x, 0.0f, Camera.main.transform.position.z + z);
        transform.Translate(x, 0, z);
        //_rigidbody.MovePosition(transform.position + new Vector3(x,z,0.0f))
    }

    public void PlayerAirControls()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * airSpeeds.horizontalSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * airSpeeds.verticalSpeed;

        transform.Rotate(0, x, 0);
        //transform.Translate(x, 0, 0);
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(jumpForce);
            if (OnFlyBegin != null)
                OnFlyBegin();
        }
    }

    public void PlayerGlide()
    {
        // While space is held down apply force
        if (Input.GetKey(KeyCode.Space))
        {
            if(GetElapsedTime() >= airSpeeds.glideDelay)
            {
                _rigidbody.AddForce(transform.forward * Time.deltaTime * airSpeeds.glideMagnitude + (Vector3.up * airSpeeds.gravityDampener), ForceMode.Acceleration);
                PlayerAirControls();
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    _rigidbody.ResetVelocity();
                    SetTime();
                    Player.instance.ToFallingState();
                }
            }
        }
        else
        {
            // Only Jumped - Didn't initiate glide
            PlayerGroundControls();
        }
    }

    public void BuildObject()
    {
        Instantiate(new GameObject());
    }
}
