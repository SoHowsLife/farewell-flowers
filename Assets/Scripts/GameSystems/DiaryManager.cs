using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameSystems
{
    public class DiaryManager : MonoBehaviour
    {
        [SerializeField]
        List<Sprite> sprites;
        int page = 0;

        [SerializeField]
        GameObject diary;
        [SerializeField]
        Image leftPage;
        [SerializeField]
        Image rightPage;
        [SerializeField]
        TextMeshProUGUI leftPageNum;
        [SerializeField]
        TextMeshProUGUI rightPageNum;


        public void ToggleDiaryDisplay()
        {
            if (diary.activeSelf) HideDiary();
            else ShowDiary();
        }
        void HideDiary()
        {
            diary.SetActive(false);
        }
        void ShowDiary()
        {
            diary.SetActive(true);
            TurnToPage(0);
        }

        public void TurnPage(int dir)
        {
            TurnToPage(page + dir);
        }
        public void TurnToPage(int page)
        {
            this.page = Mathf.Clamp(page, 0, sprites.Count / 2 - 1);
            leftPageNum.text = (this.page * 2 + 1).ToString();
            rightPageNum.text = (this.page * 2 + 2).ToString();
            leftPage.sprite = sprites[this.page * 2];
            rightPage.sprite = sprites[this.page * 2 + 1];
        }

        public void UpdatePage(int index, Sprite sprite)
        {
            sprites[index] = sprite;
        }
    }
}