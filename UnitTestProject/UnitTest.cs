
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWars.DAL.Repository.Api;
using StarWars.Domain;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using StarWarsUWP.ViewModels;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ApiRepository Repo = new ApiRepository();
            Movie selectedMovie = Repo.GetMovieByUrl("1");
            string expectedResult = "A New Hope";

            Assert.AreEqual(expectedResult, selectedMovie.Title);

        }

        [TestMethod]
        public void TestImagePath()
        {
            ApiRepository Repo = new ApiRepository();
            Movie selectedMovie = Repo.GetMovieByUrl("1");
            string help = selectedMovie.Title;
            string imagePath = "Assets/Posters/" + help.Replace(" ", "_").ToLower() + ".jpg";
            selectedMovie.ImagePath = imagePath;
            string expectedResult = "Assets/Posters/a_new_hope.jpg";

            Assert.AreEqual(expectedResult, selectedMovie.ImagePath);
        }

        [TestMethod]
        public void Test_Function_GetAllMovies_ApiRepostory_Check_If_7_Movies()
        {
            ApiRepository Repo = new ApiRepository();
            IList<Movie> movieList = Repo.GetAllMovies();

            int actual = movieList.Count;
            int expected = 7;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_If_List_Of_Movies_Contains_Information_Title_Choosen_Id_1()
        {

            ApiRepository Repo = new ApiRepository();
            IList<Movie> movieList = Repo.GetAllMovies();

            string actual = movieList[0].Title.ToLower();
            string expected = "a new hope";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ViewModel()
        {

            MoviesViewModel viewModel = new MoviesViewModel();
           
            string actual = viewModel.SelectedMovie.Title.ToLower();
            string expected = "a new hope";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_ViewModel_Image_Path()
        {

            MoviesViewModel viewModel = new MoviesViewModel();

            string actual = viewModel.SelectedMovie.ImagePath;
            string expected = "Assets/Posters/a_new_hope.jpg";
            Assert.AreEqual(expected, actual);
        }
    }
}
