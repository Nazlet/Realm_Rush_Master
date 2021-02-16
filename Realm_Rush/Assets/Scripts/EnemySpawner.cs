using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] int score;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        scoreText.text = score.ToString();
    }

    IEnumerator SpawnEnemy()
    {
        while (true) // forever
        {
            AddScore();
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            newEnemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }

    private void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }





    // Update is called once per frame
    void Update()
    {
        
    }
}
