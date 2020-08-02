using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPalette
{
    protected string paletteName;
    public abstract Color32 GetColorByIndex(int index);
}


public class Palette
{
    public static IPalette RedGreenBlack32 { get { return new CPRedGreenBlack32(); } } 

    private class CPRedGreenBlack32 : IPalette
    {
        private Color32[] colors;
        private int colorsSize = 32;
        public CPRedGreenBlack32()
        {
            paletteName = "RedGreenBlack32";
            colors = new Color32[colorsSize];
            colors[0] = new Color32(0, 0, 0, 100);
            colors[1] = new Color32(0, 0, 0, 100);
            colors[2] = new Color32(82, 4, 0, 100);
            colors[3] = new Color32(189, 24, 0, 100);
            colors[4] = new Color32(205, 44, 8, 100);
            colors[5] = new Color32(106, 28, 8, 100);
            colors[6] = new Color32(222, 72, 16, 100);
            colors[7] = new Color32(222, 97, 49, 100);
            colors[8] = new Color32(238, 89, 24, 100);
            colors[9] = new Color32(90, 56, 32, 100);
            colors[10] = new Color32(180, 141, 106, 100);
            colors[11] = new Color32(139, 101, 65, 100);
            colors[12] = new Color32(41, 24, 8, 100);
            colors[13] = new Color32(180, 153, 115, 100);
            colors[14] = new Color32(189, 161, 115, 100);
            colors[15] = new Color32(115, 97, 65, 100);
            colors[16] = new Color32(197, 174, 131, 100);
            colors[17] = new Color32(164, 141, 98, 100);
            colors[18] = new Color32(148, 125, 82, 100);
            colors[19] = new Color32(180, 157, 115, 100);
            colors[20] = new Color32(148, 133, 98, 100);
            colors[21] = new Color32(197, 186, 148, 100);
            colors[22] = new Color32(57, 48, 16, 100);
            colors[23] = new Color32(98, 89, 57, 100);
            colors[24] = new Color32(82, 72, 32, 100);
            colors[25] = new Color32(180, 170, 131, 100);
            colors[26] = new Color32(222, 218, 189, 100);
            colors[27] = new Color32(205, 202, 164, 100);
            colors[28] = new Color32(123, 121, 65, 100);
            colors[29] = new Color32(156, 157, 106, 100);
            colors[30] = new Color32(82, 93, 16, 100);
            colors[31] = new Color32(148, 165, 90, 100);
        }

        public override Color32 GetColorByIndex(int index)
        {
            if((index < colorsSize) && (index >= 0))
            {
                return colors[index];
            }
            else
            {
                Debug.LogError("Wrong color index in GetColorByIndex() call, in palette: " 
                    + paletteName + ".\nPlease put value between 0 and " + colorsSize + ".");
                return new Color32(0, 0, 0, 100);
            }
        }
    }
}
