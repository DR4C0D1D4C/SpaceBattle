using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private GameObject gameManager;
    private bool canHit = true;

    public void AssignManager(GameObject gameManager)
    {
        this.gameManager = gameManager;
    }

    void FixedUpdate()
    {
        if (!gameManager.GetComponent<GameManager>().IsGameOver())
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Border" || collision.gameObject.tag == "Player")
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }

        if (collision.gameObject.tag == "Missile")
        {
            if (canHit)
            {
                gameManager.GetComponent<GameManager>().HitEnemy();
                StartCoroutine(HitCooldown());
            }
            Destroy(gameObject);
        }
    }

    IEnumerator HitCooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(1);
        canHit = true;
    }
}
