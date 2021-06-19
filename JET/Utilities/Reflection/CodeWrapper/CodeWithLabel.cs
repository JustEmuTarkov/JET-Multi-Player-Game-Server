using System;
using System.Reflection.Emit;

namespace JET.Utilities.Reflection.CodeWrapper
{
    public class CodeWithLabel : Code
    {
        public CodeWithLabel(OpCode opCode, Label label) : base(opCode)
        {
            Label = label;
        }

        public CodeWithLabel(OpCode opCode, Label label, object operandTarget) : base(opCode, operandTarget)
        {
            Label = label;
        }

        public CodeWithLabel(OpCode opCode, Label label, Type callerType) : base(opCode, callerType)
        {
            Label = label;
        }

        public CodeWithLabel(OpCode opCode, Label label, Type callerType, object operandTarget, Type[] parameters = null) : base(opCode, callerType, operandTarget, parameters)
        {
            Label = label;
        }

        public override Label? GetLabel()
        {
            return Label;
        }

        public Label Label { get; }
    }
}
