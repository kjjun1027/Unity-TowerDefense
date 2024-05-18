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

    // 외부에서 생성자 호출을 막기 위해 private으로 설정합니다.
    private SceneManager() { }

    // 싱글톤 인스턴스를 반환하는 프로퍼티입니다.
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

    // 시작할 때 TileScene을 시작합니다.
    public void Start()
    {
        LoadScript("TileScene");
    }
    public void LoadScript(string scriptName)
    {
        currentScene = scriptName;
        try
        {
            // 스크립트 이름으로부터 Type을 가져옵니다.
            Type type = Type.GetType(scriptName);
            if (type != null)
            {
                // Type으로부터 인스턴스를 생성하고 해당 스크립트를 실행합니다.
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

    // TileScene을 로드합니다.
    public void LoadTileScene()
    {
        LoadScript("TileScene");
    }

    // GameScene을 로드합니다.
    public void LoadGameScene()
    {
        LoadScript("GameScene");
    }

    // OverScene을 로드합니다.
    public void LoadOverScene()
    {
        LoadScript("OverScene");
    }

    // 현재 Scene의 이름을 반환합니다.
    public string GetCurrentScene()
    {
        return currentScene;
    }
}