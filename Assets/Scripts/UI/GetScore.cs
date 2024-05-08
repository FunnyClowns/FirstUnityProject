using TMPro;
using UnityEngine;

public class GetScore : MonoBehaviour
{
    public TextMeshProUGUI txtSub;
    public ScoreCounter scoreCounter;

    private int score;

    public void GameLose(){
        score = scoreCounter.getScore();
        showScore();
    }

    private void showScore(){
        this.gameObject.SetActive(true);
        txtSub.text = "Your score is : " + score.ToString();
    }
}
