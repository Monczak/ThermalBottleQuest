using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermosParticleGenerator : MonoBehaviour
{
    public ObjectPooler pooler;
    public Canvas parentCanvas;

    public int initialParticleCount;
    public float interval;
    public float intervalJitter;

    public int maxParticleBatchSize;

    public float xMargin, yMargin;
    public float killPosMargin;

    public float minX, maxX, yPos;

    private float lastParticleTime = 0;


    private void Awake()
    {
        pooler = GetComponent<ObjectPooler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        minX = GameManager.Instance.mainCamera.ViewportToWorldPoint(new Vector3(0, 0, -10)).x - xMargin;
        maxX = GameManager.Instance.mainCamera.ViewportToWorldPoint(new Vector3(1, 0, -10)).x + xMargin;

        yPos = GameManager.Instance.mainCamera.ViewportToWorldPoint(new Vector3(0, 0, -10)).y - yMargin;

        for (int i = 0; i < initialParticleCount; i++)
            CreateParticle();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - lastParticleTime > interval)
        {
            int limit = Random.Range(1, maxParticleBatchSize);
            for (int i = 0; i < limit; i++)
                CreateParticle();
            lastParticleTime = Time.time + intervalJitter * (Random.value * 2 - 1);
        }
    }

    void CreateParticle()
    {
        GameObject obj = pooler.GetPooledObject();
        if (obj != null)
        {
            ThermosParticle particle = obj.GetComponent<ThermosParticle>();
            particle.transform.position = new Vector2(Random.Range(minX, maxX), yPos);
            particle.killPos = yPos - killPosMargin;

            particle.SetupMovement();
            particle.gameObject.SetActive(true);
        }
       
    }
}
