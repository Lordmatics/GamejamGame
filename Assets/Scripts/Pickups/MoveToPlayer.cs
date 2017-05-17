using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Scripts/Pickups/MoveToPlayer")]
public class MoveToPlayer : MonoBehaviour
{
    private bool bBeginMove;

    [Range(0.0f, 0.5f)] [ Header("Speed of absorption")]
    public float speed = 0.2f;
    [Range(0.0f, 0.5f)] [Header("Proximity of absorption")]
    public float range = 0.45f;
    [Range(0.0f, 0.5f)] [Header("Proximity of absorption")][SerializeField]
    private float delayForActivation = 0.3f;

    private Transform absorptionTransform;

    public delegate void OnDestroy();
    public event OnDestroy OnDestroyed;

    // Use this for initialization
    void Start ()
    {
        // Allocate reference to single player
        absorptionTransform = GameObject.FindGameObjectWithTag("Absorb").transform;//GameObject.FindObjectOfType<Player>().transform.GetChild(0).transform;
	}
	
    void OnEnable()
    {
        // Bind multiple functions
        OnDestroyed += CustomDestroy;
        OnDestroyed += NutCountUI.GainNut;
    }

    void OnDisable()
    {
        // Unbind bound functions - if you don't do this
        // It will crash
        OnDestroyed -= CustomDestroy;
        OnDestroyed -= NutCountUI.GainNut;
    }

    void CustomDestroy()
    {
        // Disable to end event, then kill
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public void BeginMovement()
    {
       // bBeginMove = true;
        StartCoroutine("MovementCoRoutine");
    }

    IEnumerator MovementCoRoutine()
    {
        // Dormant Period
        yield return new WaitForSeconds(delayForActivation);
        // Object gets alerted and bounces up
        for (int i = 0; i < 22; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        // Very subtle decline
        for (int i = 0; i < 4; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        // Then float into the player
        while (Vector3.Distance(transform.position, absorptionTransform.position) > range)
        {
            transform.LookAt(absorptionTransform.position);
            transform.Translate(Vector3.forward * speed);
            speed += Time.deltaTime * 0.1f;
            yield return new WaitForEndOfFrame();
        }
        if (Vector3.Distance(transform.position, absorptionTransform.position) <= range)
        {
            if (OnDestroyed != null)
                OnDestroyed();
        }
        yield return 0;
    }
}
