using UnityEngine;

public class MissileScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private float force;
    [SerializeField] private GameObject enemyPrefab;

    private GameObject gameManager;

    public void AssignManager(GameObject gameManager)
    {
        this.gameManager = gameManager;
    }

    void FixedUpdate()
    {
        if (!gameManager.GetComponent<GameManager>().IsGameOver())
        {
            rb.AddForce(Vector3.up * force, ForceMode2D.Force);
        }
        else
        {
            rb.linearVelocityX = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
