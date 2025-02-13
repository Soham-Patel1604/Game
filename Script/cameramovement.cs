using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public float sensx;
    public float sensy;

    public Transform orientation;

    public float xrotation;
    public float yrotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mousex = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensx;
        float mousey = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensy;

        yrotation += mousex;
        xrotation -= mousey;
        xrotation=Mathf.Clamp(xrotation, -90f, 90f);

        //rotate camerea and oriat
        transform.rotation = Quaternion.Euler( xrotation, yrotation, 0);
        orientation.rotation = Quaternion.Euler( 0, yrotation, 0);

    }
}
