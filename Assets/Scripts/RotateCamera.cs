using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speedH = 2.0f;
    public float speedV = 3.0f;
    public Vector3 min;
    public Vector3 max;

    private float yaw = 2.0f;
    private float pitch = 2.0f;
  
    void Update()
    {
        MouseRotate();
    }

    private void MouseRotate()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        //Min max for horizontal
        yaw = Mathf.Clamp(yaw, 120f, 240f);
        //Min max for vertical
        pitch = Mathf.Clamp(pitch, -20f, 40f);

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
