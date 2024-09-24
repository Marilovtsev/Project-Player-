using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string playerName = "Flash"; // ��'� ������
    public float speed = 5f; // �������� ������
    public int health = 100; // ������'� ������
    

    void Update()
    {
        // ������� ������� ���� ������.
        float move = speed * Time.deltaTime;
        transform.Translate(move, 0, 0);
    }

    public void TakeDamage(int damage)
    {
        // ��������� �����
        health -= damage;
        if (health <= 0)
        {
            health = 0; // ��������� ��'������ �������� ������'� (���� ������'� ����� ����������, �� ������������ ���� � 0. �� ������� ���������, ���� ������'� ���� ���� ��'�����, �� �� �� ����� � �������� ���.)
        }           
    }
}