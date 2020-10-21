using UnityEngine;
using UnityEngine.UI;

public class BlockScore : MonoBehaviour
{
    public int scoreTotal; // int (number) for our block score total

    public void AddScore(int scoreToAdd) // function for adding to our block score that is called from the Hit behaviour scripts
    {
        scoreTotal += scoreToAdd; // set the score total value to add the amount being given to us by the hit behaviour script, add this to the total block score
    }
}
