﻿using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _fileReader;
        private Mock<IVideoRepository> _repository;

        [SetUp]
        public void SetUp()
        {
            _fileReader = new Mock<IFileReader>();
            _repository = new Mock<IVideoRepository>();
            _videoService = new VideoService(_fileReader.Object, _repository.Object);
        }

        [TearDown]
        public void TearDown()
        {
            _fileReader = null;
            _repository = null;
            _videoService = null;
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("");


            var result = _videoService.ReadVideoTitle();

            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void ReadVideoTitle_ValidFile_ReturnsTitle()
        {
            _fileReader.Setup(fr => fr.Read("video.txt")).Returns("{\"Id\":1,\"Title\":\"a title\"}");
            var result = _videoService.ReadVideoTitle();
            Assert.That(result, Is.EqualTo("a title"));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcess_ReturnsAnEmptyString()
        {
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(new LinkedList<Video>());
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo(""));
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AFewUnProcessVideos_ReturnsAStringWithIdOfUnProcessVideos()
        {
            var videos = new List<Video>
            {
                new Video {Id = 1, Title = "a title", IsProcessed = false},
                new Video {Id = 2, Title = "another title", IsProcessed = false}
            };
            _repository.Setup(r => r.GetUnprocessedVideos()).Returns(videos);
            var result = _videoService.GetUnprocessedVideosAsCsv();
            Assert.That(result, Is.EqualTo("1,2"));
        }
    }
}
