using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetManager : MonoBehaviour
{
    [SerializeField]
    private int hunger;

    [SerializeField]
    private int happiness;

    [SerializeField]
    private int cleanliness;

    [SerializeField]
    private int loved;

    // Start is called before the first frame update
    void Start()
    {
        updateStats();
        InvokeRepeating("statDecrease", 5, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void statDecrease()
    {
        if(hunger - 5 < 0)
        {
            hunger = 0;

        } else
        {
            hunger -= 5;
        }

        if (happiness - 3 < 0)
        {
            happiness = 0;
        }
        else
        {
            happiness -= 3;
        }

        if (cleanliness - 4 < 0)
        {
            cleanliness = 0;
        }
        else
        {
            cleanliness -= 4;
        }

        checkForDeath();

    }

    void checkForDeath()
    {
        if(hunger <= 0 && happiness <= 0 && cleanliness <= 0)
        {
            SceneManager.LoadScene("DeathCredits");
        }
    }

    void updateStats()
    {
        if(!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 100;
            PlayerPrefs.SetInt("hunger", hunger);
        }
        else
        {
            hunger = PlayerPrefs.GetInt("hunger");
        }

        if (!PlayerPrefs.HasKey("happiness"))
        {
            happiness = 100;
            PlayerPrefs.SetInt("happiness", happiness);
        }
        else
        {
            happiness = PlayerPrefs.GetInt("happiness");
        }

        if (!PlayerPrefs.HasKey("cleanliness"))
        {
            cleanliness = 100;
            PlayerPrefs.SetInt("cleanliness", cleanliness);
        }
        else
        {
            cleanliness = PlayerPrefs.GetInt("cleanliness");
        }


        if (!PlayerPrefs.HasKey("loved"))
        {
            loved = 0;
            PlayerPrefs.SetInt("loved", loved);
        }
        else
        {
            loved = PlayerPrefs.GetInt("loved");
        }

    }

    void checkEvolution()
    {
        if(loved >= 50)
        {
           SceneManager.LoadScene("EvolveCredits");
        } 
        else
        {
            loved += 5;
        }
    }

    int checkMaxed(int stat, int increase)
    {
        if(stat + increase > 100)
        {
            return 100;
        } else
        {
            stat += increase;
            return stat;
        }
    }

    public void feedPet()
    {
        hunger = checkMaxed(hunger, 20);
        happiness = checkMaxed(happiness, 3);
        checkEvolution();
    }

    public void playWithPet()
    {
        happiness = checkMaxed(happiness, 5);
        checkEvolution();
    }

    public void bathePet()
    {
        cleanliness  = checkMaxed(cleanliness, 40);
        happiness = checkMaxed(happiness, 3);
        checkEvolution();
    }

    public int _hunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int _happiness
    {
        get { return happiness; }
        set { happiness = value; }
    }

    public int _cleanliness
    {
        get { return cleanliness; }
        set { cleanliness = value; }
    }
}
