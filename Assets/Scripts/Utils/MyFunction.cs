using System.Collections.Generic;

namespace Utils{
    public class MyFunction : Instance{
        
        public int nparams;
        public object instructions;
        public LinkedList<string> namesParams;


        public MyFunction(string ID, int nparams, LinkedList<string> namesParams, object instructions){
            this.nparams = nparams;
            this.ID = ID;
            this.instructions = instructions;
            this.namesParams = namesParams;
        }
    }
}