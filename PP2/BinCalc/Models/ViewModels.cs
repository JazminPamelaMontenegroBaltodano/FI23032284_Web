using System.Collections.Generic;

namespace BinCalc.Models
{
    public class ResultRow
    {
        public string Label { get; set; } = "";
        public string Bin { get; set; } = "";
        public string Oct { get; set; } = "";
        public string Dec { get; set; } = "";
        public string Hex { get; set; } = "";
    }

    public class BinaryViewModel
    {
        public BinaryInputModel Input { get; set; } = new();
        public List<ResultRow>? Rows { get; set; }   // null si hubo errores
    }
}
