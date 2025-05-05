using System;
using UnityEngine;

public class Blackmail : MonoBehaviour
{
    [SerializeField] GameObject[] floatingWordPrefabs;
    [SerializeField] RectTransform floatingWordZone;

    [SerializeField] CorrectWords[] correctWordOptions;
    private CorrectWords correctWord;
    private enum CorrectWords
    {
        dog,
        grandma,
        daughter
    }

    void Start()
    {
        correctWord = correctWordOptions[UnityEngine.Random.Range(0, correctWordOptions.Length)];
        for (int i=0;i<4;i++)
        {

            int randomWord = UnityEngine.Random.Range(3, floatingWordPrefabs.Length);
            RectTransform wordRect = floatingWordPrefabs[randomWord].GetComponent<RectTransform>();
            //spawns floating words inside the zone randomly
            Vector3 spawnPoint = new Vector2(UnityEngine.Random.Range(-floatingWordZone.rect.width/2+wordRect.rect.width/2, floatingWordZone.rect.width / 2-wordRect.rect.width/2),
                UnityEngine.Random.Range(-floatingWordZone.rect.height / 2+wordRect.rect.height/2, floatingWordZone.rect.height / 2-wordRect.rect.height/2));

            spawnPoint += floatingWordZone.position;

            if (i == 0)
            {
                if (correctWord == CorrectWords.dog)
                {
                    Instantiate(floatingWordPrefabs[(int)CorrectWords.dog], spawnPoint, Quaternion.identity, floatingWordZone);
                }
                else if (correctWord == CorrectWords.grandma)
                {
                    Instantiate(floatingWordPrefabs[(int)CorrectWords.grandma], spawnPoint, Quaternion.identity, floatingWordZone);
                }
                if (correctWord == CorrectWords.daughter)
                {
                    Instantiate(floatingWordPrefabs[(int)CorrectWords.daughter], spawnPoint, Quaternion.identity, floatingWordZone);
                }
            }
            else
            {
                Instantiate(floatingWordPrefabs[randomWord],spawnPoint,Quaternion.identity, floatingWordZone);
            }
        }
    }

    public void CheckInput(string playerInput)
    {
        if (Enum.TryParse<CorrectWords>(playerInput, out CorrectWords playerWord))
        {
            if (playerWord == correctWord)
            {
                Debug.Log("Yippie!");
                GameManager.instance.WinMG();
            }
        }
    }
}
