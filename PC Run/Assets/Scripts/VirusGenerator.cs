using UnityEngine;

public class VirusGenerator : MonoBehaviour
{
    public GameObject virus;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    // Start is called before the first frame update
    void Awake()
    {
        currentSpeed = MinSpeed;
        generateVirus();
    }

    public void GenerateNextVirusWithGap() {
        float randomWait = Random.Range(0.1f, 1.2f);
        Invoke("generateVirus", randomWait);
    }

    public void generateVirus() {
        GameObject VirusIns =  Instantiate(virus, transform.position, transform.rotation);

        VirusIns.GetComponent<VirusScript>().virusGenerator =  this;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSpeed < MaxSpeed) {
            currentSpeed += SpeedMultiplier;
        }
    }
}
