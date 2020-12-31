using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Vaquinha.Domain;
using Vaquinha.Domain.Entities;
using Vaquinha.Domain.ViewModels;
using Vaquinha.Service;
using Vaquinha.Tests.Common.Fixtures;
using Xunit;

namespace Vaquinha.Unit.Tests.ServicesTests
{
    [Collection(nameof(CausaFixtureCollection))]
    public class CausaServicesTest : IClassFixture<CausaFixture>
    {
        private readonly Mock<ICausaRepository> _causaRepository = new Mock<ICausaRepository>();

        private IDomainNotificationService _domainNotificationService = new DomainNotificationService();

        private readonly CausaFixture _causaFixture;

        private CausaService _causaServices;
        private readonly ICausaService _causaIService;

        private Mock<IMapper> _mapper;

        private readonly CausaViewModel _causaModelValida;

        public CausaServicesTest(CausaFixture causaFixture)
        {
            _causaFixture = causaFixture;

            _mapper = new Mock<IMapper>();

            _causaModelValida = causaFixture.CausaModelValida();

            _causaIService = new CausaService(_causaRepository.Object, _mapper.Object);
        }

        #region Testes método "Adicionar"

        [Fact]
        [Trait("CausaService", "Causa_Adicionar_CausaValida")]
        public void Causa_Adicionar_CausaValida()
        {
            // Arrange
            _causaServices = new CausaService(_causaRepository.Object, _mapper.Object);

            // Act
            var retorno = _causaServices.Adicionar(_causaModelValida);

            Assert.True(retorno.IsCompletedSuccessfully);
        }

        [Fact]
        [Trait("CausaService", "Causa_Adicionar_CausaInvalida")]
        public void Causa_Adicionar_CausaInvalida()
        {
            // Arrange
            var causa = _causaFixture.CausaInvalida();
            var causaModelInvalida = new CausaViewModel();
            _mapper.Setup(a => a.Map<CausaViewModel, Causa>(causaModelInvalida)).Returns(causa);

            _causaServices = new CausaService(_causaRepository.Object, _mapper.Object);

            // Act
            var retorno = _causaServices.Adicionar(causaModelInvalida);

            Assert.True(retorno.IsCompletedSuccessfully);
        }

        #endregion

        #region Testes método "RecuperarCausas"

        [Fact]
        [Trait("CausaService", "Causa_RecuperarCausas_CausaValida")]
        public void Causa_RecuperarCausas_CausaValida()
        {
            // Arrange
            _causaServices = new CausaService(_causaRepository.Object, _mapper.Object);

            // Act
            var retorno = _causaServices.RecuperarCausas();

            Assert.False(retorno == null);
        }

        #endregion
    }
}
