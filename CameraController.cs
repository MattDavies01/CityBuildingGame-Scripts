using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float moveSpeed;

    public float minXRot;
    public float maxXRot;

    public float curXRot;

    public float minZoom;
    public float maxZoom;

    public float zoomSpeed;
    public float rotateSpeed;

    private float curZoom;
    private Camera cam;

    void Start ()
    {
        cam = Camera.main;
        curZoom = cam.transfrom.localPositoin.y;
        curXRot = -50;
    }

    void Update()
    {
        curZoom += Input.GetAxis("Mouse ScrollWheel") * -zoomSpeed;
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);

        cam.transfrom.localPositoin = Vector3.up * curZoom;

        if(Input.GetMouseButton(1))
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            curXRot += -y * rotateSpeed;
            curXRot = Mathf.Clamp(curXRot, minXRot, maxXRot);

            transfrom.eulerAngles = new Vector3(curXRot, transfrom.eulerAngles.y + (x * rotateSpeed), 0.0f);

            Vector3 forward = cam.transfrom.forward;
            forward.y = 0.0f;
            forward.Normalize();
            Vector3 right = cam.transfrom.right.normalized;

            float moveX = Input.GetAxisRaw("Horizontal");
            float moveZ = Input.GetAxisRaw("Vertical");

            Vector3 dir = forward * moveZ + right * moveX;
            dir.Normalize();

            dir *= moveSpeed * Time.deltaTime;

            transfrom.position += dir;

            /////////////////////////////
            /// IN UNITY
            ///
            /// Move Speed = 10
            /// Min X Rot -85
            /// Max X Rot -10
            /// Min Zoom = 5
            /// Max Zoom = 50
            /// Zoom Speed = 20
            /// Rotate Speed = 3
            ///
            /////////////////////////////
        }
    }
}