public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        try
        {
            switch (operation)
            {
                case "+":
                    return $"{operand1} {operation} {operand2} = {SimpleOperation.Addition(operand1,operand2)}";
                    break;

                case "*":
                    return $"{operand1} {operation} {operand2} = {SimpleOperation.Multiplication(operand1,operand2)}";
                    break;

                case "/":
                    return $"{operand1} {operation} {operand2} = {SimpleOperation.Division(operand1,operand2)}";
                    break;

                case "":
                    throw new ArgumentException("operation", "The operation is empty");
                    break;

                case null:
                    throw new ArgumentNullException("operation","The operation is null");
                    break;

                default:
                    throw new ArgumentOutOfRangeException("operation","The operation is using different symbols");
                    break;
            }
            
        }
        catch (DivideByZeroException)
        {
            return "Division by zero is not allowed.";
        }
    }
}
