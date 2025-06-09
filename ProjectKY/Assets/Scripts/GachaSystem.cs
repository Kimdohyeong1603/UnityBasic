using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI Image를 사용하기 위해 추가

public class GachaSystem : MonoBehaviour
{
    // 1. List를 사용하여 캐릭터들이 담긴 집합을 만들어 봅시다.
    [System.Serializable] // Unity 에디터에서 볼 수 있도록 직렬화
    public class CharacterInfo
    {
        public string characterName;
        public Sprite characterSprite; // 캐릭터 이미지 (Sprite)
    }

    public List<CharacterInfo> characterPool = new List<CharacterInfo>();

    // UI 출력용 Image 배열
    public Image[] resultImages = new Image[10]; // 10개의 Image 컴포넌트를 연결할 배열

    void Awake()
    {
        // 예시 캐릭터 정보들을 characterPool에 추가
        // 에디터에서 직접 할당하는 것이 일반적이지만, 코드에서도 초기화 가능
        // 예시: 코드에서 캐릭터 정보 추가 (실제 사용시 에디터에서 드래그 앤 드롭으로 할당)
        // characterPool.Add(new CharacterInfo { characterName = "Warrior A", characterSprite = Resources.Load<Sprite>("WarriorASprite") });
        // characterPool.Add(new CharacterInfo { characterName = "Mage B", characterSprite = Resources.Load<Sprite>("MageBSprite") });
        // ... (모든 캐릭터에 대해)

        // 초기화 시 모든 결과 이미지를 비웁니다.
        ClearResultImages();
    }

    CharacterInfo DrawSingleCharacter()
    {
        if (characterPool.Count == 0)
        {
            Debug.LogError("캐릭터 풀이 비어있습니다. 뽑기를 진행할 수 없습니다.");
            return null; // 캐릭터 정보가 없음을 반환
        }

        // List에서 무작위 인덱스를 선택하여 캐릭터를 뽑습니다.
        int randomIndex = Random.Range(0, characterPool.Count);
        CharacterInfo drawnCharacter = characterPool[randomIndex];

        return drawnCharacter;
    }


    public void PerformTenPullGachaAndDisplay() // public으로 선언하여 버튼 이벤트에 연결 가능
    {
        Debug.Log("\n--- 10연차 뽑기 시작 ---");

        // 이전 결과 초기화
        ClearResultImages();

        List<CharacterInfo> pullResults = new List<CharacterInfo>();

        for (int i = 0; i < 10; i++)
        {
            CharacterInfo result = DrawSingleCharacter();
            if (result != null)
            {
                pullResults.Add(result);
                Debug.Log($"[{i + 1}번째 뽑기] 결과: {result.characterName}");
            }
            else
            {
                Debug.LogWarning($"[{i + 1}번째 뽑기] 캐릭터를 뽑지 못했습니다.");
                pullResults.Add(null); // null을 추가하여 빈 슬롯을 표시할 수 있도록
            }
        }

        // 결과를 5x2 배열 형태로 UI Image에 출력
        for (int i = 0; i < pullResults.Count; i++)
        {
            if (i < resultImages.Length && resultImages[i] != null) // 배열 인덱스 범위 확인 및 null 체크
            {
                if (pullResults[i] != null && pullResults[i].characterSprite != null)
                {
                    resultImages[i].sprite = pullResults[i].characterSprite; // Image 컴포넌트의 sprite 설정
                    resultImages[i].SetNativeSize(); // 원본 이미지 크기로 조정 (선택 사항)
                    resultImages[i].color = Color.white; // 이미지가 투명하게 보이는 경우 대비
                }
                else
                {
                    // 뽑힌 캐릭터가 없거나 이미지가 없는 경우, 이미지를 비웁니다.
                    resultImages[i].sprite = null;
                    resultImages[i].color = new Color(1, 1, 1, 0); // 완전히 투명하게 설정
                }
            }
            else
            {
                Debug.LogWarning($"resultImages 배열의 {i} 인덱스가 없거나 null입니다. UI 연결을 확인하세요.");
            }
        }

        Debug.Log("--- 10연차 뽑기 종료 ---");
    }

    void ClearResultImages()
    {
        foreach (Image imageElement in resultImages)
        {
            if (imageElement != null)
            {
                imageElement.sprite = null; // 스프라이트 제거
                imageElement.color = new Color(1, 1, 1, 0); // 완전히 투명하게 설정하여 보이지 않게 함
            }
        }
    }
}