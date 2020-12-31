using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Vaquinha.Domain;
using Vaquinha.Repository;
using Vaquinha.Repository.Context;
using Vaquinha.Tests.Common.Fixtures;
using Xunit;

namespace Vaquinha.Unit.Tests.RepositoryTests
{
    public class DoacaoRepositoryTests : IClassFixture<DoacaoFixture>
    {
        private readonly Mock<IDoacaoRepository> _iDoacaoRepository = new Mock<IDoacaoRepository>();

        private readonly DoacaoFixture _doacaoFixture;

        private DoacaoRepository _doacaoRepository;
        private readonly IDoacaoRepository _doacaoIRepository;

        private Mock<IMapper> _mapper;

        private readonly VaquinhaOnlineDBContext _dbContext;
        private readonly ILogger<DoacaoRepository> _logger;
        private readonly GloballAppConfig _globalSettings;

        public DoacaoRepositoryTests(DoacaoFixture doacaoFixture)
        {
            _doacaoFixture = doacaoFixture;

            _mapper = new Mock<IMapper>();

            _doacaoIRepository = new DoacaoRepository(_globalSettings, _dbContext, _logger);

        }

        #region Testes método "AdicionarAsync"

        [Fact]
        [Trait("DoacaoRepository", "Doacao_AdicionarAsync_Valida")]
        public void Doacao_AdicionarAsync_Valida()
        {
            // Arrange
            _doacaoRepository = new DoacaoRepository(_globalSettings, _dbContext, _logger);

            // Act
            var retorno = _doacaoRepository.AdicionarAsync(_doacaoFixture.DoacaoValida());

            Assert.True(retorno.IsCompletedSuccessfully);
        }

        [Fact]
        [Trait("DoacaoRepository", "Doacao_AdicionarAsync_Invalida")]
        public void Doacao_AdicionarAsync_Invalida()
        {
            // Arrange
            _doacaoRepository = new DoacaoRepository(_globalSettings, _dbContext, _logger);

            // Act
            var retorno = _doacaoRepository.AdicionarAsync(_doacaoFixture.DoacaoInvalida());

            Assert.False(retorno == null);
        }

        #endregion

        #region Testes método "RecuperarDoadoesAsync"

        [Fact]
        [Trait("DoacaoRepository", "Doacao_RecuperarDoadoesAsync_Valida")]
        public void Doacao_RecuperarDoadoesAsync_Valida()
        {
            // Arrange
            _doacaoRepository = new DoacaoRepository(_globalSettings, _dbContext, _logger);

            // Act
            var retorno = _doacaoRepository.RecuperarDoadoesAsync(1);

            Assert.True(retorno.IsCompletedSuccessfully);
        }

        [Fact]
        [Trait("DoacaoRepository", "Doacao_RecuperarDoadoesAsync_Invalida")]
        public void Doacao_RecuperarDoadoesAsync_Invalida()
        {
            // Arrange
            _doacaoRepository = new DoacaoRepository(_globalSettings, _dbContext, _logger);

            // Act
            var retorno = _doacaoRepository.RecuperarDoadoesAsync(-1);

            Assert.False(retorno == null);
        }

        #endregion
    }
}
