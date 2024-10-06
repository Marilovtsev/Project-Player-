using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string playerName = "Flash"; // Ім'я гравця
    public float speed = 5f; // Швидкість гравця.
    public int health = 100; // Здоров'я гравця
    public int maxHealth = 100; // Максимальне здоров'я гравця




    public void TakeDamage(int damage)
    {
        // Нанесення шкоди
        health -= damage;
        if (health <= 0)
        {
            health = 0; // Запобігаємо від'ємному значенню здоров'я (Якщо здоров'я стало негативним, ми встановлюємо його в 0. Це запобігає ситуаціям, коли здоров'я може бути від'ємним, що не має сенсу в контексті гри.)
        }
    }

    public void Heal(int healingAmount)
    {
        // Відновлення здоров'я
        health += healingAmount;
        if (health > maxHealth)
        {
            health = maxHealth; // Запобігаємо перевищенню максимального здоров'я
        }
    }
}

public class PlayerController : MonoBehaviour
{
    private PlayerStats playerStats; // Посилання на PlayerStats
    public float moveSpeed = 5f; // Швидкість руху

    void Start()
    {
        // Отримуємо компонент PlayerStats
        playerStats = GetComponent<PlayerStats>();
    }
}