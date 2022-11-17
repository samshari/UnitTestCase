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

    public class Engineering_IFC_FIBER_Test
    {
        private Fixture _fixture;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private ENGINEERINGController _engController;
        private Mock<IIFCFIBERRepository> _ifcFiberRepository;
        private Mock<IIfcFiberService> _ifcFiberService;

        public Engineering_IFC_FIBER_Test()
            {
            _fixture = new Fixture();
            _unitOfWorkService = new Mock<IUnitOfWorkService>();
            _engController = new ENGINEERINGController(_unitOfWorkService.Object);
            _ifcFiberRepository = new Mock<IIFCFIBERRepository>();
            _ifcFiberService = new Mock<IIfcFiberService>();
        }

        [Fact]
        public async void Get_IFCFIBER_ShouldBe_OkResult_Test()
        {
            //Arrange
            var ifcFiberModel = _fixture.CreateMany<IfcFiberModel>(3).ToList();

            _ifcFiberRepository.Setup(r => r.GetIFCFIBER(1)).ReturnsAsync(ifcFiberModel);

            var ifcFiberService = new IfcFiberService(_ifcFiberRepository.Object);

            _unitOfWorkService.Setup(o => o.ifcFiberService).Returns(ifcFiberService);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetIFCFIBER(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            result.Should().NotBeNull();

            Assert.Equal(ifcFiberModel, resval);
        }

        [Fact]
        public async void Get_IFCFIBER_ShouldBe_NotFoundResult_Test()
        {
            //Arrange
            var ifcFiberModel = _fixture.CreateMany<IfcFiberModel>(0).ToList();

            _ifcFiberRepository.Setup(r => r.GetIFCFIBER(1)).ReturnsAsync(ifcFiberModel);

            var ifcFiberService = new IfcFiberService(_ifcFiberRepository.Object);

            _unitOfWorkService.Setup(o => o.ifcFiberService).Returns(ifcFiberService);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetIFCFIBER(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_IFCFIBER_Shouldbe_OkResult_Test()
        {
            // Arrange
            var ifcFiberModel = _fixture.CreateMany<IfcFiberModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfcFiberModel, string>();
            expectedRes.Add(ifcFiberModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.ifcFiberService).Returns(() => _ifcFiberService.Object);
            uowMock.Setup(m => m.ifcFiberService.CreateIFCFIBER(ifcFiberModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateIFCFIBER(ifcFiberModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_IFCFIBER_Shouldbe_BadObjectResult_Test()
        {
            // Arrange
            var ifcFiberModel = _fixture.CreateMany<IfcFiberModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfcFiberModel, string>();
            expectedRes.Add(ifcFiberModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.ifcFiberService).Returns(() => _ifcFiberService.Object);
            uowMock.Setup(m => m.ifcFiberService.CreateIFCFIBER(ifcFiberModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateIFCFIBER(ifcFiberModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_IFCFIBER_Shouldbe_OkResult_Test()
        {
            // Arrange
            var ifcFiberModel = _fixture.CreateMany<IfcFiberModel>(1);
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfcFiberModel, string>();
            expectedRes.Add(ifcFiberModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.ifcFiberService).Returns(() => _ifcFiberService.Object);
            uowMock.Setup(m => m.ifcFiberService.UpdateIFCFIBER(ifcFiberModel.FirstOrDefault()))
                        .Returns(Task.FromResult(ifcFiberModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateIFCFIBER(id, ifcFiberModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_IFCFIBER_Shouldbe_BadObjectResult_Test()
        {
            // Arrange
            var ifcFiberModel = _fixture.CreateMany<IfcFiberModel>(1);
            int id = 0;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfcFiberModel, string>();
            expectedRes.Add(ifcFiberModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.ifcFiberService).Returns(() => _ifcFiberService.Object);
            uowMock.Setup(m => m.ifcFiberService.UpdateIFCFIBER(ifcFiberModel.FirstOrDefault()))
                        .Returns(Task.FromResult(ifcFiberModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateIFCFIBER(id, ifcFiberModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_IFCFIBER_Shouldbe_OkObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.ifcFiberService).Returns(() => _ifcFiberService.Object);
            uowMock.Setup(m => m.ifcFiberService.DeleteIFCFIBER(id))
                        .Returns(Task.FromResult(1));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteIFCFIBER(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_IFCFIBER_Shouldbe_BadObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.ifcFiberService).Returns(() => _ifcFiberService.Object);
            uowMock.Setup(m => m.ifcFiberService.DeleteIFCFIBER(id))
                        .Returns(Task.FromResult(0));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteIFCFIBER(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

    }
}
