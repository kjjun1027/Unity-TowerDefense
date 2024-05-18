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

    private SceneManager() { }

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
    public void Start()
    {
        LoadScript("TileScene");
    }
    public void LoadScript(string scriptName)
    {
        currentScene = scriptName;
        try
        {
            Type type = Type.GetType(scriptName);
            if (type != null)
            {
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
    public void LoadTileScene()
    {
        LoadScript("TileScene");
    }
    public void LoadGameScene()
    {
        LoadScript("GameScene");
    }
    public void LoadOverScene()
    {
        LoadScript("OverScene");
    }
    public string GetCurrentScene()
    {
        return currentScene;
    }
}