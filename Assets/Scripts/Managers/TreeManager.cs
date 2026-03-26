using UnityEngine;
using System.Collections;

public class TreeManager : MonoBehaviour
{
    public static TreeManager instance;
    private Vector3 startingScale;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else{ Destroy(gameObject); }
    }
    void Start()
    {
        startingScale = transform.localScale;
        
    }

    public void GrowTree(float waterAmount)
    {
        if (waterAmount > 0f)
        {
            float growthFactor = waterAmount / 30f;
            Vector3 targetScale = startingScale + (Vector3.one * growthFactor);
            StartCoroutine(AnimateTreeGrowth(targetScale, 2f));
        }
    }
    IEnumerator AnimateTreeGrowth(Vector3 target,float duration)
    {
        float time = 0f;
        Vector3 initialScale = transform.localScale;
        while (time < duration)
        {
            time += Time.deltaTime;
            float percentage = time / duration;
            transform.localScale = Vector3.Lerp(initialScale, target, percentage);
            yield return null;
        }

        transform.localScale = target;
        Debug.Log("Ağaç büyüme animasyonu bitti.");
    }
}
