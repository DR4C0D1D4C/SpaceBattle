using UnityEngine;

public class MissileScript : MonoBehaviour
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
            this.transform.position += Vector3.up * speed * Time.deltaTime;

            if (this.transform.position.y >= 11f)
            {
                Destroy(gameObject);
            }
        }
    }
}
