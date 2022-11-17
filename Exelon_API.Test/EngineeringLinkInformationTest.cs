using AutoFixture;
using Exelon.Application.IServices;
using Exelon.Application.Service;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using ExelonPOC.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Exelon_API.Test
{
    public class EngineeringLinkInformationTest
    {
        private Fixture _fixture;
        private ENGINEERINGController _engController;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private Mock<ILinkingInfoRepository> _linkingInfoRepository;
        private Mock<ILinkingInfoService> _linkInfoService;


        public EngineeringLinkInformationTest()
        {
            _fixture = new Fixture();
            _unitOfWorkService = new Mock<IUnitOfWorkService>();

            _linkingInfoRepository = new Mock<ILinkingInfoRepository>();

            _linkInfoService = new Mock<ILinkingInfoService>();
        }

        [Fact]
        public async void Get_LINKINFO_ShouldBe_OkResult_Test()
        {
            //Arrange
            var linkingInfoModel = _fixture.CreateMany<LinkingInfoModel>(3).ToList();

            _linkingInfoRepository.Setup(r => r.GetLINKINFO(1)).ReturnsAsync(linkingInfoModel);

            var linkInfoService = new LinkingInfoService(_linkingInfoRepository.Object);

            _unitOfWorkService.Setup(o => o.lINKINGINFOService).Returns(linkInfoService);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);

            

            //Act
            var result = await _engController.GetLINKINFO(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            result.Should().NotBeNull();

            Assert.Equal(linkingInfoModel, resval);
        }


        [Fact]
        public async void Get_LINKINFO_ShouldBe_NotFoundResult_Test()
        {
            //Arrange
            var linkingInfoModel = _fixture.CreateMany<LinkingInfoModel>(0).ToList();

            _linkingInfoRepository.Setup(r => r.GetLINKINFO(1)).ReturnsAsync(linkingInfoModel);

            var linkInfoService = new LinkingInfoService(_linkingInfoRepository.Object);

            _unitOfWorkService.Setup(o => o.lINKINGINFOService).Returns(linkInfoService);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetLINKINFO(1);
            var resval = ((ObjectResult)result).Value;
            

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
           
        }

         [Fact]
         public async Task Create_LINKINFO_Shouldbe_OkResult_Test()
         {
            // Arrange
            // var linkingInfoModel = _fixture.CreateMany<LinkingInfoModel>(1);
             var linkingInfoModel = new LinkingInfoModel()
            {
                LinkingID = 1,
                PrimaryKey = "a",
                Description = "d",
                Nickname = "n",
                PDID = 1,
                EngineeringYear = "2020",
                ExecutionYear = "2021",
                FK_TechnologyID = null,
                FK_RegionID = null,
                FK_BarnID = null,
                WorkOrder = "w",
                ProjectID = "p",
                FiberCount = null,
                Comments = "c",
                ScopeComments = "s",
                ITN = "i",
                FK_ProjectStatusID = null,
                FK_StepID = 1,
                CreatedDate = DateTime.Now,
                CreatedBy = 1,
                UpdatedDate = DateTime.Now,
                UpdatedBy = 1,
                IsDeleted = false,
                DeletedDate = DateTime.Now,
                DeletedBy = 1
            };

            var uowMock = new Mock<IUnitOfWorkService>();
            uowMock.Setup(o => o.lINKINGINFOService).Returns(() => _linkInfoService.Object);
            uowMock.Setup(m => m.lINKINGINFOService.CreateLINKINFO(linkingInfoModel))
                        .Returns(Task.FromResult(linkingInfoModel));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateLINKINFO(linkingInfoModel);

            //Assert
             Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_LINKINFO_Shouldbe_BadRequestResult_Test()
        {
            // Arrange
            // var linkingInfoModel = _fixture.CreateMany<LinkingInfoModel>(1);
            var linkingInfoModel = new LinkingInfoModel()
            {
                LinkingID = 0,
                PrimaryKey = "a",
                Description = "d",
                Nickname = "n",
                PDID = 1,
                EngineeringYear = "2020",
                ExecutionYear = "2021",
                FK_TechnologyID = null,
                FK_RegionID = null,
                FK_BarnID = null,
                WorkOrder = "w",
                ProjectID = "p",
                FiberCount = null,
                Comments = "c",
                ScopeComments = "s",
                ITN = "i",
                FK_ProjectStatusID = null,
                FK_StepID = 1,
                CreatedDate = DateTime.Now,
                CreatedBy = 1,
                UpdatedDate = DateTime.Now,
                UpdatedBy = 1,
                IsDeleted = false,
                DeletedDate = DateTime.Now,
                DeletedBy = 1
            };

            var uowMock = new Mock<IUnitOfWorkService>();
            uowMock.Setup(o => o.lINKINGINFOService).Returns(() => _linkInfoService.Object);
            uowMock.Setup(m => m.lINKINGINFOService.CreateLINKINFO(linkingInfoModel))
                        .Returns(Task.FromResult(linkingInfoModel));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateLINKINFO(linkingInfoModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_LINKINFO_Shouldbe_OkResult_Test()
        {
            // Arrange
            var linkingInfoModel = new LinkingInfoModel()
            {
                LinkingID = 1,
                PrimaryKey = "a",
                Description = "d",
                Nickname = "n",
                PDID = 1,
                EngineeringYear = "2020",
                ExecutionYear = "2021",
                FK_TechnologyID = null,
                FK_RegionID = null,
                FK_BarnID = null,
                WorkOrder = "w",
                ProjectID = "p",
                FiberCount = null,
                Comments = "c",
                ScopeComments = "s",
                ITN = "i",
                FK_ProjectStatusID = null,
                FK_StepID = 1,
                CreatedDate = DateTime.Now,
                CreatedBy = 1,
                UpdatedDate = DateTime.Now,
                UpdatedBy = 1,
                IsDeleted = false,
                DeletedDate = DateTime.Now,
                DeletedBy = 1
            };

            var uowMock = new Mock<IUnitOfWorkService>();
            uowMock.Setup(o => o.lINKINGINFOService).Returns(() => _linkInfoService.Object);
            uowMock.Setup(m => m.lINKINGINFOService.UpdateLINKINFO(linkingInfoModel))
                        .Returns(Task.FromResult(linkingInfoModel));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateLINKINFO((int)linkingInfoModel.LinkingID, linkingInfoModel);
            
            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_LINKINFO_Shouldbe_BadObjectResult_Test()
        {
            // Arrange
            var linkingInfoModel = new LinkingInfoModel()
            {
                LinkingID = 0,
                PrimaryKey = "a",
                Description = "d",
                Nickname = "n",
                PDID = 1,
                EngineeringYear = "2020",
                ExecutionYear = "2021",
                FK_TechnologyID = null,
                FK_RegionID = null,
                FK_BarnID = null,
                WorkOrder = "w",
                ProjectID = "p",
                FiberCount = null,
                Comments = "c",
                ScopeComments = "s",
                ITN = "i",
                FK_ProjectStatusID = null,
                FK_StepID = 1,
                CreatedDate = DateTime.Now,
                CreatedBy = 1,
                UpdatedDate = DateTime.Now,
                UpdatedBy = 1,
                IsDeleted = false,
                DeletedDate = DateTime.Now,
                DeletedBy = 1
            };

            var uowMock = new Mock<IUnitOfWorkService>();
            uowMock.Setup(o => o.lINKINGINFOService).Returns(() => _linkInfoService.Object);
            uowMock.Setup(m => m.lINKINGINFOService.UpdateLINKINFO(linkingInfoModel))
                        .Returns(Task.FromResult(linkingInfoModel));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateLINKINFO((int)linkingInfoModel.LinkingID, linkingInfoModel);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_LINKINFO_Shouldbe_OkResult_Test()
        {
            // Arrange
            // var linkingInfoModel = _fixture.CreateMany<LinkingInfoModel>(1);
            int id = 1;

            _unitOfWorkService.Setup(o => o.lINKINGINFOService).Returns(() => _linkInfoService.Object);

            var uowMock = new Mock<IUnitOfWorkService>();
            uowMock.Setup(o => o.lINKINGINFOService).Returns(() => _linkInfoService.Object);
            uowMock.Setup(m => m.lINKINGINFOService.DeleteLINKINFO(id))
                        .Returns(Task.FromResult(1));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteLINKINFO(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_LINKINFO_Shouldbe_BadObjectResult_Test()
        {
            // Arrange
            int id = 1;

            _unitOfWorkService.Setup(o => o.lINKINGINFOService).Returns(() => _linkInfoService.Object);

            var uowMock = new Mock<IUnitOfWorkService>();
            uowMock.Setup(o => o.lINKINGINFOService).Returns(() => _linkInfoService.Object);
            uowMock.Setup(m => m.lINKINGINFOService.DeleteLINKINFO(id))
                        .Returns(Task.FromResult(0));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteLINKINFO(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

       
    }
}
