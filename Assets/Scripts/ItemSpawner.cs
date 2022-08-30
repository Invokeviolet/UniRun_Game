using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public GameObject itemPrefab2;
    public int count = 5; // ������ ����  

    public float timeBetSpawnMin = 0.25f; // ���� ��ġ������ �ð� ���� �ּڰ�
    public float timeBetSpawnMax = 1.25f; // ���� ��ġ������ �ð� ���� �ִ�
    private float timeBetSpawn; // ���� ��ġ������ �ð� ����

    public float yMin = 2f; // ��ġ�� ��ġ�� �ּ� y��
    public float yMax = 3.5f; // ��ġ�� ��ġ�� �ִ� y��
    private float xPos = 20f; // ��ġ�� ��ġ�� x ��

    private GameObject[] items; // �̸� ������ ������
    private int curItem = 0; // ����� ���� ������ ������

    private Vector2 poolPosition = new Vector2(20, 0); // �ʹݿ� ������ �����۵��� ȭ�� �ۿ� ���ܵ� ��ġ
    private float lastSpawnTime; // ������ ��ġ ����


    void Start()
    {
        // �������� �ʱ�ȭ�ϰ� ����� ���ǵ��� �̸� ����
        items = new GameObject[count];
        for (int i = 0; i < count; i++)
        {
            items[i] = Instantiate(itemPrefab, poolPosition, Quaternion.identity);
            items[i] = Instantiate(itemPrefab2, poolPosition, Quaternion.identity);
        }
        lastSpawnTime = 0f;
        timeBetSpawn = 0f;

    }
        
    void Update()
    {        
        //���ӿ����϶��� ������Ʈ �������� �ʰ� ��ȯ
        if (GameManager.instance.isGameover)
        {
            return;
        }
        if (Time.time - lastSpawnTime >= timeBetSpawn)  
        {
            lastSpawnTime = Time.time;
            timeBetSpawn = Random.Range(timeBetSpawnMin, timeBetSpawnMax); // ������ ��ġ�� ��ġ
            float yPos = Random.Range(yMin, yMax);

            items[curItem].SetActive(false);
            items[curItem].SetActive(true);

            items[curItem].transform.position = new Vector2(xPos, yPos);
            curItem++;

            if (curItem >= count)
            {
                curItem = 0;
            }
        }
    }
}
