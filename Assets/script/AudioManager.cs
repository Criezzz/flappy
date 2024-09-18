using UnityEngine.Audio;
using UnityEngine;
using Unity.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }
    public Sound[] sounds;

    private void Awake()
    {
        instance = this;
       foreach (var x in sounds){
            x.source = gameObject.AddComponent<AudioSource>();
            x.source.clip = x.clip;
            x.source.volume = x.volume;
            x.source.pitch = x.pitch;  
            x.source.loop = x.loop;
            x.source.name = x.name;

        }
    }
  
    public void playSound(string name)
    {
        bool check = false;
        foreach (var x in sounds)
        {
            if (x.name == name)
            {
                check = true;
                x.source.Play();
                Debug.Log("Play " + name);
            }
        }
        if (!check)
        {
            Debug.Log("sound " + name + "not found");
        }
    }
    public void stopSound(string name)
    {
        bool check = false;
        foreach (var x in sounds)
        {
            if (x.name == name)
            {
                check = true;
                x.source.Stop();
            }
        }
        if (!check)
        {
            Debug.Log("sound " + name + "not found");
        }
    }

}
