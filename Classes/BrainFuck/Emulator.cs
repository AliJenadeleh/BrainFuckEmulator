using System;
using System.Text;

namespace bfai.Classes.BrainFuck{
    public class Emulator{
        private const int MaxMemoryLength = 1024,MaxLoop = 1024;
        private readonly string Program;
        private StringBuilder output;
        private int PIndex,MIndex;
        private byte[] Memory;
        private byte CurrentMemoryCell{
            get{return Memory[MIndex];}
        }
        public Emulator(string Program){
            this.Program = Program;
        }
        private void Init(){
            MIndex = PIndex = 0;
            Memory = new byte[MaxMemoryLength];
            output = new StringBuilder();
        }
        
        private void OutPut(){
            char value = (char) Memory[MIndex];
            output.Append(value);
            Console.Write(value);
        }


        private void ValOutPut(){
            int value =  Memory[MIndex];
            output.Append(value.ToString());
            Console.WriteLine($" [{value}] ");
        }

        private void InPut(){
            char ch = Console.ReadKey().KeyChar;
            Memory[MIndex] = (byte)ch;
        }

        private void ValInPut(){
            char tmp = Console.ReadKey().KeyChar;
             Memory[MIndex] = byte.Parse(tmp.ToString());
        }

        private void Increment(){
            int value = Memory[MIndex] + 1;
            if((value + 1) > byte.MaxValue)
                value = byte.MinValue;
            else
                Memory[MIndex] =(byte) value;
        }

        private void Decrement(){
            int value = Memory[MIndex] - 1;
            if((value + 1) < byte.MinValue)
                value = byte.MaxValue;
            else
                Memory[MIndex] =(byte) value;
        }

        private void MoveLeft(){
            int inx = MIndex - 1;
            if(inx < 0)
                MIndex = MaxMemoryLength;
            else
                MIndex = inx;
        }

        private void MoveRight()
        {
            int inx = MIndex + 1;
            if(inx > MaxMemoryLength)
                MIndex = 0;
            else
                MIndex = inx;
        }

        private void Begin(){
            if(Memory[MIndex] == 0){
                //Skip
                int i = PIndex;
                int indent = 1;

                do{
                    i++;
                    if(Program[i] == Instructions.Begin)
                        indent ++;
                    else if(Program[i] == Instructions.End)
                        indent --;
                        
                }while(indent > 0);
                PIndex = i;
            }else{
                Memory[MIndex] --;
            }
        }//Begin();

        private void End(){
            int i = PIndex ;
            int indent = 1;

            do{
                i--;
                if(Program[i] == Instructions.End)
                    indent ++;
                else if(Program[i] == Instructions.Begin)
                    indent --;
            }while(indent > 0);
            PIndex = i -1;
        }
        private void Choice(char Command){
            
            switch(Command)
            {
                case Instructions.Begin :
                    Begin();
                    break;
                case Instructions.End : 
                    End();
                    break;
                case Instructions.MoveLeft : 
                    MoveLeft();
                    break;
                case Instructions.MoveRight : 
                    MoveRight();
                    break;
                case Instructions.Increment : 
                    Increment();
                    break;
                case Instructions.Decrement : 
                    Decrement();
                    break;
                case Instructions.OutPut : 
                    OutPut();
                    break;
                case Instructions.ValOutput:
                    ValOutPut(); // NoneStandard
                    break;
                case Instructions.InPut : 
                    InPut();
                    break;
                case Instructions.ValInPut:
                    ValInPut(); // NoneStandard
                    break;
                default:
                break;
            }
        }
        private void Start(){
            int count = Count();
            char command;
            while(PIndex < count){
                command = Program[PIndex];
                Choice(command);
                PIndex ++;
            }
        }
        public void Run(){
            Init();
            Start();
        }

        public int Count(){
            return Program.Length;
        }
    }
}