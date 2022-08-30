using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : Platform
{    
    public GameObject[] Items;
    public GameObject PowerBar;
    private bool touched = false; // �÷��̾� ĳ���Ͱ� ��ġ�߳�?    
    public float speed = 3f;

    public int dir = 0;    
    public float up;
    public float down;

    void Start()
    {
        
    }
    void Update()
    {
        gameObject.SetActive(true);

        up = speed * Time.deltaTime;
        down = -speed * Time.deltaTime;
        
        // �ʴ� speed�� �ӵ��� ���Ʒ��� ������

        if (transform.localPosition.y > 4f)
        {
            dir = 1;
        }
        if (transform.localPosition.y <= 2f)
        {
            dir = 0;
        }

        switch (dir)
        {
            case 0:
                transform.Translate(new Vector2(0, up));
                break;
            case 1:
                transform.Translate(new Vector2(0, down));
                break;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
        if (other.tag == "Player" && !touched) // �±� == Die && ���� ���°� �ƴҶ�
        {
            touched = true;
            gameObject.SetActive(false);
            //�����ð����� ��������
           
        }
    }
}
