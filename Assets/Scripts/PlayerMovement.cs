using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    private Rigidbody rb;
    private ScoreManagerX scoreManager;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scoreManager = FindObjectOfType<ScoreManagerX>();  // Automatically find the ScoreManagerX script
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 forwardMovement = transform.forward * verticalInput * moveSpeed;
        Vector3 rotationMovement = new Vector3(0, horizontalInput * rotationSpeed, 0);

        rb.MovePosition(rb.position + forwardMovement * Time.deltaTime);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationMovement * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fish"))
        {
            scoreManager.AddScore(1);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Wood"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}

