
using UnityEngine;

public class controldecamara : MonoBehaviour
{

    public float speed = 20f;
    public float limite = 15f;
    public Vector2 limitesmapa;

    public float scrollspeed = 20f;
    public float minY =15f;
    public float maxY  =70f;


    public float rotationSpeed = 5f;
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height-limite)
        {
            pos.z += speed * Time.deltaTime;
        }

        if (Input.GetKey("s") || Input.mousePosition.y <= limite)
        {
            pos.z -= speed * Time.deltaTime;
        }

        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - limite)
        {
            pos.x += speed * Time.deltaTime;
        }

        if (Input.GetKey("a") || Input.mousePosition.x <= limite)
        {
            pos.x -= speed * Time.deltaTime;
        }

        //zoom
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollspeed *100f * Time.deltaTime;

       
        if (Input.GetMouseButton(2)) 
        {
            float rotateInputX = Input.GetAxis("Mouse X") * rotationSpeed;
            float rotateInputY = Input.GetAxis("Mouse Y") * rotationSpeed;

            transform.Rotate(Vector3.up, rotateInputX, Space.World);
            transform.Rotate(Vector3.left, rotateInputY, Space.Self);
        }


        pos.x = Mathf.Clamp(pos.x, -limitesmapa.x, limitesmapa.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, -limitesmapa.y, limitesmapa.y);
       
        transform.position = pos;

    }
}
