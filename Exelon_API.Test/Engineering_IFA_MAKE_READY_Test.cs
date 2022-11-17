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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Exelon_API.Test
{
    public class Engineering_IFA_MAKE_READY_Test
    {
        private Fixture _fixture;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private ENGINEERINGController _engController;
        private Mock<IIfaReadyService> _ifaReadyService;
        private Mock<IIfaReadyRepository> _ifaReadyRepository;
        public Engineering_IFA_MAKE_READY_Test()
        {
            _fixture = new Fixture();
            _unitOfWorkService = new Mock<IUnitOfWorkService>();
            _engController = new ENGINEERINGController(_unitOfWorkService.Object);
            _ifaReadyService = new Mock<IIfaReadyService>();
            _ifaReadyRepository = new Mock<IIfaReadyRepository>();
        }

        [Fact]
        public async void Get_IFAREADY_ShouldBe_OkResult_Test()
        {
            //Arrange
            var ifaReadyModel = _fixture.CreateMany<IfaReadyModel>(3).ToList();

            _ifaReadyService.Setup(r => r.GetIFA(1)).ReturnsAsync(ifaReadyModel);

            var ifaReadyService = new IfaReadyService(_ifaReadyRepository.Object);

            _unitOfWorkService.Setup(o => o.iFAREADYService).Returns(_ifaReadyService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetIFA(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            result.Should().NotBeNull();

            Assert.Equal(ifaReadyModel, resval);
        }


        [Fact]
        public async void Get_IFAREADY_ShouldBe_NotFoundResult_Test()
        {
            //Arrange
            var ifaReadyModel = _fixture.CreateMany<IfaReadyModel>(0).ToList();

            _ifaReadyService.Setup(r => r.GetIFA(1)).ReturnsAsync(ifaReadyModel);

            var ifaReadyService = new IfaReadyService(_ifaReadyRepository.Object);

            _unitOfWorkService.Setup(o => o.iFAREADYService).Returns(_ifaReadyService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetIFA(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_IFAREADY_Shouldbe_OkResult_Test()
        {
            // Arrange
            var ifaReadyModel = _fixture.CreateMany<IfaReadyModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfaReadyModel, string>();
            expectedRes.Add(ifaReadyModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.iFAREADYService).Returns(() => _ifaReadyService.Object);
            uowMock.Setup(m => m.iFAREADYService.CreateIFA(ifaReadyModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateIFA(ifaReadyModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_IFAREADY_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var ifaReadyModel = _fixture.CreateMany<IfaReadyModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfaReadyModel, string>();
            expectedRes.Add(ifaReadyModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.iFAREADYService).Returns(() => _ifaReadyService.Object);
            uowMock.Setup(m => m.iFAREADYService.CreateIFA(ifaReadyModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateIFA(ifaReadyModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_IFAREADY_Shouldbe_OkResult_Test()
        {
            // Arrange
            var ifaReadyModel = _fixture.CreateMany<IfaReadyModel>(1);
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfaReadyModel, string>();
            expectedRes.Add(ifaReadyModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.iFAREADYService).Returns(() => _ifaReadyService.Object);
            uowMock.Setup(m => m.iFAREADYService.UpdateIFA(ifaReadyModel.FirstOrDefault()))
                        .Returns(Task.FromResult(ifaReadyModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateIFA(id, ifaReadyModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_IFAREADY_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var ifaReadyModel = _fixture.CreateMany<IfaReadyModel>(1);
            int id = 0;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfaReadyModel, string>();
            expectedRes.Add(ifaReadyModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.iFAREADYService).Returns(() => _ifaReadyService.Object);
            uowMock.Setup(m => m.iFAREADYService.UpdateIFA(ifaReadyModel.FirstOrDefault()))
                        .Returns(Task.FromResult<IfaReadyModel>(null));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateIFA(id,ifaReadyModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_IFAREADY_Shouldbe_OkObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.iFAREADYService).Returns(() => _ifaReadyService.Object);
            uowMock.Setup(m => m.iFAREADYService.DeleteIFA(id))
                        .Returns(Task.FromResult(1));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteIFA(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_IFAREADY_Shouldbe_BadObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.iFAREADYService).Returns(() => _ifaReadyService.Object);
            uowMock.Setup(m => m.iFAREADYService.DeleteIFA(id))
                        .Returns(Task.FromResult(0));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteIFA(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
