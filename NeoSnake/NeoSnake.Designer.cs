namespace NeoSnake
{
    partial class SnakeForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            game_timer = new System.Windows.Forms.Timer(components);
            lbl_tick = new Label();
            SuspendLayout();
            // 
            // game_timer
            // 
            game_timer.Interval = 500;
            game_timer.Tick += game_timer_Tick;
            // 
            // lbl_tick
            // 
            lbl_tick.AutoSize = true;
            lbl_tick.Location = new Point(6, 5);
            lbl_tick.Name = "lbl_tick";
            lbl_tick.Size = new Size(0, 15);
            lbl_tick.TabIndex = 0;
            // 
            // SnakeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_tick);
            KeyPreview = true;
            Name = "SnakeForm";
            Text = "NeoSnake";
            Load += SnakeForm_Load;
            KeyDown += SnakeForm_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer game_timer;
        private Label lbl_tick;
    }
}
