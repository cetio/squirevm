namespace Squire.VM.Runtime.Handlers
{
    public class Instruction
    {
        public OpCode OpCode { get; set; }
        public VMObject Operand { get; set; }
        public ExceptionHandler ExceptionHandler { get; set; } = ExceptionHandler.None;

        public Instruction(OpCode opCode, VMObject operand, ExceptionHandler exhandler)
        {
            OpCode = opCode;
            Operand = operand;
            ExceptionHandler = exhandler;
        }

        public Instruction(OpCode opCode, VMObject operand)
        {
            OpCode = opCode;
            Operand = operand;
        }

        public Instruction(OpCode opCode, object? operand)
            => new Instruction(opCode, new VMObject(operand));

        public Instruction(OpCode opCode)
            => new Instruction(opCode, null);
    
        public Instruction()
            => new Instruction(OpCodes.Nop, null);

        public void Run(Context ctx)
            OpCode.Run(ctx, Operand);
    }
}