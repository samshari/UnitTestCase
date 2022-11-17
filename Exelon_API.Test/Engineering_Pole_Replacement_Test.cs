using AutoFixture;
using Exelon.Application.IServices;
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
    public class Engineering_Pole_Replacement_Test
    {
        private Fixture _fixture;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private ENGINEERINGController _engController;
        private Mock<IPPREPLACEMENTService> _ireplacementService;
        private Mock<IPPReplacementRepository> _ireplacementRepository;
        public Engineering_Pole_Replacement_Test()
        {
            _fixture = new Fixture();
            _unitOfWorkService = new Mock<IUnitOfWorkService>();
            _engController = new ENGINEERINGController(_unitOfWorkService.Object);
            _ireplacementService = new Mock<IPPREPLACEMENTService>();
            _ireplacementRepository = new Mock<IPPReplacementRepository>();
        }

        [Fact]
        public async void Get_POLE_REPLACE_ShouldBe_OkResult_Test()
        {
            //Arrange
            var poleReplacementModel = _fixture.CreateMany<PPREPLACEMENTModel>(3).ToList();

            _ireplacementService.Setup(r => r.GetPPREPLACE(1)).ReturnsAsync(poleReplacementModel);


            _unitOfWorkService.Setup(o => o.pPREPLACEMENTService).Returns(_ireplacementService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);


            //Act
            var result = await _engController.GetPPREPLACE(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            result.Should().NotBeNull();

            Assert.Equal(poleReplacementModel, resval);
        }

        [Fact]
        public async void Get_POLE_REPLACE_ShouldBe_NotFoundResult_Test()
        {
            //Arrange
            var poleReplacementModel = _fixture.CreateMany<PPREPLACEMENTModel>(0).ToList();

            _ireplacementService.Setup(r => r.GetPPREPLACE(1)).ReturnsAsync(poleReplacementModel);


            _unitOfWorkService.Setup(o => o.pPREPLACEMENTService).Returns(_ireplacementService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);


            //Act
            var result = await _engController.GetPPREPLACE(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_POLE_REPLACEMENT_Shouldbe_OkResult_Test()
        {
            // Arrange
            var poleReplacementModel = _fixture.CreateMany<PPREPLACEMENTModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<PPREPLACEMENTModel, string>();
            expectedRes.Add(poleReplacementModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.pPREPLACEMENTService).Returns(() => _ireplacementService.Object);
            uowMock.Setup(m => m.pPREPLACEMENTService.CreatePPREPLACE(poleReplacementModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreatePPREPLACE(poleReplacementModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_POLE_REPLACEMENT_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var poleReplacementModel = _fixture.CreateMany<PPREPLACEMENTModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<PPREPLACEMENTModel, string>();
            expectedRes.Add(poleReplacementModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.pPREPLACEMENTService).Returns(() => _ireplacementService.Object);
            uowMock.Setup(m => m.pPREPLACEMENTService.CreatePPREPLACE(poleReplacementModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreatePPREPLACE(poleReplacementModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_POLE_REPLACEMENT_Shouldbe_OkResult_Test()
        {
            // Arrange
            var poleReplacementModel = _fixture.CreateMany<PPREPLACEMENTModel>(1);
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.pPREPLACEMENTService).Returns(() => _ireplacementService.Object);
            uowMock.Setup(m => m.pPREPLACEMENTService.UpdatePPREPLACE(poleReplacementModel.FirstOrDefault()))
                        .Returns(Task.FromResult(poleReplacementModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdatePPREPLACE(id, poleReplacementModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_POLE_REPLACEMENT_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var poleReplacementModel = _fixture.CreateMany<PPREPLACEMENTModel>(1);
            int id = 0;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.pPREPLACEMENTService).Returns(() => _ireplacementService.Object);
            uowMock.Setup(m => m.pPREPLACEMENTService.UpdatePPREPLACE(poleReplacementModel.FirstOrDefault()))
                        .Returns(Task.FromResult(poleReplacementModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdatePPREPLACE(id, poleReplacementModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_POLE_REPLACEMENT_Shouldbe_OkResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.pPREPLACEMENTService).Returns(() => _ireplacementService.Object);
            uowMock.Setup(m => m.pPREPLACEMENTService.DeletePPREPLACE(id))
                        .Returns(Task.FromResult(1));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeletePPREPLACE(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_POLE_REPLACEMENT_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.pPREPLACEMENTService).Returns(() => _ireplacementService.Object);
            uowMock.Setup(m => m.pPREPLACEMENTService.DeletePPREPLACE(id))
                        .Returns(Task.FromResult(0));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeletePPREPLACE(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
