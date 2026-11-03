using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float force;

    float horizontalMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector3.right * force * horizontalMovement, ForceMode2D.Force);
    }
}
