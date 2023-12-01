using UnityEngine;

public class VirusGenerator : MonoBehaviour
{
    public GameObject virus;

    public float MinSpeed;
    public float MaxSpeed;
    public float currentSpeed;

    public float SpeedMultiplier;

    void Awake()
    {
        currentSpeed = MinSpeed;
        generateVirus();
    }

    public void GenerateVirusWithSpace() {
        float randomWait = Random.Range(0.7f, 1.5f);
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
