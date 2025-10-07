using Microsoft.AspNetCore.Mvc;
using BinCalc.Models;
using System.Collections.Generic;

namespace BinCalc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index() => View(new BinaryViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(BinaryInputModel input)
        {
            if (!ModelState.IsValid)
            {
                // Devolver con mensajes de validación
                return View(new BinaryViewModel { Input = input, Rows = null });
            }

            var a = input.A;
            var b = input.B;

            var rows = new List<ResultRow>();

            // a y b se muestran en 1 Byte
            var aPad8 = BinaryOps.PadToByte(a);
            var bPad8 = BinaryOps.PadToByte(b);

            rows.Add(MakeRow("a", aPad8));
            rows.Add(MakeRow("b", bPad8));

            // Operaciones binarias
            string and = BinaryOps.And(a, b);
            string or  = BinaryOps.Or(a, b);
            string xor = BinaryOps.Xor(a, b);

            rows.Add(MakeRow("a AND b", and));
            rows.Add(MakeRow("a OR b",  or));
            rows.Add(MakeRow("a XOR b", xor));

            // Aritméticas
            string sum = BinaryOps.Sum(a, b);
            string prod = BinaryOps.Product(a, b);

            rows.Add(MakeRow("a + b", sum));
            rows.Add(MakeRow("a • b", prod));

            var vm = new BinaryViewModel
            {
                Input = input,
                Rows = rows
            };

            return View(vm);
        }

        private static ResultRow MakeRow(string label, string bin)
        {

            var trimmedBin = BinaryOps.TrimLeadingZeros(bin);
            return new ResultRow
            {
                Label = label,
                Bin = trimmedBin,
                Oct = BinaryOps.ToOct(trimmedBin),
                Dec = BinaryOps.ToDec(trimmedBin),
                Hex = BinaryOps.ToHex(trimmedBin)
            };
        }
    }
}
