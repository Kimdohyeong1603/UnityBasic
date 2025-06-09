using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI Image�� ����ϱ� ���� �߰�

public class GachaSystem : MonoBehaviour
{
    // 1. List�� ����Ͽ� ĳ���͵��� ��� ������ ����� ���ô�.
    [System.Serializable] // Unity �����Ϳ��� �� �� �ֵ��� ����ȭ
    public class CharacterInfo
    {
        public string characterName;
        public Sprite characterSprite; // ĳ���� �̹��� (Sprite)
    }

    public List<CharacterInfo> characterPool = new List<CharacterInfo>();

    // UI ��¿� Image �迭
    public Image[] resultImages = new Image[10]; // 10���� Image ������Ʈ�� ������ �迭

    void Awake()
    {
        // ���� ĳ���� �������� characterPool�� �߰�
        // �����Ϳ��� ���� �Ҵ��ϴ� ���� �Ϲ���������, �ڵ忡���� �ʱ�ȭ ����
        // ����: �ڵ忡�� ĳ���� ���� �߰� (���� ���� �����Ϳ��� �巡�� �� ������� �Ҵ�)
        // characterPool.Add(new CharacterInfo { characterName = "Warrior A", characterSprite = Resources.Load<Sprite>("WarriorASprite") });
        // characterPool.Add(new CharacterInfo { characterName = "Mage B", characterSprite = Resources.Load<Sprite>("MageBSprite") });
        // ... (��� ĳ���Ϳ� ����)

        // �ʱ�ȭ �� ��� ��� �̹����� ���ϴ�.
        ClearResultImages();
    }

    CharacterInfo DrawSingleCharacter()
    {
        if (characterPool.Count == 0)
        {
            Debug.LogError("ĳ���� Ǯ�� ����ֽ��ϴ�. �̱⸦ ������ �� �����ϴ�.");
            return null; // ĳ���� ������ ������ ��ȯ
        }

        // List���� ������ �ε����� �����Ͽ� ĳ���͸� �̽��ϴ�.
        int randomIndex = Random.Range(0, characterPool.Count);
        CharacterInfo drawnCharacter = characterPool[randomIndex];

        return drawnCharacter;
    }


    public void PerformTenPullGachaAndDisplay() // public���� �����Ͽ� ��ư �̺�Ʈ�� ���� ����
    {
        Debug.Log("\n--- 10���� �̱� ���� ---");

        // ���� ��� �ʱ�ȭ
        ClearResultImages();

        List<CharacterInfo> pullResults = new List<CharacterInfo>();

        for (int i = 0; i < 10; i++)
        {
            CharacterInfo result = DrawSingleCharacter();
            if (result != null)
            {
                pullResults.Add(result);
                Debug.Log($"[{i + 1}��° �̱�] ���: {result.characterName}");
            }
            else
            {
                Debug.LogWarning($"[{i + 1}��° �̱�] ĳ���͸� ���� ���߽��ϴ�.");
                pullResults.Add(null); // null�� �߰��Ͽ� �� ������ ǥ���� �� �ֵ���
            }
        }

        // ����� 5x2 �迭 ���·� UI Image�� ���
        for (int i = 0; i < pullResults.Count; i++)
        {
            if (i < resultImages.Length && resultImages[i] != null) // �迭 �ε��� ���� Ȯ�� �� null üũ
            {
                if (pullResults[i] != null && pullResults[i].characterSprite != null)
                {
                    resultImages[i].sprite = pullResults[i].characterSprite; // Image ������Ʈ�� sprite ����
                    resultImages[i].SetNativeSize(); // ���� �̹��� ũ��� ���� (���� ����)
                    resultImages[i].color = Color.white; // �̹����� �����ϰ� ���̴� ��� ���
                }
                else
                {
                    // ���� ĳ���Ͱ� ���ų� �̹����� ���� ���, �̹����� ���ϴ�.
                    resultImages[i].sprite = null;
                    resultImages[i].color = new Color(1, 1, 1, 0); // ������ �����ϰ� ����
                }
            }
            else
            {
                Debug.LogWarning($"resultImages �迭�� {i} �ε����� ���ų� null�Դϴ�. UI ������ Ȯ���ϼ���.");
            }
        }

        Debug.Log("--- 10���� �̱� ���� ---");
    }

    void ClearResultImages()
    {
        foreach (Image imageElement in resultImages)
        {
            if (imageElement != null)
            {
                imageElement.sprite = null; // ��������Ʈ ����
                imageElement.color = new Color(1, 1, 1, 0); // ������ �����ϰ� �����Ͽ� ������ �ʰ� ��
            }
        }
    }
}