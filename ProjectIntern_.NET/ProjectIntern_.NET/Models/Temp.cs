
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectIntern_.NET.Models
{
    public class Temp
    {
        
        public Int32 gyoNO { get; set; }
        
        public Int32 denpyoNO { get; set; }
        
        public DateTime idoDT { get; set; }
        
        public String shuppatsuPLC { get; set; }
        
        public String mokutekiPLC { get; set; }
        
        public String keiro { get; set; }
        
        public Int32 kingaku { get; set; }
        public Boolean isDelete { get; set; }   
    }
}
