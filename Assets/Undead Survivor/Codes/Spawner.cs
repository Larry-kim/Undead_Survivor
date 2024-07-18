using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    public float levelTime;

    int level;
    float timer;

    void Awake()
    {
        spawnPoint = GetComponentsInChildren<Transform>();
        levelTime = GameManager.instance.maxGameTime / spawnData.Length;
    }

    void Update()
    {
        if (!GameManager.instance.isLive)
            return;

        timer += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / levelTime), spawnData.Length - 1); 
        // 소수점을 버리고 Int로 변환

        if(timer > spawnData[level].spawnTime)
        {
            timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData // 소환을 담당하는 클래스
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;


}