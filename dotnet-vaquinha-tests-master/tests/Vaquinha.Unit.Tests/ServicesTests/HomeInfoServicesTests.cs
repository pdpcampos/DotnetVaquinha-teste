using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Vaquinha.Domain;
using Vaquinha.Domain.ViewModels;
using Vaquinha.Service;
using Xunit;

namespace Vaquinha.Unit.Tests.ServicesTests
{
    public class HomeInfoServicesTests
    {
        private readonly Mock<IHomeInfoRepository> _homeInfoRepository = new Mock<IHomeInfoRepository>();
        private readonly Mock<ICausaRepository> _causaRepository = new Mock<ICausaRepository>();

        private HomeInfoService _homeInfoServices;
        private readonly IDoacaoService _doacaoIService;

        private Mock<IMapper> _mapper;
        
        private readonly GloballAppConfig _globalSettings;

        public HomeInfoServicesTests()
        {
            _mapper = new Mock<IMapper>();

            _homeInfoServices = new HomeInfoService(_mapper.Object, _doacaoIService, _globalSettings, _homeInfoRepository.Object, _causaRepository.Object);
        }

        [Fact]
        [Trait("HomeInfoService", "HomeInfo_RecuperarDadosIniciaisHomeAsync_Valido")]
        public void HomeInfo_RecuperarDadosIniciaisHomeAsync_Valido()
        {
            // Arrange
            _homeInfoServices = new HomeInfoService(_mapper.Object, _doacaoIService, _globalSettings, _homeInfoRepository.Object, _causaRepository.Object);

            // Act
            var retorno = _homeInfoServices.RecuperarDadosIniciaisHomeAsync();

            Assert.True(retorno.IsCompleted);
        }

        [Fact]
        [Trait("HomeInfoService", "HomeInfo_RecuperarDadosIniciaisHomeAsync_Invalido")]
        public void HomeInfo_RecuperarDadosIniciaisHomeAsync_Invalido()
        {
            // Arrange
            _homeInfoServices = new HomeInfoService(_mapper.Object, _doacaoIService, _globalSettings, null, null);

            // Act
            var retorno = _homeInfoServices.RecuperarDadosIniciaisHomeAsync();

            Assert.False(retorno == null);
        }

        [Fact]
        [Trait("HomeInfoService", "HomeInfo_RecuperarCausasAsync_Valido")]
        public void HomeInfo_RecuperarCausasAsync_Valido()
        {
            // Arrange
            _homeInfoServices = new HomeInfoService(_mapper.Object, _doacaoIService, _globalSettings, _homeInfoRepository.Object, _causaRepository.Object);

            // Act
            var retorno = _homeInfoServices.RecuperarCausasAsync();

            Assert.True(retorno.IsCompleted);
        }

        [Fact]
        [Trait("HomeInfoService", "HomeInfo_RecuperarCausasAsync_Invalido")]
        public void HomeInfo_RecuperarCausasAsync_Invalido()
        {
            // Arrange
            _homeInfoServices = new HomeInfoService(_mapper.Object, _doacaoIService, _globalSettings, null, null);

            // Act
            var retorno = _homeInfoServices.RecuperarCausasAsync();

            Assert.False(retorno == null);
        }
    }
}
