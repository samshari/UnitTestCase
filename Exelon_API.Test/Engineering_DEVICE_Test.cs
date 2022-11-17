using AutoFixture;
using Exelon.Application.IServices;
using Exelon.Application.Service;
using Exelon.Domain;
using Exelon.Domain.Abstractions;
using Exelon.Infrastructure.Repositories;
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
    public class Engineering_DEVICE_Test
    {
        private Fixture _fixture;
        private Mock<IUnitOfWorkService> _unitOfWorkService;
        private ENGINEERINGController _engController;
        private Mock<IMDEVICEService> _imDeviceService;
        private Mock<IDeviceRepository> _iDeviceRepository;
        public Engineering_DEVICE_Test()
        {
            _fixture = new Fixture();
            _unitOfWorkService = new Mock<IUnitOfWorkService>();
            _engController = new ENGINEERINGController(_unitOfWorkService.Object);
            _imDeviceService = new Mock<IMDEVICEService>();
            _iDeviceRepository = new Mock<IDeviceRepository>();
        }

        [Fact]
        public async void Get_DEVICE_ShouldBe_OkResult_Test()
        {
            //Arrange
            var deviceModel = _fixture.CreateMany<DeviceModel>(3).ToList();

            _imDeviceService.Setup(r => r.GetDEVICE(1)).ReturnsAsync(deviceModel);

            //var deviceService = new DeviceService(_iDeviceRepository.Object);

            _unitOfWorkService.Setup(o => o.dEVICEService).Returns(_imDeviceService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);


            //Act
            var result = await _engController.GetDEVICE(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            result.Should().NotBeNull();

            Assert.Equal(deviceModel, resval);
        }

        [Fact]
        public async void Get_DEVICE_ShouldBe_NotFoundResult_Test()
        {
            //Arrange
            var deviceModel = _fixture.CreateMany<DeviceModel>(0).ToList();

            _imDeviceService.Setup(r => r.GetDEVICE(1)).ReturnsAsync(deviceModel);

            //var deviceService = new DeviceService(_iDeviceRepository.Object);

            _unitOfWorkService.Setup(o => o.dEVICEService).Returns(_imDeviceService.Object);

            _engController = new ENGINEERINGController(_unitOfWorkService.Object);


            //Act
            var result = await _engController.GetDEVICE(1);
            var resval = ((ObjectResult)result).Value;

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task Create_DEVICE_Shouldbe_OkResult_Test()
        {
            // Arrange
            var deviceModel = _fixture.CreateMany<DeviceModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<DeviceModel, string>();
            expectedRes.Add(deviceModel.FirstOrDefault(), "ok");
            uowMock.Setup(o => o.dEVICEService).Returns(() => _imDeviceService.Object);
            uowMock.Setup(m => m.dEVICEService.CreateDEVICE(deviceModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateDEVICE(deviceModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Create_DEVICE_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var deviceModel = _fixture.CreateMany<DeviceModel>(1);
            var uowMock = new Mock<IUnitOfWorkService>();
            var expectedRes = new Dictionary<DeviceModel, string>();
            expectedRes.Add(deviceModel.FirstOrDefault(), "NotOk");
            uowMock.Setup(o => o.dEVICEService).Returns(() => _imDeviceService.Object);
            uowMock.Setup(m => m.dEVICEService.CreateDEVICE(deviceModel.FirstOrDefault()))
                        .Returns(Task.FromResult(expectedRes));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.CreateDEVICE(deviceModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_DEVICE_Shouldbe_OkResult_Test()
        {
            // Arrange
            var deviceModel = _fixture.CreateMany<DeviceModel>(1);
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.dEVICEService).Returns(() => _imDeviceService.Object);
            uowMock.Setup(m => m.dEVICEService.UpdateDEVICE(deviceModel.FirstOrDefault()))
                        .Returns(Task.FromResult(deviceModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateDEVICE(id, deviceModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_DEVICE_Shouldbe_BadRequestObjectResult_Test()
        {
            // Arrange
            var deviceModel = _fixture.CreateMany<DeviceModel>(1);
            int id = 0;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.dEVICEService).Returns(() => _imDeviceService.Object);
            uowMock.Setup(m => m.dEVICEService.UpdateDEVICE(deviceModel.FirstOrDefault()))
                        .Returns(Task.FromResult(deviceModel.FirstOrDefault()));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.UpdateDEVICE(id, deviceModel.FirstOrDefault());

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DEVICE_Shouldbe_OkResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.dEVICEService).Returns(() => _imDeviceService.Object);
            uowMock.Setup(m => m.dEVICEService.DeleteDEVICE(id))
                        .Returns(Task.FromResult(1));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteDEVICE(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_DEVICE_Shouldbe_BadObjectResult_Test()
        {
            // Arrange
            int id = 1;
            var uowMock = new Mock<IUnitOfWorkService>();

            uowMock.Setup(o => o.dEVICEService).Returns(() => _imDeviceService.Object);
            uowMock.Setup(m => m.dEVICEService.DeleteDEVICE(id))
                        .Returns(Task.FromResult(0));
            _engController = new ENGINEERINGController(uowMock.Object);


            // Act
            var result = await _engController.DeleteDEVICE(id);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
