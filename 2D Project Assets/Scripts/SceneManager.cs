using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    private static SceneManager instance;
    private string currentScene;

    // �ܺο��� ������ ȣ���� ���� ���� private���� �����մϴ�.
    private SceneManager() { }

    // �̱��� �ν��Ͻ��� ��ȯ�ϴ� ������Ƽ�Դϴ�.
    public static SceneManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SceneManager();
            }
            return instance;
        }
    }

    // ������ �� TileScene�� �����մϴ�.
    public void Start()
    {
        LoadScript("TileScene");
    }
    public void LoadScript(string scriptName)
    {
        currentScene = scriptName;
        try
        {
            // ��ũ��Ʈ �̸����κ��� Type�� �����ɴϴ�.
            Type type = Type.GetType(scriptName);
            if (type != null)
            {
                // Type���κ��� �ν��Ͻ��� �����ϰ� �ش� ��ũ��Ʈ�� �����մϴ�.
                MethodInfo method = type.GetMethod("Start");
                if (method != null)
                {
                    object instance = Activator.CreateInstance(type);
                    method.Invoke(instance, null);
                }
                else
                {
                    Console.WriteLine("��ũ��Ʈ�� Start �޼��尡 �����ϴ�.");
                }
            }
            else
            {
                Console.WriteLine("�ش��ϴ� �̸��� ��ũ��Ʈ�� �����ϴ�.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("��ũ��Ʈ ���� �� ���� �߻�: " + ex.Message);
        }
    }

    // TileScene�� �ε��մϴ�.
    public void LoadTileScene()
    {
        LoadScript("TileScene");
    }

    // GameScene�� �ε��մϴ�.
    public void LoadGameScene()
    {
        LoadScript("GameScene");
    }

    // OverScene�� �ε��մϴ�.
    public void LoadOverScene()
    {
        LoadScript("OverScene");
    }

    // ���� Scene�� �̸��� ��ȯ�մϴ�.
    public string GetCurrentScene()
    {
        return currentScene;
    }
}