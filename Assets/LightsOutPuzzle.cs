using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsOutPuzzle : MonoBehaviour
{
    [SerializeField] GameObject[] lights;
    private bool[] lightStates;
    private int gridSize = 3; // change this to adjust the size of the grid
    private bool solved = false;
    public AudioSource correctSound;

    // Start is called before the first frame update
    void Start()
    {
        int numLights = gridSize * gridSize;
        lightStates = new bool[numLights];

        // Set up light states
        int numOn = 4; // change this to adjust the number of lights that start on
        for (int i = 0; i < numOn; i++)
        {
            int index = Random.Range(0, numLights);
            if (!lightStates[index])
            {
                ToggleLights(index);
            }
            else
            {
                i--;
            }
        }
    }

    public void OnLightClick(int index)
    {
        ToggleLights(index);

        // Check if puzzle is solved
        if (CheckIfPuzzleIsSolved())
        {
            if (!solved)
            {
                Debug.Log("Puzzle solved!");
                solved = true;
                correctSound.Play();
            }
        }
    }
    private void ToggleLights(int index)
    {
        if (!solved)
        {
            Debug.Log("Doing light");
            int x = index % gridSize;
            int y = index / gridSize;

            // Toggle clicked light
            lightStates[index] = !lightStates[index];
            lights[index].GetComponent<Light>().color = lightStates[index] ? Color.red : Color.green;
            MeshRenderer emissionToggle = lights[index].GetComponent<MeshRenderer>();
            if (lightStates[index]) emissionToggle.materials[0].SetColor("_EmissionColor", Color.red);
            else emissionToggle.materials[0].SetColor("_EmissionColor", Color.green);
            //emissionToggle.materials[0].DisableKeyword("_EMISSION");

            // Toggle adjacent lights
            if (x > 0)
            {
                int adjIndex = index - 1;
                lightStates[adjIndex] = !lightStates[adjIndex];
                emissionToggle = lights[adjIndex].GetComponent<MeshRenderer>();
                if (lightStates[adjIndex]) emissionToggle.materials[0].SetColor("_EmissionColor", Color.red);
                else emissionToggle.materials[0].SetColor("_EmissionColor", Color.green);
            }
            if (x < gridSize - 1)
            {
                int adjIndex = index + 1;
                lightStates[adjIndex] = !lightStates[adjIndex];
                emissionToggle = lights[adjIndex].GetComponent<MeshRenderer>();
                if (lightStates[adjIndex]) emissionToggle.materials[0].SetColor("_EmissionColor", Color.red);
                else emissionToggle.materials[0].SetColor("_EmissionColor", Color.green);
            }
            if (y > 0)
            {
                int adjIndex = index - gridSize;
                lightStates[adjIndex] = !lightStates[adjIndex];
                emissionToggle = lights[adjIndex].GetComponent<MeshRenderer>();
                if (lightStates[adjIndex]) emissionToggle.materials[0].SetColor("_EmissionColor", Color.red);
                else emissionToggle.materials[0].SetColor("_EmissionColor", Color.green);
            }
            if (y < gridSize - 1)
            {
                int adjIndex = index + gridSize;
                lightStates[adjIndex] = !lightStates[adjIndex];
                emissionToggle = lights[adjIndex].GetComponent<MeshRenderer>();
                if (lightStates[adjIndex]) emissionToggle.materials[0].SetColor("_EmissionColor", Color.red);
                else emissionToggle.materials[0].SetColor("_EmissionColor", Color.green);
            }
        }
    }

    private bool CheckIfPuzzleIsSolved()
    {
        foreach (bool state in lightStates)
        {
            if (state)
            {
                return false;
            }
        }

        return true;
    }
}
