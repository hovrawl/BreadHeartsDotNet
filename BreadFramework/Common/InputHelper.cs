namespace BreadFramework.Common;

public class InputHelper
{
    public static int CombineInputs(params ControllerInput[] inputs)
    {
        return inputs.Sum(input => (int)input);
    }
}