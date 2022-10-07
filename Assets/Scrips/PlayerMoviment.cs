using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float velocidade = 20f;
    public float rotation = 200f;
    public float corrida = 40f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) && velocidade < 40f)
        {
            velocidade += 5f;
        } else if (!Input.GetKey(KeyCode.LeftShift) && velocidade > 20f){
            velocidade -= 5f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 dir = new Vector3(x, 0, y) * velocidade;
        transform.Translate(dir * Time.deltaTime);  
        transform.Rotate(new Vector3(0, mouseX * rotation * Time.deltaTime, 0));
    }
}
