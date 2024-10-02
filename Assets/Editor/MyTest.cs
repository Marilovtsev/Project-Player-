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

    [Test]
    public void TestPlayerHealthMaxLimit()
    {
        // Отримуємо компонент PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // Наносимо пошкодження
        playerStats.TakeDamage(50); // Зменшуємо здоров'я до 50
        Assert.AreEqual(50, playerStats.health, "Здоров'я гравця повинно бути 50 після пошкодження.");

        // Відновлюємо здоров'я на більше, ніж максимальне
        playerStats.Heal(100); // Має відновити до 100, не більше
        Assert.AreEqual(playerStats.maxHealth, playerStats.health, "Здоров'я гравця не повинно перевищувати максимальне значення.");
    }

    public class CameraTests
    {
        GameObject gameObject;
        GameObject cameraObject;
        GameObject playerObject;
        CameraFollow cameraFollow;

        [SetUp]
        public void Setup()
        {
            // Створюємо об'єкти камери та гравця
            cameraObject = new GameObject();
            playerObject = new GameObject();

            // Додаємо до камери скрипт CameraFollow (наш компонент)
            cameraFollow = cameraObject.AddComponent<CameraFollow>();

            // Вказуємо персонажа, за яким має стежити камера
            cameraFollow.target = playerObject.transform;
        }

        [Test]
        public void TestCameraFollowPlayer()
        {
            // Початкова позиція персонажа
            playerObject.transform.position = new Vector3(0, 0, 0);
            cameraObject.transform.position = new Vector3(0, 0, 10); // Камера на відстані по осі Z

            // Переміщуємо персонажа
            playerObject.transform.position = new Vector3(10, 0, 0);

            // Задаємо позицію камери
            cameraObject.transform.position = new Vector3(playerObject.transform.position.x, cameraObject.transform.position.y, cameraObject.transform.position.z);

            // Перевіряємо, чи камера тепер знаходиться біля персонажа
            Assert.AreEqual(cameraObject.transform.position.x, playerObject.transform.position.x, "Камера не слідує за персонажем по осі X.");



        }

        [Test]
        public void TestCameraNotFollowBeyondLimit()
        {
            // Встановлюємо межу позиції персонажа
            float followLimit = 55;

            // Початкова позиція персонажа нижче межі
            playerObject.transform.position = new Vector3(50, 0, 0);
            cameraObject.transform.position = new Vector3(50, 0, 10); // Камера на початковій позиції по осі Z

            // Оновлюємо позицію камери через метод FollowPlayer
            cameraFollow.FollowPlayer();

            // Перевіряємо, що камера слідує за персонажем, коли той у межах
            Assert.AreEqual(cameraObject.transform.position.x, playerObject.transform.position.x, "Камера повинна слідувати за персонажем у межах.");

            // Переміщуємо персонажа за межу
            playerObject.transform.position = new Vector3(60, 0, 0);

            // Оновлюємо позицію камери через метод FollowPlayer
            cameraFollow.FollowPlayer();

            // Перевіряємо, що камера більше не слідує за персонажем за межами
            Assert.AreNotEqual(cameraObject.transform.position.x, playerObject.transform.position.x, "Камера не повинна слідувати за персонажем поза межами.");
        }

    }
}