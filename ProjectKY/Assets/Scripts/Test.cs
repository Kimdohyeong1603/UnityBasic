using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public string myName = "김도형";
    public int age = 28;
    public float height = 175.3f;
    public bool isGamePlanner = true;
    public string mbti = "INTP";
    public char gender = 'M';

    void Start()
    {
        PrintMyInfo();
    }

    void PrintMyInfo()
    {
        Debug.Log("이름: " + myName);
        Debug.Log("나이: " + age);
        Debug.Log("키: " + height + "cm");
        Debug.Log("게임 기획자인가요?: " + isGamePlanner);
        Debug.Log("MBTI: " + mbti);
    }
}
