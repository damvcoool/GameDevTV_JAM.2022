using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    [SerializeField] Vector3 MoveDirection;
    [SerializeField] bool move = true;

    private void OnEnable()
    {
        Time.timeScale = 1;
        move = true;
    }
    void Update()
    {
        if(move)
            this.transform.Translate(MoveDirection * Time.deltaTime);

        if(this.transform.localPosition.y >= 500)
        {
            SceneManager.LoadScene(1);
            Debug.Log("Load Scene");
        }
    }
}
