namespace random
{
    public partial class Form1 : Form
    {
        Point pos;
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragButtonPoint;

        public Form1()
        {
            InitializeComponent();
            Point pos = Cursor.Position;
            this.MouseMove += Form1_MouseMove1;

            button1.MouseDown += Button1_MouseDown;
            button1.MouseUp += Button1_MouseUp;


        }

        private void Form1_MouseMove1(object sender, MouseEventArgs e)
        {
            Rectangle buttonBounds = button1.Bounds;
            if (buttonBounds.X - 15 <= e.X && e.X <= buttonBounds.Right + 15 &&
                buttonBounds.Y - 15 <= e.Y && e.Y <= buttonBounds.Bottom + 15)
            {
                int newX = button1.Left;
                int newY = button1.Top;

                if (e.X < button1.Left)
                {
                    newX = button1.Left + 1;
                }
                else if (e.X > button1.Right)
                {
                    newX = button1.Left - 1;
                }
                if (e.Y < button1.Top)
                {
                    newY = button1.Top + 1;
                }
                else if (e.Y > button1.Bottom)
                {
                    newY = button1.Top - 1;
                }
                if (newX < 0) newX = 0;
                if (newY < 0) newY = 0;
                if (newX + button1.Width > this.ClientSize.Width) newX = this.ClientSize.Width - button1.Width;
                if (newY + button1.Height > this.ClientSize.Height) newY = this.ClientSize.Height - button1.Height;

                button1.Location = new Point(newX, newY);
            }
        }

        private void Form1_MouseMove2(object sender, MouseEventArgs e)
        {
            Rectangle buttonBounds = button1.Bounds;

            if (buttonBounds.X - 15 <= e.X && e.X <= buttonBounds.Right + 15 &&
                buttonBounds.Y - 15 <= e.Y && e.Y <= buttonBounds.Bottom + 15)
            {
                int newX = button1.Left;
                int newY = button1.Top;

                if (e.X < button1.Left)
                {
                    newX = button1.Left - 1;
                }
                else if (e.X > button1.Right)
                {
                    newX = button1.Left + 1;
                }
                if (e.Y < button1.Top)
                {
                    newY = button1.Top - 1;
                }
                else if (e.Y > button1.Bottom)
                {
                    newY = button1.Top + 1;
                }
                if (newX < 0) newX = 0;
                if (newY < 0) newY = 0;
                if (newX + button1.Width > this.ClientSize.Width) newX = this.ClientSize.Width - button1.Width;
                if (newY + button1.Height > this.ClientSize.Height) newY = this.ClientSize.Height - button1.Height;

                button1.Location = new Point(newX, newY);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.MouseMove -= Form1_MouseMove1;
                this.MouseMove += Form1_MouseMove2;
                button1.MouseMove -= Button1_MouseMove;
            }
            else
            {
                this.MouseMove += Form1_MouseMove1;
                this.MouseMove -= Form1_MouseMove2;
                button1.MouseMove -= Button1_MouseMove;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.MouseMove -= Form1_MouseMove1;
            this.MouseMove -= Form1_MouseMove2;
        }

        private void Button1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                button1.MouseMove += Button1_MouseMove;
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragButtonPoint = button1.Location;
            }
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point newCursorPoint = Cursor.Position;
                int offsetX = newCursorPoint.X - dragCursorPoint.X;
                int offsetY = newCursorPoint.Y - dragCursorPoint.Y;
                button1.Location = new Point(dragButtonPoint.X + offsetX, dragButtonPoint.Y + offsetY);
            }
        }

        private void Button1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isDragging = false;
            }
        }
    }
}
