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
            panel_menu = new Panel();
            cbox_looks = new ComboBox();
            lbl_looks = new Label();
            lbl_y = new Label();
            lbl_x = new Label();
            lbl_starting_body_elements = new Label();
            lbl_tick_duration = new Label();
            lbl_fields = new Label();
            lbl_size = new Label();
            lbl_title = new Label();
            button_start = new Button();
            num_start_body_elements = new NumericUpDown();
            num_tick_duration = new NumericUpDown();
            num_fields_y = new NumericUpDown();
            num_fields_x = new NumericUpDown();
            num_size_y = new NumericUpDown();
            num_size_x = new NumericUpDown();
            pictureBox1 = new PictureBox();
            panel_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_start_body_elements).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_tick_duration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_fields_y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_fields_x).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_size_y).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_size_x).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel_menu
            // 
            panel_menu.Controls.Add(cbox_looks);
            panel_menu.Controls.Add(lbl_looks);
            panel_menu.Controls.Add(lbl_y);
            panel_menu.Controls.Add(lbl_x);
            panel_menu.Controls.Add(lbl_starting_body_elements);
            panel_menu.Controls.Add(lbl_tick_duration);
            panel_menu.Controls.Add(lbl_fields);
            panel_menu.Controls.Add(lbl_size);
            panel_menu.Controls.Add(lbl_title);
            panel_menu.Controls.Add(button_start);
            panel_menu.Controls.Add(num_start_body_elements);
            panel_menu.Controls.Add(num_tick_duration);
            panel_menu.Controls.Add(num_fields_y);
            panel_menu.Controls.Add(num_fields_x);
            panel_menu.Controls.Add(num_size_y);
            panel_menu.Controls.Add(num_size_x);
            panel_menu.Location = new Point(44, 41);
            panel_menu.Name = "panel_menu";
            panel_menu.Size = new Size(367, 318);
            panel_menu.TabIndex = 0;
            // 
            // cbox_looks
            // 
            cbox_looks.FormattingEnabled = true;
            cbox_looks.Items.AddRange(new object[] { "Default" });
            cbox_looks.Location = new Point(21, 235);
            cbox_looks.Name = "cbox_looks";
            cbox_looks.Size = new Size(121, 23);
            cbox_looks.TabIndex = 15;
            cbox_looks.Text = "Default";
            // 
            // lbl_looks
            // 
            lbl_looks.AutoSize = true;
            lbl_looks.Location = new Point(21, 217);
            lbl_looks.Name = "lbl_looks";
            lbl_looks.Size = new Size(38, 15);
            lbl_looks.TabIndex = 14;
            lbl_looks.Text = "Looks";
            // 
            // lbl_y
            // 
            lbl_y.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_y.AutoSize = true;
            lbl_y.Location = new Point(170, 116);
            lbl_y.Name = "lbl_y";
            lbl_y.Size = new Size(14, 15);
            lbl_y.TabIndex = 13;
            lbl_y.Text = "Y";
            // 
            // lbl_x
            // 
            lbl_x.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_x.AutoSize = true;
            lbl_x.Location = new Point(170, 87);
            lbl_x.Name = "lbl_x";
            lbl_x.Size = new Size(14, 15);
            lbl_x.TabIndex = 12;
            lbl_x.Text = "X";
            // 
            // lbl_starting_body_elements
            // 
            lbl_starting_body_elements.AutoSize = true;
            lbl_starting_body_elements.Location = new Point(214, 157);
            lbl_starting_body_elements.Name = "lbl_starting_body_elements";
            lbl_starting_body_elements.Size = new Size(129, 15);
            lbl_starting_body_elements.TabIndex = 11;
            lbl_starting_body_elements.Text = "Starting Body Elements";
            // 
            // lbl_tick_duration
            // 
            lbl_tick_duration.AutoSize = true;
            lbl_tick_duration.Location = new Point(21, 157);
            lbl_tick_duration.Name = "lbl_tick_duration";
            lbl_tick_duration.Size = new Size(77, 15);
            lbl_tick_duration.TabIndex = 10;
            lbl_tick_duration.Text = "Tick Duration";
            // 
            // lbl_fields
            // 
            lbl_fields.AutoSize = true;
            lbl_fields.Location = new Point(247, 59);
            lbl_fields.Name = "lbl_fields";
            lbl_fields.Size = new Size(37, 15);
            lbl_fields.TabIndex = 9;
            lbl_fields.Text = "Fields";
            // 
            // lbl_size
            // 
            lbl_size.AutoSize = true;
            lbl_size.Location = new Point(49, 59);
            lbl_size.Name = "lbl_size";
            lbl_size.Size = new Size(55, 15);
            lbl_size.TabIndex = 8;
            lbl_size.Text = "Field Size";
            // 
            // lbl_title
            // 
            lbl_title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lbl_title.AutoSize = true;
            lbl_title.Location = new Point(149, 18);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(60, 15);
            lbl_title.TabIndex = 7;
            lbl_title.Text = "NeoSnake";
            // 
            // button_start
            // 
            button_start.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button_start.Location = new Point(79, 276);
            button_start.Name = "button_start";
            button_start.Size = new Size(205, 23);
            button_start.TabIndex = 6;
            button_start.Text = "Start";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += button_start_Click;
            // 
            // num_start_body_elements
            // 
            num_start_body_elements.Location = new Point(214, 175);
            num_start_body_elements.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_start_body_elements.Name = "num_start_body_elements";
            num_start_body_elements.Size = new Size(120, 23);
            num_start_body_elements.TabIndex = 5;
            num_start_body_elements.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // num_tick_duration
            // 
            num_tick_duration.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            num_tick_duration.Location = new Point(21, 175);
            num_tick_duration.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            num_tick_duration.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            num_tick_duration.Name = "num_tick_duration";
            num_tick_duration.Size = new Size(120, 23);
            num_tick_duration.TabIndex = 4;
            num_tick_duration.Tag = "";
            num_tick_duration.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // num_fields_y
            // 
            num_fields_y.Location = new Point(214, 114);
            num_fields_y.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_fields_y.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            num_fields_y.Name = "num_fields_y";
            num_fields_y.Size = new Size(120, 23);
            num_fields_y.TabIndex = 3;
            num_fields_y.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // num_fields_x
            // 
            num_fields_x.Location = new Point(214, 85);
            num_fields_x.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_fields_x.Minimum = new decimal(new int[] { 4, 0, 0, 0 });
            num_fields_x.Name = "num_fields_x";
            num_fields_x.Size = new Size(120, 23);
            num_fields_x.TabIndex = 2;
            num_fields_x.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // num_size_y
            // 
            num_size_y.Location = new Point(21, 114);
            num_size_y.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_size_y.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            num_size_y.Name = "num_size_y";
            num_size_y.Size = new Size(120, 23);
            num_size_y.TabIndex = 1;
            num_size_y.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // num_size_x
            // 
            num_size_x.Location = new Point(21, 85);
            num_size_x.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            num_size_x.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            num_size_x.Name = "num_size_x";
            num_size_x.Size = new Size(120, 23);
            num_size_x.TabIndex = 0;
            num_size_x.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.apple;
            pictureBox1.Location = new Point(278, 365);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 50);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // SnakeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 421);
            Controls.Add(pictureBox1);
            Controls.Add(panel_menu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "SnakeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NeoSnake";
            Load += SnakeForm_Load;
            panel_menu.ResumeLayout(false);
            panel_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_start_body_elements).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_tick_duration).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_fields_y).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_fields_x).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_size_y).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_size_x).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_menu;
        private NumericUpDown num_start_body_elements;
        private NumericUpDown num_tick_duration;
        private NumericUpDown num_fields_y;
        private NumericUpDown num_fields_x;
        private NumericUpDown num_size_y;
        private NumericUpDown num_size_x;
        private Button button_start;
        private Label lbl_fields;
        private Label lbl_size;
        private Label lbl_title;
        private Label lbl_tick_duration;
        private Label lbl_starting_body_elements;
        private Label lbl_y;
        private Label lbl_x;
        private Label lbl_looks;
        private ComboBox cbox_looks;
        private PictureBox pictureBox1;
    }
}
