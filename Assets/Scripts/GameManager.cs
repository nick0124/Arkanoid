using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball ballPrefab;
    [SerializeField] private Transform ballContainer;
    public int ballsCount;
    [SerializeField] private Transform blocksContainer;
    public int blocksCount;

    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text pointsText;

    [SerializeField] private int lives;
    private int points;

    // Start is called before the first frame update
    void Start()
    {
        Ball ball = Instantiate(this.ballPrefab, this.ballContainer.position, Quaternion.identity, this.ballContainer);
        ball.gameManager = this;

        blocksCount = this.blocksContainer.childCount;
        ballsCount = this.ballContainer.childCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateLives()
    {

    }

    public void UpdateScore(int pointsToScore)
    {
        this.points += pointsToScore;
    }

    public void UpdateBlocksCount()
    {
        this.blocksCount--;
        if (this.blocksCount == 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void UpdateBallsCount()
    {
        this.ballsCount--;
        if (this.ballsCount == 0)
        {
            lives--;

            this.ballsCount = 1;
            Ball ball = Instantiate(this.ballPrefab, this.ballContainer.position, Quaternion.identity, this.ballContainer);
            ball.gameManager = this;
        }

        if (this.lives == 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
