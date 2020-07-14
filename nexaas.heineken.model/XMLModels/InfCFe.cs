using System.Collections.Generic;

namespace nexaas.heineken.model.XMLModels
{
    public class InfCFe
    {
        public Ide Ide { get; set; }
        public Emit Emit { get; set; }
        public IList<object> Dest { get; set; }
        public IList<Det> Det { get; set; }
        public Total Total { get; set; }
        public Pgto Pgto { get; set; }
        public InfAdic InfAdic { get; set; }
    }
}
