using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinamicMusic : MonoBehaviour
{
    ButtonManager bm;


    enum AudioPist
    {
        BOUTIQUE_FERMEE_FINALE,
        BASE_DEUX8CLIENTS,
        CHMAPI,
        DEMON_01,
        DEMON_02,
        MINOTAUR,
        NYMPHE,
        NYMPHE_03,
        PUMPKIN_01,
        PUMPKIN_02,
        SKELETON_01,
        SKELETON_02,
        MAX,
    }

    public AK.Wwise.Event playAll;
    public AK.Wwise.Event[] Mute;
    public AK.Wwise.Event[] UnMute;
    bool[] EventTracker;

    private void Start()
    {
        EventTracker = new bool[(int)AudioPist.MAX];
        

        bm = GetComponent<ButtonManager>();


        MuteAll();
        playAll.Post(gameObject);
        Play((int)AudioPist.BOUTIQUE_FERMEE_FINALE);
    }

    public void OnClienChange()
    {
        MuteAll();
        ResetEventTracker();

        if (bm.CustomerTab.Count == 0)
        {
            Play((int)AudioPist.BOUTIQUE_FERMEE_FINALE);
        }
        else
        {
            Play((int)AudioPist.BASE_DEUX8CLIENTS);
        }

        for (int i = 0; i < bm.CustomerTab.Count; i++)
        {
            if (bm.CustomerTab[i].Race != RACE.RACENB)
            {
                switch (bm.CustomerTab[i].Race)
                {
                    case RACE.PUMPKIN:
                        if (!EventTracker[(int)AudioPist.PUMPKIN_01])
                        {
                            EventTracker[(int)AudioPist.PUMPKIN_01] = true;
                            Play((int)AudioPist.PUMPKIN_01);
                        }
                        else
                        {
                            MuteOne((int)AudioPist.PUMPKIN_01);
                            Play((int)AudioPist.PUMPKIN_02);
                        }
                        break;
                    case RACE.DEVIL:
                        if (!EventTracker[(int)AudioPist.DEMON_01])
                        {
                            EventTracker[(int)AudioPist.DEMON_01] = true;
                            Play((int)AudioPist.DEMON_01);
                        }
                        else
                        {
                            MuteOne((int)AudioPist.DEMON_01);
                            Play((int)AudioPist.DEMON_02);
                        }
                        break;
                    case RACE.SKELETON:
                        if (!EventTracker[(int)AudioPist.SKELETON_01])
                        {
                            EventTracker[(int)AudioPist.SKELETON_01] = true;
                            Play((int)AudioPist.SKELETON_01);
                        }
                        else
                        {
                            MuteOne((int)AudioPist.SKELETON_01);
                            Play((int)AudioPist.SKELETON_02);
                        }
                        break;
                    case RACE.RACENB:
                        break;
                    default:
                        break;
                }
            }
            else if (bm.CustomerTab[i].hero != HERO.HERONB)
            {
                switch (bm.CustomerTab[i].hero)
                {
                    case HERO.MERCHANT:
                        if (!EventTracker[(int)AudioPist.MINOTAUR])
                        {
                            EventTracker[(int)AudioPist.MINOTAUR] = true;
                            Play((int)AudioPist.MINOTAUR);
                        }
                        break;
                    case HERO.WARIOR:

                        break;
                    case HERO.SUCCUBUS:
                        if (!EventTracker[(int)AudioPist.NYMPHE])
                        {
                            EventTracker[(int)AudioPist.NYMPHE] = true;
                            Play((int)AudioPist.NYMPHE);
                        }
                        break;
                    case HERO.HERONB:

                        break;
                    default:
                        break;
                }
            }
        }
    }


    private void OnDestroy()
    {
        playAll.Stop(gameObject);
    }

    void MuteAll()
    {
        for (int i = 0; i < Mute.Length; i++)
        {
            Mute[i].Post(gameObject);
        }
    }

    void MuteOne(int _index)
    {
        Mute[_index].Post(gameObject);
    }
    void Play(int _index)
    {
        Mute[_index].Stop(gameObject);
        UnMute[_index].Post(gameObject);
    }

    private void ResetEventTracker()
    {
        for (int i = 0; i < EventTracker.Length; i++)
        {
            EventTracker[i] = false;
        }
    }

}
