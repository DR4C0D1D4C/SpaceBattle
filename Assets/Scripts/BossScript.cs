using System.Collections;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private GameObject gameManager;
    private bool canHit = true;
    private float hp = 4;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

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

        if (hp == 0)
        {
            gameManager.GetComponent<GameManager>().DestroyBoss();
            Destroy(gameObject);
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
                hp--;
                StartCoroutine(Impacted());
                StartCoroutine(HitCooldown());
            }
        }
    }

    IEnumerator HitCooldown()
    {
        canHit = false;
        yield return new WaitForSeconds(0.5f);
        canHit = true;
    }

    IEnumerator Impacted()
    {
        for (int i = 0; i < 5; i++)
        {
            sr.color = Color.red;

            yield return new WaitForSeconds(0.1f);

            sr.color = Color.white;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
