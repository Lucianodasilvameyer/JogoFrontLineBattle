using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField]Rigidbody2D righ;
    Vector2 moviment;

    [SerializeField]Vector2 mousePos;
    public Camera cam;

    void Awake()
    {
        righ = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        moviment.x = Input.GetAxisRaw("Horizontal");
        moviment.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log("Mouse position: " + mousePos);        
    }
    void FixedUpdate()
    {
        righ.MovePosition(righ.position + moviment * moveSpeed * Time.fixedDeltaTime);

        Vector2 OlharDirecao = mousePos - righ.position;

        float angle = Mathf.Atan2(OlharDirecao.y,OlharDirecao.x) * Mathf.Rad2Deg-90f;

        //Debug.Log(angle);

        righ.rotation = angle; 
    }
}
