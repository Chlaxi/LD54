using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Animator anim;
    private InputReader InputReader;
    private CharacterController characterController;

    [SerializeField]
    private float baseSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        InputReader = GetComponent<InputReader>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        Vector3 direction = new Vector3(InputReader.MovementDir.x, 0, InputReader.MovementDir.y);

        direction.Normalize();
        float speed = baseSpeed; // Add modifiers
        Vector3 velocity = direction * speed;
        characterController.Move(velocity * Time.deltaTime);
        Debug.Log(velocity.magnitude);
        anim.SetFloat("Speed", velocity.magnitude);
    }

    void LookDir(){
        
    }
}
