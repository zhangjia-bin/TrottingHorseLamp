using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarkUI : MonoBehaviour
{
    List<Image> ima = new List<Image>();
    public Button but2;
    public Button but;
    int index;
    private void Awake()
    {
        GameObject[] games = GameObject.FindGameObjectsWithTag("1");
        for (int i = 0; i < games.Length; i++)
        {
            ima.Add(games[i].GetComponent<Image>());
            //把图片放入抽奖槽
            ima[i].GetComponent<Image>().sprite = Resources.Load<Sprite>((i + 1).ToString());
        }

    }
    void Start()
    {
        //五连抽
        but.onClick.AddListener(() =>
        {
            StartCoroutine(Move1());
        });
        //单抽
        but2.onClick.AddListener(() =>
        {
            StartCoroutine(Move());
        });
    }

    IEnumerator Move1()
    {

        for (int i = 0; i < 5; i++)
        {
            yield return StartCoroutine(Move());
            yield return new WaitForSeconds(1f);
        }
        //yield return null;
    }
    IEnumerator Move()
    {
         index = Random.Range(0, 14);
        for (int i = 0; i < ima.Count; i++)
        {
            //time = Mathf.Lerp(0.04f, 0.05f,0.05f*i);
            //Debug.Log("====now time====="+time);
            //改变颜色
            for (int j = 0; j < ima.Count; j++)
            {
                ima[j].color = Color.white;
            }
            ima[i].color = Color.red;
            yield return new WaitForSeconds(0.05f);

        }
        for (int i = 0; i < ima.Count; i++)
        {
            //time = Mathf.Lerp(0.05f, 0.065f, 0.05f * i);
            // Debug.Log("====now time=====" + time);
            //改变颜色
            for (int j = 0; j < ima.Count; j++)
            {
                ima[j].color = Color.white;
            }
            ima[i].color = Color.red;
            yield return new WaitForSeconds(0.05f);

        }
        for (int i = 0; i < ima.Count; i++)
        {
            //time = Mathf.Lerp(0.065f, 0.08f, 0.05f * i);
            //Debug.Log("====now time=====" + time);
            //改变颜色
            for (int j = 0; j < ima.Count; j++)
            {
                ima[j].color = Color.white;
            }
            ima[i].color = Color.red;
            yield return new WaitForSeconds(0.05f);

        }

       
        for (int i = 0; i < index; i++)
        {

            //改变颜色
            for (int j = 0; j < ima.Count; j++)
            {
                ima[j].color = Color.white;
            }
            ima[i].color = Color.red;
            yield return new WaitForSeconds(0.05f);

        }

        yield return new WaitForSeconds(1f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
