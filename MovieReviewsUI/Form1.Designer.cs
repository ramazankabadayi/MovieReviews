namespace MovieReviewsUI
{
    partial class Form1
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
            lstMovies = new ListBox();
            dgvReviews = new DataGridView();
            nameText = new TextBox();
            reviewText = new TextBox();
            lblMovies = new Label();
            lblReviews = new Label();
            lblMakeReview = new Label();
            btnReview = new Button();
            label1 = new Label();
            label3 = new Label();
            lblSelectedMovieText = new Label();
            lblReleaseYearText = new Label();
            lblDirectorText = new Label();
            lblSelectedMovie = new Label();
            lblReleaseDate = new Label();
            lblDirector = new Label();
            ratingsComboBox = new ComboBox();
            label2 = new Label();
            label4 = new Label();
            emailText = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvReviews).BeginInit();
            SuspendLayout();
            // 
            // lstMovies
            // 
            lstMovies.FormattingEnabled = true;
            lstMovies.ItemHeight = 20;
            lstMovies.Location = new Point(39, 128);
            lstMovies.Name = "lstMovies";
            lstMovies.Size = new Size(172, 244);
            lstMovies.TabIndex = 0;
            lstMovies.SelectedIndexChanged += lstMovies_SelectedIndexChanged;
            // 
            // dgvReviews
            // 
            dgvReviews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReviews.Location = new Point(249, 128);
            dgvReviews.Name = "dgvReviews";
            dgvReviews.RowHeadersWidth = 51;
            dgvReviews.RowTemplate.Height = 29;
            dgvReviews.Size = new Size(555, 244);
            dgvReviews.TabIndex = 1;
            dgvReviews.CellClick += dgvReviews_CellClick;
            // 
            // nameText
            // 
            nameText.Location = new Point(950, 173);
            nameText.Name = "nameText";
            nameText.Size = new Size(183, 27);
            nameText.TabIndex = 2;
            // 
            // reviewText
            // 
            reviewText.Location = new Point(951, 335);
            reviewText.Multiline = true;
            reviewText.Name = "reviewText";
            reviewText.Size = new Size(183, 120);
            reviewText.TabIndex = 4;
            // 
            // lblMovies
            // 
            lblMovies.AutoSize = true;
            lblMovies.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblMovies.Location = new Point(57, 73);
            lblMovies.Name = "lblMovies";
            lblMovies.Size = new Size(127, 46);
            lblMovies.TabIndex = 5;
            lblMovies.Text = "Movies";
            // 
            // lblReviews
            // 
            lblReviews.AutoSize = true;
            lblReviews.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblReviews.Location = new Point(443, 73);
            lblReviews.Name = "lblReviews";
            lblReviews.Size = new Size(138, 46);
            lblReviews.TabIndex = 6;
            lblReviews.Text = "Reviews";
            // 
            // lblMakeReview
            // 
            lblMakeReview.AutoSize = true;
            lblMakeReview.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lblMakeReview.Location = new Point(886, 73);
            lblMakeReview.Name = "lblMakeReview";
            lblMakeReview.Size = new Size(216, 46);
            lblMakeReview.TabIndex = 7;
            lblMakeReview.Text = "Make Review";
            // 
            // btnReview
            // 
            btnReview.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            btnReview.Location = new Point(1196, 376);
            btnReview.Name = "btnReview";
            btnReview.Size = new Size(113, 58);
            btnReview.TabIndex = 8;
            btnReview.Text = "Send";
            btnReview.UseVisualStyleBackColor = true;
            btnReview.Click += btnReview_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(858, 173);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 9;
            label1.Text = "Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(858, 335);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 11;
            label3.Text = "Review:";
            // 
            // lblSelectedMovieText
            // 
            lblSelectedMovieText.AutoSize = true;
            lblSelectedMovieText.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblSelectedMovieText.Location = new Point(301, 399);
            lblSelectedMovieText.Name = "lblSelectedMovieText";
            lblSelectedMovieText.Size = new Size(195, 35);
            lblSelectedMovieText.TabIndex = 12;
            lblSelectedMovieText.Text = "Selected Movie :";
            // 
            // lblReleaseYearText
            // 
            lblReleaseYearText.AutoSize = true;
            lblReleaseYearText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblReleaseYearText.Location = new Point(364, 434);
            lblReleaseYearText.Name = "lblReleaseYearText";
            lblReleaseYearText.Size = new Size(126, 28);
            lblReleaseYearText.TabIndex = 13;
            lblReleaseYearText.Text = "Release Year :";
            // 
            // lblDirectorText
            // 
            lblDirectorText.AutoSize = true;
            lblDirectorText.Location = new Point(420, 469);
            lblDirectorText.Name = "lblDirectorText";
            lblDirectorText.Size = new Size(70, 20);
            lblDirectorText.TabIndex = 14;
            lblDirectorText.Text = "Director :";
            // 
            // lblSelectedMovie
            // 
            lblSelectedMovie.AutoSize = true;
            lblSelectedMovie.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblSelectedMovie.Location = new Point(496, 399);
            lblSelectedMovie.Name = "lblSelectedMovie";
            lblSelectedMovie.Size = new Size(0, 35);
            lblSelectedMovie.TabIndex = 15;
            // 
            // lblReleaseDate
            // 
            lblReleaseDate.AutoSize = true;
            lblReleaseDate.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblReleaseDate.Location = new Point(496, 434);
            lblReleaseDate.Name = "lblReleaseDate";
            lblReleaseDate.Size = new Size(0, 28);
            lblReleaseDate.TabIndex = 16;
            // 
            // lblDirector
            // 
            lblDirector.AutoSize = true;
            lblDirector.Location = new Point(496, 469);
            lblDirector.Name = "lblDirector";
            lblDirector.Size = new Size(0, 20);
            lblDirector.TabIndex = 17;
            // 
            // ratingsComboBox
            // 
            ratingsComboBox.FormattingEnabled = true;
            ratingsComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            ratingsComboBox.Location = new Point(951, 253);
            ratingsComboBox.Name = "ratingsComboBox";
            ratingsComboBox.Size = new Size(151, 28);
            ratingsComboBox.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(862, 256);
            label2.Name = "label2";
            label2.Size = new Size(55, 20);
            label2.TabIndex = 19;
            label2.Text = "Rating:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(858, 214);
            label4.Name = "label4";
            label4.Size = new Size(55, 20);
            label4.TabIndex = 20;
            label4.Text = "E-mail:";
            // 
            // emailText
            // 
            emailText.Location = new Point(950, 211);
            emailText.Name = "emailText";
            emailText.Size = new Size(125, 27);
            emailText.TabIndex = 21;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1376, 601);
            Controls.Add(emailText);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(ratingsComboBox);
            Controls.Add(lblDirector);
            Controls.Add(lblReleaseDate);
            Controls.Add(lblSelectedMovie);
            Controls.Add(lblDirectorText);
            Controls.Add(lblReleaseYearText);
            Controls.Add(lblSelectedMovieText);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(btnReview);
            Controls.Add(lblMakeReview);
            Controls.Add(lblReviews);
            Controls.Add(lblMovies);
            Controls.Add(reviewText);
            Controls.Add(nameText);
            Controls.Add(dgvReviews);
            Controls.Add(lstMovies);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReviews).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstMovies;
        private DataGridView dgvReviews;
        private TextBox nameText;
        private TextBox reviewText;
        private Label lblMovies;
        private Label lblReviews;
        private Label lblMakeReview;
        private Button btnReview;
        private Label label1;
        private Label label3;
        private Label lblSelectedMovieText;
        private Label lblReleaseYearText;
        private Label lblDirectorText;
        private Label lblSelectedMovie;
        private Label lblReleaseDate;
        private Label lblDirector;
        private ComboBox ratingsComboBox;
        private Label label2;
        private Label label4;
        private TextBox emailText;
    }
}
