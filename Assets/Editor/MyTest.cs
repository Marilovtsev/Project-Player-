using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PlayerStatsTests
{
    GameObject player; // Об'єкт гравця

    [SetUp]
    public void Setup()
    {
        // Створюємо об'єкт гравця та додаємо компонент PlayerStats
        player = new GameObject();
        player.AddComponent<PlayerStats>();
       
    }

    [Test]
    public void TestPlayerSpeed()
    {
        // Отримуємо компонент PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // Отримуємо реальне значення швидкості
        float actualSpeed = playerStats.speed;

        // Очікуване значення
        float expectedSpeed = 5f;

        // Перевірка
        Assert.AreEqual(expectedSpeed, actualSpeed, "Швидкість гравця не відповідає очікуваному значенню.");
    }

    [Test]
    public void TestPlayerHealth()
    {
        // Отримуємо компонент PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // Отримуємо реальне значення здоров'я
        int actualHealth = playerStats.health;

        // Очікуване значення
        int expectedHealth = 100;

        // Перевірка
        Assert.AreEqual(expectedHealth, actualHealth, "Здоров'є гравця не відповідає очікуваному значенню.");
    }

    [Test]
    public void TestPlayerName()
    {
        // Отримуємо компонент PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // Отримуємо реальне значення ім'я
        string actualName = playerStats.playerName;

        // Очікуване значення
        string expectedName = "Flash";

        // Перевірка
        Assert.AreEqual(expectedName, actualName, "Ім'я гравця не відповідає очікуваному значенню.");
    }

    [Test]
    public void TestTakeDamage()
    {
        // Отримуємо компонент PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // Використовуємо метод TakeDamage
        playerStats.TakeDamage(20);

        // Отримуємо реальне значення здоров'я
        int actualHealth = playerStats.health;

        // Очікуване значення
        int expectedHealth = 80;

        // Перевірка
        Assert.AreEqual(expectedHealth, actualHealth, "Здоров'я гравця не відповідає очікуваному значенню після отримання пошкодження.");
    }

    [Test]
    public void TestTakeDamage_NegativeHealthPrevention()
    {
        // Отримуємо компонент PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // Методом TakeDamage наносимо 150 пошкоджень, якщо здоров'я 100
        playerStats.TakeDamage(150);

        // Перевірка
        Assert.AreEqual(0, playerStats.health, "Здоров'я гравця не повинно бути негативним.");
    }

    [Test]
    public void TestTakeDamage_ZeroDamage()
    {
        // Отримуємо компонент PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // Отримання початкового значення здоров'я:
        int initialHealt = playerStats.health;

        // Нанесення пошкодження
        playerStats.TakeDamage(0);

        // Перевірка значення здоров'я
        Assert.AreEqual(initialHealt, playerStats.health, "Здоров'я гравця повинно залишатися незмінним.");
    }
}

public class CameraTests
{
    GameObject gameObject;
    GameObject cameraObject;
    CameraFollow cameraFollow;

    [SetUp]
    public void Setup()
    {
        // Створюємо об'єкти камери та гравця
        cameraObject = new GameObject();
        playerObject = new GameObject();
    }
}