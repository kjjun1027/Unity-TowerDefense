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
                    Console.WriteLine("스크립트에 Start 메서드가 없습니다.");
                }
            }
            else
            {
                Console.WriteLine("해당하는 이름의 스크립트가 없습니다.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("스크립트 실행 중 오류 발생: " + ex.Message);
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