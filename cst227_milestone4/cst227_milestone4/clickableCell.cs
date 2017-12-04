using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace cst227_milestone4
{
    // Extend button Class
    class clickableCell : Button
    {
        // Set initial count to 0
        public int count = 0;

        // On initialize
        public clickableCell()
        {
            // set starting bacground color
            this.BackColor = Color.LightGray;
            // set starting text to ""
            this.Text = "";
        }

        // get cell count
        public int getCount()
        {
            return this.count;
        }

        // set cell count
        public void setCount()
        {
            this.count = this.count + 1;
        }

        // override base onclick method for button class
        protected override void OnClick(EventArgs e)
        {
            // chage count
            this.setCount();
            // change text
            this.Text = Convert.ToString(this.getCount());
            // change color of cell
            this.BackColor = Color.LightGreen;
        }



    }

}
