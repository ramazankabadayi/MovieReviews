using MovieReviewsBL;
using MovieReviewsEL.DTO;
using MovieReviewsEL.Entities;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MovieReviewsUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgvReviews.CellClick += dgvReviews_CellClick;
        }
        private BaseManager<User, UserDTO, int> _userManager;
        private BaseManager<Film, FilmDTO, int> _filmManager;
        private BaseManager<Review, ReviewDTO, int> _reviewManager;

        private void Form1_Load(object sender, EventArgs e)
        {

            lstMovies.DisplayMember = "Title";
            lstMovies.ValueMember = "FilmId";


            dgvReviews.AllowUserToAddRows = false;
            dgvReviews.AllowUserToDeleteRows = false;
            dgvReviews.AllowUserToOrderColumns = false;
            int rating = 0;


            var movies = _filmManager.GetAllDataWithJoin();


            lstMovies.DataSource = movies;


        }

        private void btnReview_Click(object sender, EventArgs e)
        {
            try
            {
                if (nameText != null && emailText != null && reviewText != null && ratingsComboBox.SelectedItem != null)
                {
                    string username = nameText.Text;
                    string email = emailText.Text;
                    int rating = Convert.ToInt32(ratingsComboBox.SelectedItem);
                    string reviewText = this.reviewText.Text;
                    int selectedMovieId = (int)lstMovies.SelectedValue;

                    UserDTO newUser = new UserDTO
                    {
                        Username = username,
                        Email = email
                    };

                    bool isUserAdded = _userManager.AddNewData(newUser);

                    UserDTO addedUser = _userManager.GetSomeData(u => u.Username == username).FirstOrDefault();
                    if (addedUser == null)
                    {
                        MessageBox.Show("Kullanýcý bulunamadý.");
                        return;
                    }
                    ReviewDTO newReview = new ReviewDTO
                    {
                        FilmId = selectedMovieId,
                        UserId = addedUser.UserId,
                        Rating = rating,
                        ReviewText = reviewText,
                        ReviewDate = DateTime.Now


                    };


                    bool isAdded = _reviewManager.AddNewData(newReview);
                    if (isAdded)
                    {
                        nameText.Clear();
                        emailText.Clear();
                        this.reviewText.Clear();
                        MessageBox.Show("Your Review is Saved");
                    }

                }
                else
                {
                    MessageBox.Show("Please Fill All");
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void lstMovies_SelectedIndexChanged(object sender, EventArgs e)
        {


            int selected = (int)lstMovies.SelectedValue;

            try
            {
                var reviews = _reviewManager.GetAllDataWithJoin().Where(x => x.FilmId == selected);

                var reviewDetails = reviews.Select(review => new
                {
                    UserName = _userManager.GetById(review.UserId).Username,
                    MovieName = _filmManager.GetById(review.FilmId).Title,
                    MovieYear = _filmManager.GetById(review.FilmId).Year,
                    Director = _filmManager.GetById(review.FilmId).Director,
                    Rating = _reviewManager.GetById(review.ReviewId).Rating,
                    ReviewText = review.ReviewText,
                    ReviewDate = review.ReviewDate
                }).ToList();

                lblSelectedMovie.Text = reviewDetails[0].MovieName;
                lblReleaseDate.Text = reviewDetails[0].MovieYear.ToString();
                lblDirector.Text = reviewDetails[0].Director.ToString();


                dgvReviews.DataSource = reviewDetails;
                dgvReviews.Columns["UserName"].HeaderText = "Reviewer";
                dgvReviews.Columns["MovieYear"].HeaderText = "Year";
                dgvReviews.Columns["MovieYear"].Visible = false;
                dgvReviews.Columns["MovieName"].HeaderText = "Movie Name";
                dgvReviews.Columns["MovieName"].Visible = false;
                dgvReviews.Columns["Director"].Visible = false;
                dgvReviews.Columns["ReviewText"].HeaderText = "Review";
                dgvReviews.Columns["ReviewDate"].HeaderText = "Review Date";
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void dgvReviews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Týklanan hücrenin deðerini al
                var cellValue = dgvReviews[e.ColumnIndex, e.RowIndex].Value?.ToString();

                // MessageBox'ta bu deðeri göster
                MessageBox.Show(cellValue);
            }
        }
    }
}
