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
    public class Engineering_IFC_MAKE_READY_Test
    {
        private Fixture _fixture;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private ENGINEERINGController _engController;
        private Mock<IIfcReadyService> _ifcReadyService;
        private Mock<IIfcReadyRepository> _ifcReadyRepository;

        public Engineering_IFC_MAKE_READY_Test()
        {
            _fixture = new Fixture();
            _unitOfWorkService = new Mock<IUnitOfWorkService>();
            _engController = new ENGINEERINGController(_unitOfWorkService.Object);
            _ifcReadyService = new Mock<IIfcReadyService>();
            _ifcReadyRepository = new Mock<IIfcReadyRepository>();
        }

        [Fact]
        public async void Get_IFCREADY_ShouldBe_OkResult_Test()
        {
            //Arrange
            var ifcReadyModel = _fixture.CreateMany<IfcReadyModel>(3).ToList();

            _ifcReadyService.Setup(r => r.GetIFC(1)).ReturnsAsync(ifcReadyModel);

            var ifcReadyService = new IfcReadyService(_ifcReadyRepository.Object);

            _unitOfWorkService.Setup(o => o.iFCREADYService).Returns(_ifcReadyService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetIFC(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            result.Should().NotBeNull();

            Assert.Equal(ifcReadyModel, resval);
        }

        [Fact]
        public async void Get_IFCREADY_ShouldBe_NotFoundResult_Test()
        {
            //Arrange
            var ifcReadyModel = _fixture.CreateMany<IfcReadyModel>(0).ToList();

            _ifcReadyService.Setup(r => r.GetIFC(1)).ReturnsAsync(ifcReadyModel);

            var ifcReadyService = new IfcReadyService(_ifcReadyRepository.Object);

            _unitOfWorkService.Setup(o => o.iFCREADYService).Returns(_ifcReadyService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetIFC(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_IFCREADY_Shouldbe_OkResult_Test()
        {
            // Arrange
            var ifcReadyModel = _fixture.CreateMany<IfcReadyModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfcReadyModel, string>();
            expectedRes.Add(ifcReadyModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.iFCREADYService).Returns(() => _ifcReadyService.Object);
            uowMock.Setup(m => m.iFCREADYService.CreateIFC(ifcReadyModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateIFC(ifcReadyModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_IFCREADY_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var ifcReadyModel = _fixture.CreateMany<IfcReadyModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfcReadyModel, string>();
            expectedRes.Add(ifcReadyModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.iFCREADYService).Returns(() => _ifcReadyService.Object);
            uowMock.Setup(m => m.iFCREADYService.CreateIFC(ifcReadyModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateIFC(ifcReadyModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_IFCREADY_Shouldbe_OkResult_Test()
        {
            // Arrange
            var ifcReadyModel = _fixture.CreateMany<IfcReadyModel>(1);
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();
            
            uowMock.Setup(o => o.iFCREADYService).Returns(() => _ifcReadyService.Object);
            uowMock.Setup(m => m.iFCREADYService.UpdateIFC(ifcReadyModel.FirstOrDefault()))
                        .Returns(Task.FromResult(ifcReadyModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateIFC(id, ifcReadyModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_IFCREADY_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var ifcReadyModel = _fixture.CreateMany<IfcReadyModel>(1);
            int id = 0;
            var uowMock = new Mock<IUnitOfWorkService>();
          
            uowMock.Setup(o => o.iFCREADYService).Returns(() => _ifcReadyService.Object);
            uowMock.Setup(m => m.iFCREADYService.UpdateIFC(ifcReadyModel.FirstOrDefault()))
                        .Returns(Task.FromResult<IfcReadyModel>(null));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateIFC(id, ifcReadyModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_IFCREADY_Shouldbe_OkObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.iFCREADYService).Returns(() => _ifcReadyService.Object);
            uowMock.Setup(m => m.iFCREADYService.DeleteIFC(id))
                        .Returns(Task.FromResult(1));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteIFC(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_IFCREADY_Shouldbe_BadObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.iFCREADYService).Returns(() => _ifcReadyService.Object);
            uowMock.Setup(m => m.iFCREADYService.DeleteIFC(id))
                        .Returns(Task.FromResult(0));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteIFC(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
