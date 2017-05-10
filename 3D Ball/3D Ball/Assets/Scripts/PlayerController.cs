using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public Text countText;
    public Text winText;

    private int count;

    Vector3 zeroAc;
    Vector3 curAc;
    float sensH = 10;
    float sensV = 10;
    float smooth = 0.5f;
    float GetAxisH = 0;
    float GetAxisV = 0;

    void ResetAxes()
    {
        zeroAc = Input.acceleration;
        curAc = Vector3.zero;
    }
    void Start()
    {
        ResetAxes();

        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();

        winText.text = "";
    }
    void FixedUpdate()
    {
        //Mobile
        /*
        curAc = Vector3.Lerp(curAc, Input.acceleration - zeroAc, Time.deltaTime / smooth);
        GetAxisV = Mathf.Clamp(curAc.y * sensV, -1, 1);
        GetAxisH = Mathf.Clamp(curAc.x * sensH, -1, 1);

        rb.AddForce(new Vector3(GetAxisH, 0.0f, GetAxisV));
        */

        //PC
        
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.AddForce((new Vector3(moveHorizontal, 0.0f, moveVertical)) * 10);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You won!";
        }
    }
}
