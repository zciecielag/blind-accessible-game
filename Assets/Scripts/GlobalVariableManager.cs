public class GlobalVariableManager
{
    private static bool contrastOrNoContrastGlobal;
    private static float generalVolume = 0.1f;
    private static float narratorVolume;

    public bool GetContrastStatus()
    {
        return contrastOrNoContrastGlobal;
    }

    public void SetContrastStatus(bool contrast)
    {
        contrastOrNoContrastGlobal = contrast;
    }

    public float GetGeneralVolume()
    {
        return generalVolume;
    }

    public void SetGeneralVolume(float volume)
    {
        generalVolume = volume;
    }

    public float GetNarratorVolume()
    {
        return narratorVolume;
    }

    public void SetNarratorVolume(float volume)
    {
        narratorVolume = volume;
    }
}
