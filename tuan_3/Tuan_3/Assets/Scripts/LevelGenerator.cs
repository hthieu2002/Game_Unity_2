using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour
{
    public Vector2Int size;
    public Vector2 offset;
    public GameObject brickPrefab;
    public Gradient gradient;

    private void Awake()
    {
        for (int i = 0; i < size.x; i++)
        {
            for (int j = 0; j < size.y; j++)
            {
                GameObject newBrick = Instantiate(brickPrefab, transform);
                newBrick.transform.position = transform.position + new Vector3((float)((size.x - 1) * 5f - i) * offset.x, j * offset.y, 0);
                newBrick.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j / (size.y - 1));

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}