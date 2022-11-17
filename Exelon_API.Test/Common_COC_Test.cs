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
    public class Common_COC_Test
    {
        private Fixture _fixture;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private CommonController _commonController;
        private Mock<IMCOCMASTERService> _iMCOCMasterService;
        public Common_COC_Test()
        {
            _fixture = new Fixture();
            _unitOfWorkService = new Mock<IUnitOfWorkService>();
            _commonController = new CommonController(_unitOfWorkService.Object);
            _iMCOCMasterService = new Mock<IMCOCMASTERService>();
        }

        [Fact]
        public async void Get_COC_ShouldBe_OkResult_Test()
        {
            //Arrange
            var mcocMasterModel = _fixture.CreateMany<MCOCMASTERModel>(3).ToList();

            _iMCOCMasterService.Setup(r => r.GetCOC(1)).ReturnsAsync(mcocMasterModel);

            //var mcocMasterService = new MCOCMASTERService(_iMCOCMASTERRepository.Object);

            _unitOfWorkService.Setup(o => o.mCOCMASTERService).Returns(_iMCOCMasterService.Object);

            _commonController = new CommonController(_unitOfWorkService.Object);



            //Act
            var result = await _commonController.GetCOCMaster(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            result.Should().NotBeNull();

            Assert.Equal(mcocMasterModel, resval);
        }

        [Fact]
        public async void Get_COC_ShouldBe_NotFoundResult_Test()
        {
            //Arrange
            var mcocMasterModel = _fixture.CreateMany<MCOCMASTERModel>(0).ToList();

            _iMCOCMasterService.Setup(r => r.GetCOC(1)).ReturnsAsync(mcocMasterModel);

            //var mcocMasterService = new MCOCMASTERService(_iMCOCMASTERRepository.Object);

            _unitOfWorkService.Setup(o => o.mCOCMASTERService).Returns(_iMCOCMasterService.Object);

            _commonController = new CommonController(_unitOfWorkService.Object);



            //Act
            var result = await _commonController.GetCOCMaster(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_COC_Shouldbe_OkResult_Test()
        {
            // Arrange
            var mcocMasterModel = _fixture.CreateMany<MCOCMASTERModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<MCOCMASTERModel, string>();
            expectedRes.Add(mcocMasterModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.mCOCMASTERService).Returns(() => _iMCOCMasterService.Object);
            uowMock.Setup(m => m.mCOCMASTERService.CreateCOC(mcocMasterModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _commonController = new CommonController(uowMock.Object);


            // Act
            var result = await _commonController.CreateCOCMaster(mcocMasterModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_COC_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var mcocMasterModel = _fixture.CreateMany<MCOCMASTERModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<MCOCMASTERModel, string>();
            expectedRes.Add(mcocMasterModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.mCOCMASTERService).Returns(() => _iMCOCMasterService.Object);
            uowMock.Setup(m => m.mCOCMASTERService.CreateCOC(mcocMasterModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _commonController = new CommonController(uowMock.Object);


            // Act
            var result = await _commonController.CreateCOCMaster(mcocMasterModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_COC_Shouldbe_OkResult_Test()
        {
            // Arrange
            int id = 1;
            var mcocMasterModel = _fixture.CreateMany<MCOCMASTERModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
        
            uowMock.Setup(o => o.mCOCMASTERService).Returns(() => _iMCOCMasterService.Object);
            uowMock.Setup(m => m.mCOCMASTERService.UpdateCOC(mcocMasterModel.FirstOrDefault()))
                        .Returns(Task.FromResult(mcocMasterModel.FirstOrDefault()));
            _commonController = new CommonController(uowMock.Object);


            // Act
            var result = await _commonController.UpdateCOCMaster(id, mcocMasterModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_COC_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            int id = 0;
            var mcocMasterModel = _fixture.CreateMany<MCOCMASTERModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.mCOCMASTERService).Returns(() => _iMCOCMasterService.Object);
            uowMock.Setup(m => m.mCOCMASTERService.UpdateCOC(mcocMasterModel.FirstOrDefault()))
                        .Returns(Task.FromResult(mcocMasterModel.FirstOrDefault()));
            _commonController = new CommonController(uowMock.Object);


            // Act
            var result = await _commonController.UpdateCOCMaster(id, mcocMasterModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_COC_Shouldbe_OkObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.mCOCMASTERService).Returns(() => _iMCOCMasterService.Object);
            uowMock.Setup(m => m.mCOCMASTERService.DeleteCOC(id))
                        .Returns(Task.FromResult(1));
            _commonController = new CommonController(uowMock.Object);


            // Act
            var result = await _commonController.DeleteCOCMaster(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }


        [Fact]
        public async Task Delete_COC_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.mCOCMASTERService).Returns(() => _iMCOCMasterService.Object);
            uowMock.Setup(m => m.mCOCMASTERService.DeleteCOC(id))
                        .Returns(Task.FromResult(0));
            _commonController = new CommonController(uowMock.Object);


            // Act
            var result = await _commonController.DeleteCOCMaster(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
