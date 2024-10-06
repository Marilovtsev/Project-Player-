using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string playerName = "Flash"; // ��'� ������
    public float speed = 5f; // �������� ������.
    public int health = 100; // ������'� ������
    public int maxHealth = 100; // ����������� ������'� ������




    public void TakeDamage(int damage)
    {
        // ��������� �����
        health -= damage;
        if (health <= 0)
        {
            health = 0; // ��������� ��'������ �������� ������'� (���� ������'� ����� ����������, �� ������������ ���� � 0. �� ������� ���������, ���� ������'� ���� ���� ��'�����, �� �� �� ����� � �������� ���.)
        }
    }

    public void Heal(int healingAmount)
    {
        // ³��������� ������'�
        health += healingAmount;
        if (health > maxHealth)
        {
            health = maxHealth; // ��������� ����������� ������������� ������'�
        }
    }
}

public class PlayerController : MonoBehaviour
{
    private PlayerStats playerStats; // ��������� �� PlayerStats
    public float moveSpeed = 5f; // �������� ����

    void Start()
    {
        // �������� ��������� PlayerStats
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        Move(); // ��������� ����� ����
        // ��� ����� ����� ������ ����� ��� ��������� ���������� ��� ��������
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // �������� ��� �� �� X
        float moveVertical = Input.GetAxis("Vertical"); // �������� ��� �� �� Y

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.deltaTime; // ���������� ���
        transform.Tramslate(movement); // ����������� ���
    }