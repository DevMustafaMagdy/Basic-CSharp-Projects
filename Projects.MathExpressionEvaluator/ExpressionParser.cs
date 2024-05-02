using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.MathExpressionEvaluator
{
    public static class ExpressionParser
    {
        /*
         5 + 4
        10 mod 2
        */
        private const string MathSymbols = "+*/%^";
        public static MathExpression Parse(string input)
        {
            input = input.Trim();
            var expr = new MathExpression();
            string token = "";
            bool leftSideInitialized = false;
            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                // Digits
                if (char.IsDigit(currentChar))
                {
                    token += currentChar;
                    if (i == input.Length - 1 && leftSideInitialized)
                    {
                        expr.RightSideOperand = double.Parse(token);
                    }
                }
                // Symbols (+ * / % ^)
                else if (MathSymbols.Contains(currentChar))
                {
                    if (!leftSideInitialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                    }
                    if (expr.Operation == MathOperation.Subtraction && currentChar == '+')
                        expr.Operation = MathOperation.Subtraction;
                    else
                        expr.Operation = ParseMathOperation(currentChar.ToString());
                    token = "";
                }
                // Letter
                else if (char.IsLetter(currentChar))
                {
                    token += currentChar;
                    leftSideInitialized = true;
                }
                // Minus [-]
                else if (currentChar == '-' && i > 0)
                {
                    if (expr.Operation == MathOperation.None || expr.Operation == MathOperation.Addition)
                    {
                        expr.Operation = MathOperation.Subtraction;
                        if (!leftSideInitialized)
                        {
                            expr.LeftSideOperand = double.Parse(token);
                            leftSideInitialized = true;
                        }
                        token = "";
                    }
                    else if (expr.Operation == MathOperation.Subtraction)
                        expr.Operation = MathOperation.Addition;
                    else
                        token += currentChar;
                }
                // Space
                else if (currentChar == ' ')
                {
                    if (!leftSideInitialized)
                    {
                        expr.LeftSideOperand = double.Parse(token);
                        leftSideInitialized = true;
                    }
                    else if (expr.Operation == MathOperation.None && token != "")
                    {
                        expr.Operation = ParseMathOperation(token);
                    }
                    token = "";
                }
                else
                    token += currentChar;
            }
            return expr;
        }

        private static MathOperation ParseMathOperation(string token)

        {
            switch (token.ToLower())
            {
                case "+":
                    return MathOperation.Addition;
                case "*":
                    return MathOperation.Multiplication;
                case "/":
                    return MathOperation.Division;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "^":
                case "pow":
                    return MathOperation.Power;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;
            }
        }
    }
}
