using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{

    public float speed;
    public Text counttext;
    public Text wintext;

    private Rigidbody rb;
    private int count;
	
    // Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        wintext.text = "";
	}
	
	// Called before performing any physics calculations
	void FixedUpdate ()
    {

        //設移動變數
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(mh, 0.0f, mv);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("point"))
        {
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("point"))
        {
            other.gameObject.SetActive(false);
            count = count +  1;
            SetCountText();
        }
    }

    void SetCountText()
    {
        counttext.text = "Count:" + count.ToString();
        if (count >= 25)
        {
            wintext.text = "Congratulations";
        }
    }
}
