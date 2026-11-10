using System.Collections;
using UnityEngine;

public class SpaceshipScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject gameManager;
    [SerializeField] float force;
    [SerializeField] float secondsCooldown;

    float horizontalMovement;
    bool canShoot = true;

    void Start()
    {

    }

    private void FixedUpdate()
    {
        if (!gameManager.GetComponent<GameManager>().IsGameOver())
        {
            horizontalMovement = Input.GetAxis("Horizontal");

            rb.AddForce(Vector3.right * force * horizontalMovement, ForceMode2D.Force);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -7.2f, 7.2f), transform.position.y, transform.position.z);

            if (transform.position.x <= -7.2f || transform.position.x >= 7.2f)
            {
                rb.linearVelocityX = 0;
            }

            if (Input.GetKey(KeyCode.E) && canShoot)
            {
                GameObject newMissile = Instantiate(missilePrefab);

                newMissile.GetComponent<MissileScript>().AssignManager(gameManager);

                newMissile.transform.position = transform.position + Vector3.up;
                StartCoroutine(MissileCooldown());
            }
        }
        else
        {
            rb.linearVelocityX = 0;
        }
    }

    IEnumerator MissileCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(secondsCooldown);
        canShoot = true;
    }
}
