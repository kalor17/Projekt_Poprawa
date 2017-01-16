using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Poprawa
{
    abstract class Player
    {
        protected string nazwa;
        protected string znak;
        protected int lZwyc;

        public int ReturnZwy()
        {
            return this.lZwyc;
        }

        public void ZwiekszZwy()
        {
            this.lZwyc += 1;
        }

        public void UstawZnak(string znak)
        {
            this.znak = znak;
        }

        public void ZerujZwy()
        {
            this.lZwyc = 0;
        }

        public string ReturnZnak()
        {
            return this.znak;
        }

        public abstract string Info();
    }
}
