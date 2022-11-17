using AutoFixture;
using Exelon.API.Controllers;
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
    public class Engineering_Design_Miles_Test
    {
        private Fixture _fixture;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private ENGINEERINGController _engController;
        private Mock<IDesignMilesService> _iDesignMilesService;
        private Mock<IDesignMilesRepository> _designMilesRepository;
        public Engineering_Design_Miles_Test()
        {
            _fixture = new Fixture();
            _unitOfWorkService = new Mock<IUnitOfWorkService>();
            _engController = new ENGINEERINGController(_unitOfWorkService.Object);
            _iDesignMilesService = new Mock<IDesignMilesService>();
            _designMilesRepository = new Mock<IDesignMilesRepository>();
        }

        [Fact]
        public async void Get_DESIGN_ShouldBe_OkResult_Test()
        {
            //Arrange
            var designMilesModel = _fixture.CreateMany<DesignMilesModel>(3).ToList();

            _iDesignMilesService.Setup(r => r.GetDESIGN(1)).ReturnsAsync(designMilesModel);

            _unitOfWorkService.Setup(o => o.dESIGNMILESService).Returns(_iDesignMilesService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetDESIGN(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            result.Should().NotBeNull();

            Assert.Equal(designMilesModel, resval);
        }


        [Fact]
        public async void Get_DESIGN_ShouldBe_NotFoundObjectResult_Test()
        {
            //Arrange
            var designMilesModel = _fixture.CreateMany<DesignMilesModel>(0).ToList();

            _iDesignMilesService.Setup(r => r.GetDESIGN(1)).ReturnsAsync(designMilesModel);

            _unitOfWorkService.Setup(o => o.dESIGNMILESService).Returns(_iDesignMilesService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);



            //Act
            var result = await _engController.GetDESIGN(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);


        }

        [Fact]
        public async Task Create_DESIGNMILES_Shouldbe_OkResult_Test()
        {
            // Arrange
            var designMilesModel = _fixture.CreateMany<DesignMilesModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<DesignMilesModel, string>();
            expectedRes.Add(designMilesModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.dESIGNMILESService).Returns(() => _iDesignMilesService.Object);
            uowMock.Setup(m => m.dESIGNMILESService.CreateDESIGN(designMilesModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateDESIGN(designMilesModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_DESIGNMILES_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var designMilesModel = _fixture.CreateMany<DesignMilesModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<DesignMilesModel, string>();
            expectedRes.Add(designMilesModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.dESIGNMILESService).Returns(() => _iDesignMilesService.Object);
            uowMock.Setup(m => m.dESIGNMILESService.CreateDESIGN(designMilesModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateDESIGN(designMilesModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_DESIGNMILES_Shouldbe_OkResult_Test()
        {
            // Arrange
            var designMilesModel = _fixture.CreateMany<DesignMilesModel>(1);
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<DesignMilesModel, string>();
            expectedRes.Add(designMilesModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.dESIGNMILESService).Returns(() => _iDesignMilesService.Object);
            uowMock.Setup(m => m.dESIGNMILESService.UpdateDESIGN(designMilesModel.FirstOrDefault()))
                        .Returns(Task.FromResult(designMilesModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateDESIGN(id, designMilesModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_DESIGNMILES_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var designMilesModel = _fixture.CreateMany<DesignMilesModel>(1);
            int id = 0;
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<DesignMilesModel, string>();
            expectedRes.Add(designMilesModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.dESIGNMILESService).Returns(() => _iDesignMilesService.Object);
            uowMock.Setup(m => m.dESIGNMILESService.UpdateDESIGN(designMilesModel.FirstOrDefault()))
                        .Returns(Task.FromResult(designMilesModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateDESIGN(id, designMilesModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DESIGNMILES_Shouldbe_OkObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.dESIGNMILESService).Returns(() => _iDesignMilesService.Object);
            uowMock.Setup(m => m.dESIGNMILESService.DeleteDESIGN(id))
                        .Returns(Task.FromResult(1));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteDESIGN(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DESIGNMILES_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.dESIGNMILESService).Returns(() => _iDesignMilesService.Object);
            uowMock.Setup(m => m.dESIGNMILESService.DeleteDESIGN(id))
                        .Returns(Task.FromResult(0));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteDESIGN(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
