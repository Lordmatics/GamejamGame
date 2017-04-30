using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    // Physics based movement
    private Rigidbody _rigidbody;

    [SerializeField]
    private Vector3 jumpForce = new Vector3(0.0f, 300.0f, 0.0f);

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.freezeRotation = true;
    }

    public void PlayerControls()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

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
}
