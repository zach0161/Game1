using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{

    public List<string> inventory = new List<string>();
    public GameObject morseAlphabet;
    public GameObject symptomBook;
    List<string> diseases;
    public Timer timer;
    public PostProcessVolume volume;
    LensDistortion distortion;
    bool nauseous = false;
    public Camera mainCamera;
    public GameObject menuCamera;
    public Movement movement;
    public AudioClip breathing;
    public List<AudioClip> whistles = new List<AudioClip>();
    AudioSource source;
    public AudioClip knocking;
    public string pickedDisease;


    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        volume.profile.TryGetSettings(out distortion);
        // a random disease gets picked and its symptoms gets activated
        diseases = new List<string> { "ptsd", "adhd", "depression", "anxiety" };
        string disease = diseasePicker();
        switch (disease)
        {
            case "ptsd":
                pickedDisease = "ptsd";
                StartCoroutine(ptsd(30f));
                break;
            case "adhd":
                pickedDisease = "adhd";
                StartCoroutine(adhd(30f));
                break;
            case "depression":
                pickedDisease = "depression";
                StartCoroutine(depression(30f));
                break;
            case "anxiety":
                pickedDisease = "anxiety";
                StartCoroutine(anxiety(30f));
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("r"))
        {
            if (inventory.Contains("Alphabet"))
            {
                if (morseAlphabet.activeSelf)
                {
                    morseAlphabet.SetActive(false);
                }
                else
                {
                    morseAlphabet.SetActive(true);
                }

            }
        }

        if (Input.GetKeyDown("f"))
        {
            if (inventory.Contains("symptomBook") && !symptomBook.activeSelf)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                menuCamera.SetActive(true);
                symptomBook.SetActive(true);
            }
        }


        if (nauseous)
        {
            // player feels nauseous

            // Random values close to last random value
            float intensityValue = Mathf.PingPong(Time.time * 3, 30) + 30;

            distortion.intensity.value = intensityValue;
        }

        
        if (source.clip == breathing && !source.isPlaying) source.volume = 1f;

    }

    string diseasePicker()
    {
        // returns a random disease
        return diseases[Random.Range(0, diseases.Count - 1)];
    }

    IEnumerator ptsd(float delay = 0f)
    {
        if (delay != 0f)
        {
            yield return new WaitForSeconds(delay);
        }

        List<string> symptoms = new List<string>() { "hallucinations", "hyperventilation" };
        string symptom = symptomPicker(symptoms);

        switch (symptom)
        {
            case "hallucinations":
                StartCoroutine(hallucinations());
                break;

            case "hyperventilation":
                StartCoroutine(breathe());
                break;
        }

        float maxDelay = Mathf.Log(timer.time) * Mathf.Ceil(timer.time / 100);
        StartCoroutine(ptsd(Random.Range(8 / 10 * maxDelay, maxDelay)));
        yield return null;

    }

    IEnumerator adhd(float delay = 0f)
    {
        if (delay != 0f)
        {
            yield return new WaitForSeconds(delay);
        }

        List<string> symptoms = new List<string>() { "attentionProblems", "whistling" };
        string symptom = symptomPicker(symptoms);

        switch (symptom)
        {
            case "attentionProblems":
                StartCoroutine(attentionProblems());
                break;

            case "whistling":
                whistling();
                break;
        }

        float maxDelay = Mathf.Log(timer.time) * Mathf.Ceil(timer.time / 100);
        StartCoroutine(adhd(Random.Range(8 / 10 * maxDelay, maxDelay)));
        yield return null;
    }

    IEnumerator depression(float delay = 0f)
    {
        if (delay != 0f)
        {
            yield return new WaitForSeconds(delay);
        }

        List<string> symptoms = new List<string>() { "slowDown", "turnDownLights" };
        string symptom = symptomPicker(symptoms);

        switch (symptom)
        {
            case "slowDown":
                StartCoroutine(slowDown());
                break;

            case "turnDownLights":
                StartCoroutine(turnDownLights());
                break;
        }

        float maxDelay = Mathf.Log(timer.time) * Mathf.Ceil(timer.time / 100);
        StartCoroutine(depression(Random.Range(8 / 10 * maxDelay, maxDelay)));
        yield return null;
    }

    IEnumerator anxiety(float delay = 0f)
    {
        if (delay != 0f)
        {
            yield return new WaitForSeconds(delay);
        }

        List<string> symptoms = new List<string>() { "shake", "hyperventilation", "nausea" };
        string symptom = symptomPicker(symptoms);

        switch (symptom)
        {
            case "shake":
                StartCoroutine(shake(10f));
                break;
            case "hyperventilation":
                StartCoroutine(breathe());
                break;
            case "nausea":
                StartCoroutine(nausea());
                break;
        }

        float maxDelay = Mathf.Log(timer.time) * Mathf.Ceil(timer.time / 100);
        StartCoroutine(anxiety(Random.Range(8 / 10 * maxDelay, maxDelay)));
        yield return null;

    }

    string symptomPicker(List<string> symptoms)
    {
        // returns a random symptom
        return symptoms[Random.Range(0, symptoms.Count)];
    }



    /* 
       Diseases and symptoms:
       PTSD: Hallucinations, hyperventilation
       ADHD: attention problems (blurry vision), spontaneous whistling
       Depression: slow down, dark lights
       Anxiety: Shake, hyperventilation, nausea

    */
    IEnumerator hallucinations()
    {
        //Knocking sound
        source.clip = knocking;
        source.Play();
        yield return null;

    }

    IEnumerator breathe()
    {
        // fast breathing
        source.clip = breathing;
        // breathing sound clip is extremely loud
        source.volume = 0.6f;
        source.Play();
        yield return null;
    }

    IEnumerator attentionProblems()
    {
        // Blurry camera effect
        DepthOfField depthOfField;
        volume.profile.TryGetSettings(out depthOfField);
        depthOfField.active = true;
        yield return new WaitForSeconds(5f);
        depthOfField.active = false;
    }

    void whistling()
    {
        // random whistling
        source.clip = whistles[Random.Range(0, whistles.Count - 1)];
        source.Play();
    }

    IEnumerator slowDown()
    {
        //slowing down player
        float originalSpeed = movement.runSpeed;
        movement.runSpeed = 10f;
        yield return new WaitForSeconds(5f);
        movement.runSpeed = originalSpeed;
    }

    IEnumerator turnDownLights()
    {
        //makes the room darker
        AutoExposure autoExposure;
        volume.profile.TryGetSettings(out autoExposure);
        // changing exposure compensation
        float originalExposure = autoExposure.keyValue.value;
        autoExposure.keyValue.value = 0.1f;
        yield return new WaitForSeconds(5f);
        autoExposure.keyValue.value = originalExposure;
    }

    IEnumerator shake(float magnitude)
    {
        //camera shake
        float time = 5f;
        float elapsedTime = 0f;
        Vector3 originalPos = mainCamera.transform.localPosition;

        while (elapsedTime < time)
        {
            float xOffset = Random.Range(-0.005f, 0.005f) * magnitude;
            float yOffset = Random.Range(-0.005f, 0.005f) * magnitude;

            mainCamera.transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.localPosition = originalPos;
    }

    IEnumerator nausea()
    {
        // warps the screen randomly to create a nausea like effect
        ChromaticAberration chromaticAberration;
        volume.profile.TryGetSettings(out chromaticAberration);
        chromaticAberration.intensity.value = 1f;
        nauseous = true;
        yield return new WaitForSeconds(5f);
        chromaticAberration.intensity.value = 0f;
        nauseous = false;
        distortion.intensity.value = 0f;
    }
    
    void OnTriggerEnter(Collider other) {
        // checks for collision with the end which results in completing the game
        if (other.CompareTag("End")) {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }
}
