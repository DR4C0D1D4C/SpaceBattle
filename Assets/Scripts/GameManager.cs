using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private TMP_Text scoreText;

    private int score;

    List<GameObject> missileList = new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            GameObject newMissile = Instantiate(missilePrefab);

            newMissile.transform.position = new Vector3(Random.Range(-3.2f, 3.2f), 5.5f, 0);

            missileList.Add(newMissile);
        }
    }
}
