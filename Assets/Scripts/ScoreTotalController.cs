using UnityEngine;
using UnityEngine.UI;

public class ScoreTotalController : MonoBehaviour
{
    public CheckPointScore cpScore; // reference to the Time Score script
    int t; // Number for the Time Score
    public BlockScore blockScore; // reference to the Block Score script
    int b; // number for the Block Score
    public Text totalScoreText; // reference to the Total Score text
    int ts; // number for the Total Score

    // need to import current time from CheckPointScore and tostring it (time to zero)

    private void Start()
    {
        t = cpScore.cpScoreTotal; // set the value of t to the value of the Time Score in the Time Score Script
        b = blockScore.scoreTotal;  // set the value of b to the value of the Block Score in the Time Score Script
        ts = t + b; // set the value of ts to the t + b values
        // string x = one.ToString() + two.ToString() + three.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        totalScoreText.text = ts.ToString(); // et the total score text to the values of time score plus block score and output them in a readable ToString format
        // totalScoreText.text = totalScoreText.ToString();
    }
}
