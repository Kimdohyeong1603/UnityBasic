using UnityEngine;

public class Star : MonoBehaviour
{
    string star;

    void Start()
    {
        Phase1();
        Phase2();
        Phase3();
        Phase4();
        Phase5();
    }

    public void Phase1()
    {
        star = "";
        for (int i = 1; i <= 5; i++)
        {
            string currentLine = "";
            for (int j = 0; j < i; j++)
            {
                currentLine += "¡Ú";
            }
            star += currentLine + "\n";
        }
        Debug.Log(star);
    }

    public void Phase2()
    {
        star = "";
        for (int i = 5; i >= 1; i--)
        {
            string currentLine = "";
            for (int j = 0; j < i; j++)
            {
                currentLine += "¡Ú";
            }
            star += currentLine + "\n";
        }
        Debug.Log(star);
    }

    public void Phase3()
    {
        star = "";
        for (int i = 1; i <= 5; i++)
        {
            string currentLine = "";
            for (int j = 0; j < i; j++)
            {
                currentLine += "¡Ú";
            }
            star += currentLine + "\n";
        }
        for (int i = 4; i >= 1; i--)
        {
            string currentLine = "";
            for (int j = 0; j < i; j++)
            {
                currentLine += "¡Ú";
            }
            star += currentLine + "\n";
        }
        Debug.Log(star);
    }

    public void Phase4()
    {
        star = "";
        int maxWidth = 5;

        for (int i = 1; i <= maxWidth; i++)
        {
            string currentLine = "";
            int numStars = i;
            int numSpaces = maxWidth - numStars;

            for (int j = 0; j < numSpaces; j++)
            {
                currentLine += " ";
            }
            for (int k = 0; k < numStars; k++)
            {
                currentLine += "¡Ú";
            }
            star += currentLine + "\n";
        }

        for (int i = maxWidth - 1; i >= 1; i--)
        {
            string currentLine = "";
            int numStars = i;
            int numSpaces = maxWidth - numStars;

            for (int j = 0; j < numSpaces; j++)
            {
                currentLine += " ";
            }
            for (int k = 0; k < numStars; k++)
            {
                currentLine += "¡Ú";
            }
            star += currentLine + "\n";
        }
        Debug.Log(star);
    }

    public void Phase5()
    {
        star = "";
        int maxStars = 11;
        int centerRow = (maxStars + 1) / 2;

        for (int i = 1; i <= centerRow; i++)
        {
            string currentLine = "";
            int numStars = (i * 2) - 1;
            int numSpaces = (maxStars - numStars) / 2;

            for (int j = 0; j < numSpaces; j++)
            {
                currentLine += " ";
            }
            for (int k = 0; k < numStars; k++)
            {
                currentLine += "¡Ú";
            }
            star += currentLine + "\n";
        }

        for (int i = centerRow - 1; i >= 1; i--)
        {
            string currentLine = "";
            int numStars = (i * 2) - 1;
            int numSpaces = (maxStars - numStars) / 2;

            for (int j = 0; j < numSpaces; j++)
            {
                currentLine += " ";
            }
            for (int k = 0; k < numStars; k++)
            {
                currentLine += "¡Ú";
            }
            star += currentLine + "\n";
        }
        Debug.Log(star);
    }
}