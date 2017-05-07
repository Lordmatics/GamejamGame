using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region MOVE_SPEEDS
[System.Serializable]
public class MoveSpeeds
{
    [Header("HorizontalSpeed")]
    public float horizontalSpeed = 250.0f;

    [Header("VerticalSpeed")]
    public float verticalSpeed = 10.0f;

    public MoveSpeeds(float x = 250.0f, float y = 10.0f)
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

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    public void PlayerControls()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * movespeeds.horizontalSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * movespeeds.verticalSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }

    public void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.AddForce(jumpForce);
        }
    }

    public void BuildObject()
    {
        Instantiate(new GameObject());
    }
}
