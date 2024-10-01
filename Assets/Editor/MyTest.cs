using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class PlayerStatsTests
{
    GameObject player; // ��'��� ������

    [SetUp]
    public void Setup()
    {
        // ��������� ��'��� ������ �� ������ ��������� PlayerStats
        player = new GameObject();
        player.AddComponent<PlayerStats>();
       
    }

    [Test]
    public void TestPlayerSpeed()
    {
        // �������� ��������� PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // �������� ������� �������� ��������
        float actualSpeed = playerStats.speed;

        // ��������� ��������
        float expectedSpeed = 5f;

        // ��������
        Assert.AreEqual(expectedSpeed, actualSpeed, "�������� ������ �� ������� ����������� ��������.");
    }

    [Test]
    public void TestPlayerHealth()
    {
        // �������� ��������� PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // �������� ������� �������� ������'�
        int actualHealth = playerStats.health;

        // ��������� ��������
        int expectedHealth = 100;

        // ��������
        Assert.AreEqual(expectedHealth, actualHealth, "������'� ������ �� ������� ����������� ��������.");
    }

    [Test]
    public void TestPlayerName()
    {
        // �������� ��������� PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // �������� ������� �������� ��'�
        string actualName = playerStats.playerName;

        // ��������� ��������
        string expectedName = "Flash";

        // ��������
        Assert.AreEqual(expectedName, actualName, "��'� ������ �� ������� ����������� ��������.");
    }

    [Test]
    public void TestTakeDamage()
    {
        // �������� ��������� PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // ������������� ����� TakeDamage
        playerStats.TakeDamage(20);

        // �������� ������� �������� ������'�
        int actualHealth = playerStats.health;

        // ��������� ��������
        int expectedHealth = 80;

        // ��������
        Assert.AreEqual(expectedHealth, actualHealth, "������'� ������ �� ������� ����������� �������� ���� ��������� �����������.");
    }

    [Test]
    public void TestTakeDamage_NegativeHealthPrevention()
    {
        // �������� ��������� PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // ������� TakeDamage �������� 150 ����������, ���� ������'� 100
        playerStats.TakeDamage(150);

        // ��������
        Assert.AreEqual(0, playerStats.health, "������'� ������ �� ������� ���� ����������.");
    }

    [Test]
    public void TestTakeDamage_ZeroDamage()
    {
        // �������� ��������� PlayerStats
        PlayerStats playerStats = player.GetComponent<PlayerStats>();

        // ��������� ����������� �������� ������'�:
        int initialHealt = playerStats.health;

        // ��������� �����������
        playerStats.TakeDamage(0);

        // �������� �������� ������'�
        Assert.AreEqual(initialHealt, playerStats.health, "������'� ������ ������� ���������� ��������.");
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
        // ��������� ��'���� ������ �� ������
        cameraObject = new GameObject();
        playerObject = new GameObject();
    }
}