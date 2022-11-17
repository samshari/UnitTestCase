using AutoFixture;
using Exelon.API.Controllers;
using Exelon.Application.IServices;
using Exelon.Application.Service;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Exelon_API.Test
{
    public class Common_MEOCREALSTATE_Test
    {
        private Fixture _fixture;
        private CommonController _CommonController;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private Mock<IMEOCREALSTATERepository> _meocRealStateRepository;
        private Mock<IMEOCREALSTATEService> _meocRealStateService;

        public Common_MEOCREALSTATE_Test()
        {
            _fixture = new Fixture();
            
            _unitOfWorkService = new Mock<IUnitOfWorkService>();
            _meocRealStateRepository = new Mock<IMEOCREALSTATERepository>();
            _meocRealStateService = new Mock<IMEOCREALSTATEService>();

            _CommonController = new CommonController(_unitOfWorkService.Object);
        }

        [Fact]
        public async void Get_MEOCREALSTATE_ShouldBe_OkResult_Test()
        {
            //Arrange
            var meocRealStateModel = _fixture.CreateMany<MEOCREALSTATEModel>(3).ToList();

            _meocRealStateRepository.Setup(r => r.GetMEOCREALSTATE(1)).ReturnsAsync(meocRealStateModel);

            var meocRealStateService = new MEOCREALSTATEService(_meocRealStateRepository.Object);

            _unitOfWorkService.Setup(o => o.mEOCREALSTATEService).Returns(meocRealStateService);

            _CommonController = new CommonController(_unitOfWorkService.Object);



            //Act
            var result = await _CommonController.GetMEOCREALSTATE(1);

            //Assert
            result.Should().NotBeNull();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async void Get_MEOCREALSTATE_ShouldBe_NotFoundResult_Test()
        {
            //Arrange
            var meocRealStateModel = _fixture.CreateMany<MEOCREALSTATEModel>(0).ToList();

            _meocRealStateRepository.Setup(r => r.GetMEOCREALSTATE(1)).ReturnsAsync(meocRealStateModel);

            var meocRealStateService = new MEOCREALSTATEService(_meocRealStateRepository.Object);

            _unitOfWorkService.Setup(o => o.mEOCREALSTATEService).Returns(meocRealStateService);

            _CommonController = new CommonController(_unitOfWorkService.Object);



            //Act
            var result = await _CommonController.GetMEOCREALSTATE(1);

            //Assert
            result.Should().NotBeNull();
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_MEOCREALSTATE_Shouldbe_OkResult_Test()
        {
            // Arrange
             var meocRealStateModel = _fixture.CreateMany<MEOCREALSTATEModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<MEOCREALSTATEModel, string>();
            expectedRes.Add(meocRealStateModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.mEOCREALSTATEService).Returns(() => _meocRealStateService.Object);
            uowMock.Setup(m => m.mEOCREALSTATEService.CreateMEOCREALSTATE(meocRealStateModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _CommonController = new CommonController(uowMock.Object);


            // Act
            var result = await _CommonController.CreateMEOCREALSTATE(meocRealStateModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_MEOCREALSTATE_Shouldbe_BadObjectResult_Test()
        {
            // Arrange
            var meocRealStateModel = _fixture.CreateMany<MEOCREALSTATEModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<MEOCREALSTATEModel, string>();
            expectedRes.Add(meocRealStateModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.mEOCREALSTATEService).Returns(() => _meocRealStateService.Object);
            uowMock.Setup(m => m.mEOCREALSTATEService.CreateMEOCREALSTATE(meocRealStateModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _CommonController = new CommonController(uowMock.Object);


            // Act
            var result = await _CommonController.CreateMEOCREALSTATE(meocRealStateModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_MEOCREALSTATE_Shouldbe_OkResult_Test()
        {
            // Arrange
            var meocRealStateModel = _fixture.CreateMany<MEOCREALSTATEModel>(1);
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<MEOCREALSTATEModel, string>();
            expectedRes.Add(meocRealStateModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.mEOCREALSTATEService).Returns(() => _meocRealStateService.Object);
            uowMock.Setup(m => m.mEOCREALSTATEService.UpdateMEOCREALSTATE(meocRealStateModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _CommonController = new CommonController(uowMock.Object);


            // Act
            var result = await _CommonController.UpdateMEOCREALSTATE(id,meocRealStateModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_MEOCREALSTATE_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var meocRealStateModel = _fixture.CreateMany<MEOCREALSTATEModel>(1);
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<MEOCREALSTATEModel, string>();
            expectedRes.Add(meocRealStateModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.mEOCREALSTATEService).Returns(() => _meocRealStateService.Object);
            uowMock.Setup(m => m.mEOCREALSTATEService.UpdateMEOCREALSTATE(meocRealStateModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _CommonController = new CommonController(uowMock.Object);


            // Act
            var result = await _CommonController.UpdateMEOCREALSTATE(id, meocRealStateModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_MEOCREALSTATE_Shouldbe_OkResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();
            uowMock.Setup(o => o.mEOCREALSTATEService).Returns(() => _meocRealStateService.Object);
            uowMock.Setup(m => m.mEOCREALSTATEService.DeleteMEOCREALSTATE(id))
                        .Returns(Task.FromResult(0));
            _CommonController = new CommonController(uowMock.Object);


            // Act
            var result = await _CommonController.DeleteMEOCREALSTATE(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_MEOCREALSTATE_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            int id = 1;

            var uowMock = new Mock<IUnitOfWorkService>();
            uowMock.Setup(o => o.mEOCREALSTATEService).Returns(() => _meocRealStateService.Object);
            uowMock.Setup(m => m.mEOCREALSTATEService.DeleteMEOCREALSTATE(id))
                        .Returns(Task.FromResult(1));
            _CommonController = new CommonController(uowMock.Object);


            // Act
            var result = await _CommonController.DeleteMEOCREALSTATE(1);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }


    }
}
