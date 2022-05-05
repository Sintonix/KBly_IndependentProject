using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovementScript : MonoBehaviour
{
    public float speed = 5f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private GameObject targetSphere;
    private int count;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        targetSphere = GameObject.Find("Player");
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float hValue = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float vValue = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        targetSphere.transform.Translate(hValue, 0f, vValue);

        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        }
        
    }

    void SetCountText()
    {
        countText.text = "Cans Collected: " + count.ToString();
        if (count >= 28)
        {
            winTextObject.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}