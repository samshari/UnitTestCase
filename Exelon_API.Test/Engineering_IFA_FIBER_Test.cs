using AutoFixture;
using Exelon.Application.IServices;
using Exelon.Application.Service;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using ExelonPOC.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Exelon_API.Test
{
    public class Engineering_IFA_FIBER_Test
    {
        private Fixture _fixture;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private ENGINEERINGController _engController;
        private Mock<IIfaFiberRepository> _ifaFiberRepository;
        private Mock<IIfaFiberService> _ifaFiberService;
        public Engineering_IFA_FIBER_Test()
        {
            _fixture = new Fixture();

            _unitOfWorkService = new Mock<IUnitOfWorkService>();
            _ifaFiberRepository = new Mock<IIfaFiberRepository>();
            _ifaFiberService = new Mock<IIfaFiberService>();

            
        }

        [Fact]
        public async void Get_IFAFIBER_ShouldBe_OkResult_Test()
        {
            //Arrange
            var ifaFiberModel = _fixture.CreateMany<IfaFiberModel>(3).ToList();

            _ifaFiberRepository.Setup(r => r.GetIFAFIBER(1)).ReturnsAsync(ifaFiberModel);

            var ifaFiberService = new IfaFiberService(_ifaFiberRepository.Object);

            _unitOfWorkService.Setup(o => o.ifaFiberService).Returns(ifaFiberService);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetIFAFIBER(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            result.Should().NotBeNull();

            Assert.Equal(ifaFiberModel, resval);
        }

        [Fact]
        public async void Get_IFAFIBER_ShouldBe_NotFoundResult_Test()
        {
            //Arrange
            var ifaFiberModel = _fixture.CreateMany<IfaFiberModel>(0).ToList();

            _ifaFiberRepository.Setup(r => r.GetIFAFIBER(1)).ReturnsAsync(ifaFiberModel);

            var ifaFiberService = new IfaFiberService(_ifaFiberRepository.Object);

            _unitOfWorkService.Setup(o => o.ifaFiberService).Returns(ifaFiberService);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetIFAFIBER(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Create_IFAFIBER_Shouldbe_OkResult_Test()
        {
            // Arrange
            var ifaFiberModel = _fixture.CreateMany<IfaFiberModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfaFiberModel, string>();
            expectedRes.Add(ifaFiberModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.ifaFiberService).Returns(() => _ifaFiberService.Object);
            uowMock.Setup(m => m.ifaFiberService.CreateIFAFIBER(ifaFiberModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateIFAFIBER(ifaFiberModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_IFAFIBER_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var ifaFiberModel = _fixture.CreateMany<IfaFiberModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfaFiberModel, string>();
            expectedRes.Add(ifaFiberModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.ifaFiberService).Returns(() => _ifaFiberService.Object);
            uowMock.Setup(m => m.ifaFiberService.CreateIFAFIBER(ifaFiberModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateIFAFIBER(ifaFiberModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_IFAFIBER_Shouldbe_OkResult_Test()
        {
            // Arrange
            var ifaFiberModel = _fixture.CreateMany<IfaFiberModel>(1);
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfaFiberModel, string>();
            expectedRes.Add(ifaFiberModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.ifaFiberService).Returns(() => _ifaFiberService.Object);
            uowMock.Setup(m => m.ifaFiberService.UpdateIFAFIBER(ifaFiberModel.FirstOrDefault()))
                        .Returns(Task.FromResult(ifaFiberModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateIFAFIBER(id, ifaFiberModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_IFAFIBER_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var ifaFiberModel = _fixture.CreateMany<IfaFiberModel>(1);
            int id = 0;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<IfaFiberModel, string>();
            expectedRes.Add(ifaFiberModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.ifaFiberService).Returns(() => _ifaFiberService.Object);
            uowMock.Setup(m => m.ifaFiberService.UpdateIFAFIBER(ifaFiberModel.FirstOrDefault()))
                        .Returns(Task.FromResult(ifaFiberModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateIFAFIBER(id, ifaFiberModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_IFAFIBER_Shouldbe_OkObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();
           
            uowMock.Setup(o => o.ifaFiberService).Returns(() => _ifaFiberService.Object);
            uowMock.Setup(m => m.ifaFiberService.DeleteIFAFIBER(id))
                        .Returns(Task.FromResult(1));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteIFAFIBER(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_IFAFIBER_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.ifaFiberService).Returns(() => _ifaFiberService.Object);
            uowMock.Setup(m => m.ifaFiberService.DeleteIFAFIBER(id))
                        .Returns(Task.FromResult(0));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteIFAFIBER(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
