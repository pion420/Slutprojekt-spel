using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class SC_FPSController : MonoBehaviour
{
    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;
    public int HoppM‰ngd = 2;
    public int HoppM‰ngdKvar;
    public bool KanHoppaIgen;
    public float SpringFOV = 300f;
    public float GÂFOV = 65f;
    public int hehenummer = 1;
    public bool WallRuning = false;
    public int WallRunNum;
    

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("v‰gg"))
        {
            WallRuning = false;
            HoppM‰ngdKvar = HoppM‰ngd;


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("v‰gg"))
        {
            WallRuning = true;
            
        }
    }

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    IEnumerator HoppV‰nta()
    {
        KanHoppaIgen = false;
        yield return new WaitForSecondsRealtime(0.5f);
        KanHoppaIgen = true;

    }

    void Start()
    {
        KanHoppaIgen = true;

        characterController = GetComponent<CharacterController>();

        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

       
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            HoppM‰ngdKvar = HoppM‰ngd;
        }
        // We are grounded, so recalculate move direction based on axes
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && HoppM‰ngdKvar > 0 && KanHoppaIgen == true)
        {
            moveDirection.y = jumpSpeed;
            HoppM‰ngdKvar = HoppM‰ngdKvar - 1;
            StartCoroutine(HoppV‰nta());
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime * hehenummer;
        }

        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);

        // Player and Camera rotation
        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (playerCamera.fieldOfView < SpringFOV)
            {
                playerCamera.fieldOfView += 200 * Time.deltaTime;
            }
        }
        else
        {
            if (playerCamera.fieldOfView > GÂFOV)
            {
                playerCamera.fieldOfView -= 200 * Time.deltaTime;
            }
        }
        characterController.Move(moveDirection * Time.deltaTime);


        if (WallRuning == true)
        {
            hehenummer = 0;
            moveDirection = Vector3.zero;
        }
        if (WallRuning == false)
        {
            hehenummer = 1;
        }

        if (Input.GetKey("1"))
        {
            WallRuning = true;
        }
        if (Input.GetKey("2"))
        {
            WallRuning = false;
        }
        






       
        

        

    }
}