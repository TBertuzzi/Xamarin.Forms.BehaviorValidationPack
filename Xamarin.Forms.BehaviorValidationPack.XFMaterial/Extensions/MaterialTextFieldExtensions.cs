using System;
using XF.Material.Forms.UI;


public static class MaterialTextFieldExtensions
{

    public static string ValidatedText(this MaterialTextField materialTextField)
    {
        return materialTextField?.Text ?? string.Empty;
    }
}

