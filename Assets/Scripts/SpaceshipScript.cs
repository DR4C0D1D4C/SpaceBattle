using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] private float force;

    private Rigidbody2D rb;
    private float horizontalMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.right * horizontalMovement * force);
    }
}
