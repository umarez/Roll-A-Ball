using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;


    // Start is called before the first frame update
    void Start()
    {
        // Getting gameObject rigidbody
        rb = GetComponent<Rigidbody>();
        setCountText();
        winTextObject.SetActive(false);
        count = 0;
    }

    void OnMove(InputValue movementValue)
    {
        // Take the vector value and store to variable
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 7)
        {
            winTextObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 10f, 0), ForceMode.Impulse);
            Debug.Log("space key was pressed");
        }
    }

    void FixedUpdate()
    {
        // Apply force to rigidbody
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);


    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();

        }

    }
}
