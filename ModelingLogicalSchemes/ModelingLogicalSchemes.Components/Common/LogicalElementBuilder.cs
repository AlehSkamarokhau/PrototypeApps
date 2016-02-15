using ModelingLogicalSchemes.Components.Entities;

namespace ModelingLogicalSchemes.Components.Common
{
    public class LogicalElementBuilder
    {
        #region Private Members

        private static LogicalElement CreateLogicalElement(int numElement)
        {
            return new LogicalElement()
            {
                NumberElement = numElement
            };
        }

        private static LogicalElement SetFunction(LogicalElement element, FunctionTypes functionType)
        {
            element.Function = FunctionFactory.GetFunction(functionType);
            return element;
        }

        private static LogicalElement SetBrokenType(LogicalElement element, BrokenTypes brokenType)
        {
            element.BrokenType = brokenType;
            return element;
        }

        #endregion

        public static LogicalElement Build(int numElement, FunctionTypes functionType, BrokenTypes brokenType = BrokenTypes.Non)
        {
            LogicalElement element = CreateLogicalElement(numElement);
            element = SetFunction(element, functionType);
            element = SetBrokenType(element, brokenType);

            return element;
        }
    }
}
