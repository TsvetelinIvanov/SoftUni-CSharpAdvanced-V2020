namespace _06CreationalPatterns_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorController colorController = new ColorController();

            colorController["yellow"] = new Color(255, 255, 0);
            colorController["orange"] = new Color(255, 128, 0);
            colorController["purple"] = new Color(128, 0, 255);

            colorController["sunny"] = new Color(255, 54, 0);
            colorController["tasty"] = new Color(255, 153, 51);
            colorController["rainy"] = new Color(255, 0, 255);

            Color color1 = colorController["yellow"].Clone() as Color;//RGB color is cloned to: 255,255,  0
            Color color2 = colorController["orange"].Clone() as Color;//RGB color is cloned to: 255,128,  0
            Color color3 = colorController["purple"].Clone() as Color;//RGB color is cloned to: 128,  0,255
            Color color4 = colorController["sunny"].Clone() as Color;//RGB color is cloned to: 255, 54,  0
            Color color5 = colorController["tasty"].Clone() as Color;//RGB color is cloned to: 255,153, 51
            Color color6 = colorController["rainy"].Clone() as Color;//RGB color is cloned to: 255,  0,255
        }
    }
}