using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public string playerName = "Flash"; // ≤м'€ гравц€
    public float speed = 5f; // Ўвидк≥сть гравц€
    public int health = 100; // «доров'€ гравц€
    

    void Update()
    {
        // ѕростий приклад руху гравц€.
        float move = speed * Time.deltaTime;
        transform.Translate(move, 0, 0);
    }

    public void TakeDamage(int damage)
    {
        // Ќанесенн€ шкоди
        health -= damage;
        if (health <= 0)
        {
            health = 0; // «апоб≥гаЇмо в≥д'Їмному значенню здоров'€ (якщо здоров'€ стало негативним, ми встановлюЇмо його в 0. ÷е запоб≥гаЇ ситуац≥€м, коли здоров'€ може бути в≥д'Їмним, що не маЇ сенсу в контекст≥ гри.)
        }           
    }
}