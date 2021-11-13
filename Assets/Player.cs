using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float jumpForce = 2f;


    public Rigidbody2D rb;
    public SpriteRenderer sr; //  SpriteColor Keeper

    public string currentColor;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorPink;
    public Color colorMagenta;

     void Start()
    {
        SetRandomColor();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }    
    }


     void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag =="ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        if (col.tag == "LastColorSwitch")
        {
            Debug.Log("Congratulations");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if (col.tag!=currentColor)
        {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);





            
        }



    }


    void SetRandomColor()
    {
        int index = Random.Range(0, 4);




        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;     
        }
    }

}
