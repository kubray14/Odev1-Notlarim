using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController characterController;

    [SerializeField] float speed = 60f;
    [SerializeField] float mouseSensivity = 100f;

    float xRotation, yRotation, MouseX, MouseY;

    Vector3 direction;

    [HideInInspector] public Transform GrabbedItem;

    public static Player Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();

        GrabbedItem = transform.Find("GrabbedItem");
    }

    void Update()
    {
        direction = transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical");

        characterController.Move(speed * Time.deltaTime * direction + 9.81f * Time.deltaTime * Vector3.down);

        MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensivity;
        MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensivity;

        xRotation -= MouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation += MouseX;

        transform.rotation = Quaternion.Euler(new Vector3(xRotation, yRotation, 0f));
    }
}
