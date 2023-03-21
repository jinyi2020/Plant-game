using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public float speed = 5.0f;
    public float sensitivity = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameData.Instance.isUIOpen)
        {
            transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * speed * Time.deltaTime);
            transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);

            if (Input.GetMouseButton(0))
            {
                transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * sensitivity, 0));
                
            }
        }
        
    }
}
