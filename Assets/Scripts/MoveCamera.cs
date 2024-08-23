using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float speed = 10.0f;
    public float gameLength = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 p = GetBaseInput();
        transform.Translate(p * speed * Time.deltaTime);
    }

    private Vector3 GetBaseInput() 
    {
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.A) && transform.position.x > 0){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D) && transform.position.x < gameLength){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}
