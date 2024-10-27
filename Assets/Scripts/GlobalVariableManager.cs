public class GlobalVariableManager
{
    private static bool contrastOrNoContrastGlobal;

    public bool GetContrastStatus()
    {
        return contrastOrNoContrastGlobal;
    }

    public void SetContrastStatus(bool contrast)
    {
        contrastOrNoContrastGlobal = contrast;
    }
}
