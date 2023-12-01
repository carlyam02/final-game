using System.Collections;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 10f; 

    void Start()
    {
        StartCoroutine(SpawnCoinsOverTime());
    }

    IEnumerator SpawnCoinsOverTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            SpawnCoin();
        }
    }

    void SpawnCoin()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-8.0f, -7.0f), Random.Range(-3f, -1f), 0f);
        GameObject newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D coinRigidbody = newCoin.GetComponent<Rigidbody2D>();
        if (coinRigidbody != null)
        {
            coinRigidbody.velocity = Vector2.down * 4;
        }
    }
}
