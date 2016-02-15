using System;

namespace ModelingLogicalSchemes.Components.Common
{
    public class FunctionFactory
    {
        #region Public Interface

        public static Func<bool[], bool> GetFunction(FunctionTypes functionType)
        {
            switch (functionType)
            {
                case FunctionTypes.AND:

                    Func<bool[], bool> functionAnd = delegate(bool[] inputValues)
                    {
                        bool resultValue = inputValues[0];

                        for (int i = 1; i < inputValues.Length; i++)
                        {
                            resultValue = resultValue & inputValues[i];
                        }

                        return resultValue;
                    };

                    return functionAnd;

                case FunctionTypes.OR:

                    Func<bool[], bool> functionOr = delegate(bool[] inputValues)
                    {
                        bool resultValue = inputValues[0];

                        for (int i = 1; i < inputValues.Length; i++)
                        {
                            resultValue = resultValue | inputValues[i];
                        }

                        return resultValue;
                    };

                    return functionOr;

                case FunctionTypes.NOR:

                    Func<bool[], bool> functionNOr = delegate(bool[] inputValues)
                    {
                        bool resultValue = inputValues[0];

                        for (int i = 1; i < inputValues.Length; i++)
                        {
                            resultValue = resultValue | inputValues[i];
                        }

                        return !resultValue;
                    };

                    return functionNOr;

                case FunctionTypes.NXOR:

                    Func<bool[], bool> functionNXOr = delegate(bool[] inputValues)
                    {
                        bool resultValue = inputValues[0];

                        for (int i = 1; i < inputValues.Length; i++)
                        {
                            resultValue = resultValue ^ inputValues[i];
                        }

                        return !resultValue;
                    };

                    return functionNXOr;

                default:
                    break;
            }

            return null;
        }

        #endregion
    }
}
