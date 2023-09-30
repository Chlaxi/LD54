using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Camera cam;
    private Animator anim;
    private InputReader InputReader;
    private CharacterController characterController;

    [SerializeField]
    private float baseSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        characterController = GetComponent<CharacterController>();
        InputReader = GetComponent<InputReader>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
  
        Move();
        LookDirection();
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

    Vector3 GetMouseWorldPosition(){
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Ray ray = new Ray(mousePos, cam.transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        Vector3 hitPoint = hit.point;
        hitPoint.y = 0;
        return hitPoint;
    }

    void LookDirection(){
        Vector3 pos = transform.position; 
        pos.y = 0;
        Vector3 direction = GetMouseWorldPosition() - pos;
        direction.Normalize();
        transform.rotation = Quaternion.LookRotation(direction);
    }

    void OnDrawGizmos(){
        Vector3 mouseHitPoint = GetMouseWorldPosition();
        Gizmos.DrawSphere(mouseHitPoint, .5f);
        Vector3 pos = transform.position; 
        pos.y = 0;
        Vector3 direction = mouseHitPoint - pos;
        direction.Normalize();
        Gizmos.DrawLine(pos, direction);
    }
}
