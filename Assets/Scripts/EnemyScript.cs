using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject gameManager;

    public void AssignManager(GameObject gameManager)
    {
        this.gameManager = gameManager;
    }

    void FixedUpdate()
    {
        if (!gameManager.GetComponent<GameManager>().IsGameOver())
        {
            this.transform.position += Vector3.down * speed * Time.deltaTime;

            if (transform.position.y <= -10f)
            {
                gameManager.GetComponent<GameManager>().GameOver();
            }
        }
    }
}
